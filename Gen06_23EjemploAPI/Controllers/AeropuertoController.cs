using Gen06_23EjemploAPI.Data;
using Gen06_23EjemploAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gen06_23EjemploAPI.Controllers
{
    [ApiController]
    [Route("api/aeropuertos")]
    public class AeropuertoController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public AeropuertoController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Aeropuerto>>> GetListAeropuerto()
        {
            var listaAeropuerto = await _context.Aeropuertos.ToListAsync();
            return listaAeropuerto;
        }

        [HttpGet("{id:int}", Name = "GetAeropuertoById")]
        public async Task<ActionResult<Aeropuerto>> GetAeropuertoById(int id)
        {
            var aeropuerto = await _context.Aeropuertos.FirstOrDefaultAsync(a => a.Id == id);
            if(aeropuerto == null)
            {
                return NotFound("Aeropuerto no encontrado");
            }

            return aeropuerto;
        }

        [HttpPost]
        public async Task<ActionResult> RegristrarAeropuerto([FromBody] Aeropuerto aeropuerto)
        {
            var existe = await _context.Aeropuertos.AnyAsync(a => a.Nombre == aeropuerto.Nombre);   
            if(existe)
            {
                return BadRequest($"Ya hay un aeropuerto com ese nombre: {aeropuerto.Nombre}");
            }
            _context.Aeropuertos.Add(aeropuerto);
            await _context.SaveChangesAsync();
            return CreatedAtRoute("GetAeropuertoById", new { id = aeropuerto.Id }, aeropuerto);
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult> UpdateAeropuerto([FromBody] Aeropuerto aeropuerto, int id)
        {
            if (aeropuerto.Id != id)
            {
                return BadRequest("No se encuentra es ID");
            }
            var existe = await _context.Aeropuertos.AnyAsync(a => a.Nombre == aeropuerto.Nombre && a.Id != id);

            if (existe)
            {
                return BadRequest("El nombre del aeropuerto ya fue utilizado");
            }
            _context.Aeropuertos.Update(aeropuerto);
            await _context.SaveChangesAsync();
            return NoContent();
        }

        
        [HttpDelete("{id:int}")]
        public async Task<ActionResult> DeleteAeropuerto(int id)
        {
            var aeropuerto = await _context.Aeropuertos.FindAsync(id);
            if (aeropuerto == null)
            {
                return NotFound("Esa aerolinea no esta registrada");
            }
            _context.Aeropuertos.Remove(aeropuerto);
            await _context.SaveChangesAsync();
            return NoContent();
        }

        //Buscar una aerilinea po nombre, por pais, por codigo
        [HttpGet("{prefixText}")]
        public async Task<ActionResult<IEnumerable<Aeropuerto>>> BuscarAeropuerto(string prefixText)
        {
            var aeropuerto = await _context.Aeropuertos.Where(a => a.Nombre.Contains(prefixText) ||
                                                                  a.IATA.Contains(prefixText) ||
                                                                  a.ICAO.Contains(prefixText) ||
                                                                  a.Longuitud.Contains(prefixText) ||
                                                                  a.Latitud.Contains(prefixText) ||
                                                                  a.ZonaHoraria.Contains(prefixText) ||
                                                                  a.Terminal.Contains(prefixText) ||
                                                                  a.Pais.Contains(prefixText)).ToListAsync();

            return aeropuerto;
        }
    }
}
