using AutoMapper;
using Gen06_23EjemploAPI.Data;
using Gen06_23EjemploAPI.DTOs;
using Gen06_23EjemploAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gen06_23EjemploAPI.Controllers
{
    [ApiController]
    [Route("api/aerolineas")]
    public class AerolineasController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper mapper;
         public AerolineasController(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            this.mapper = mapper;

        }
        //private readonly IMapper mapper;

        //obtener la lista de aerolineas
        //obtener cada aerolinea por id
        //registrar una aerolinea
        //actualizar una aerolinea
        //eliminar una aerolinea
        //buscar una aerolinea por nombre, por pais, por codigo 


        //obtener la lista de aerolineas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CAerolinea>>> GetListAerolineas()
        {
            var listaAerolineas = await _context.Aerolineas.Include(a => a.Aviones).ToListAsync();
            return listaAerolineas;
        }

        [HttpGet("{id:int}", Name = "GetAerolineaById")]
        public async Task<ActionResult<CAerolinea>> GetAerolineaById(int id)
        {
            var aerolinea = await _context.Aerolineas.Include(a => a.Aviones).FirstOrDefaultAsync(a => a.Id == id);
            if (aerolinea == null)
            {
                return NotFound("Aerolinea no encontrada");
            }
            return aerolinea;
        }

        //Registrar aerolinea
        [HttpPost]
        public async Task<ActionResult> RegistrarAerolinea([FromBody] AerolineaDTO aerolinea)
        {
            var existe = await _context.Aerolineas.AnyAsync(a => a.Name == aerolinea.Name); 
            if(existe)
            {
                return BadRequest($"Ya hay un aerolinea com ese nombre: {aerolinea.Name}");
            }
            //Proceso para convertir el DTO en el modelo
            var aerolineaObj = mapper.Map<CAerolinea>(aerolinea);


            _context.Aerolineas.Add(aerolineaObj);
            await _context.SaveChangesAsync();
            return CreatedAtRoute("GetAerolineaById", new {id = aerolineaObj.Id},aerolinea);
        }

        //actualizar un aerolinea
        [HttpPut("{id:int}")]
        public async Task<ActionResult> UpdateAerolinea([FromBody] CAerolinea aerolinea, int id)
        {
            if(aerolinea.Id != id)
            {
                return BadRequest("No se encuentra es ID");
            }
            var existe = await _context.Aerolineas.AnyAsync(a => a.Name == aerolinea.Name && a.Id != id);

            if(existe)
            {
                return BadRequest("El nombre de la erolinea ya fue utilizado");
            }
            _context.Aerolineas.Update(aerolinea);
            await _context.SaveChangesAsync();
            return NoContent();
        }

        //Eliminar una aerolinea
        [HttpDelete("{id:int}")]
        public async Task<ActionResult> DeleteAerolinea(int id)
        {
            var aerolinea = await _context.Aerolineas.FindAsync(id);
            if (aerolinea == null)
            {
                return NotFound("Esa aerolinea no esta registrada");
            }
            _context.Aerolineas.Remove(aerolinea);
            await _context.SaveChangesAsync();
            return NoContent();
        }

        //Buscar una aerilinea po nombre, por pais, por codigo
        [HttpGet("{prefixText}")]
        public async Task<ActionResult<IEnumerable<CAerolinea>>> BuscarAerolines(string prefixText)
        {
            var aerolinea = await _context.Aerolineas.Include(a => a.Aviones).Where(a => a.Name.Contains(prefixText) ||
                                                                  a.IATA.Contains(prefixText) ||
                                                                  a.Country.Contains(prefixText)).ToListAsync();

            return aerolinea;
        }

    }
}
