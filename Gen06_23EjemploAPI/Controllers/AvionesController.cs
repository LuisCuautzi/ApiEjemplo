using Gen06_23EjemploAPI.Data;
using Gen06_23EjemploAPI.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gen06_23EjemploAPI.Controllers
{
    [ApiController]
    [Route("api/aerolineas/{aerolineaId:int}/aviones")]
    public class AvionesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public AvionesController(ApplicationDbContext context)
        {
            _context = context;
        }

        //Obtener listado de TODOS LOS AVIONES
        [HttpGet("/api/aviones")]
        public async Task<ActionResult<IEnumerable<Avion>>> GetListAviones()
        {
            var listaAviones = await _context.Aviones.Include(a => a.Aerolinea).ToListAsync();

            return listaAviones;
        }

        //Obtener listado de aviones por aerolinea
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Avion>>> GetListAvionesByAerolinea(int aerolineaId)
        {
            var existe = await _context.Aerolineas.AnyAsync(a => a.Id == aerolineaId);
            if (!existe)
            {
                return NotFound($"No existe ninguna aerolinea con el id {aerolineaId}");
            }

            var listaAviones = await _context.Aviones.Include(a => a.Aerolinea).Where(a => a.AerolineaID == aerolineaId).ToListAsync();

            return listaAviones;
        }
        //obtener un avion por id
        [HttpGet("/api/aviones/{id:int}", Name = "GetAvionById")]
        public async Task<ActionResult<Avion>> GetAvionById(int id)
        {
        var avion = await _context.Aviones.Include(a => a.Aerolinea).FirstOrDefaultAsync(a => a.Id == id);
        if (avion == null)
        {
            return NotFound($"No existe ningun avion con el id {id}");
        }
        return avion;
        }

        //Regristrar un avion
        [HttpPost]
        public async Task<ActionResult> RegistarAvion([FromBody] Avion avion, int aerolineaId)
        {
            var existe = await _context.Aerolineas.AnyAsync(a => a.Id == aerolineaId);
            if (!existe)
            {
                return NotFound($"No existe ningun avion con el id{aerolineaId}");
            }

            existe = await _context.Aviones.Include(a => a.Aerolinea).AnyAsync(a => a.NumRegistro == avion.NumRegistro);
            if (existe)
            {
                return BadRequest($"Ya existe un avion con el numero de registro{avion.NumRegistro}");
            }

            _context.Aviones.Add(avion);
            await _context.SaveChangesAsync();

            avion.Aerolinea = _context.Aerolineas.Find(aerolineaId);

            return CreatedAtRoute("GetAvionById", new { id = avion.Id }, avion);
        }

        //Actualizar un avion
        [HttpPut("{id:int}")]
        public async Task<ActionResult> UpdateAvion([FromBody] Avion avion, int aerolineaId, int id)
        {
            var existe = await _context.Aviones.AnyAsync(a => a.Id == aerolineaId);
            if (!existe)
            {
                return NotFound($"No existe ninguna aerolinea con el id {aerolineaId}");
            }

            if (avion.Id != id)
            {
                return BadRequest("El id del avion no coincide");
            }

            if (avion.AerolineaID != aerolineaId)
            {
                return BadRequest($"La aerolinea del avion no coincide");
            }
            existe = await _context.Aviones.AnyAsync(a => a.Id == id);
            if (!existe)
            {
                return NotFound($"No existe ninguna avion con el id {id}");
            }

            existe = await _context.Aviones.AnyAsync(a => a.Id == id && a.AerolineaID == aerolineaId);
            if (!existe)
            {
                return NotFound("no se encontro el avion solicitado");
            }

            existe = await _context.Aviones.AnyAsync(a => a.NumRegistro == avion.NumRegistro && a.Id != id);
            if (existe)
            {
                return BadRequest("el numero de registro del avion ya fue utilizado");
            }

            _context.Aviones.Update(avion);
            await _context.SaveChangesAsync();
            return NoContent();
        }

        //eliminar un avion
        [HttpDelete("/api/aviones/{id:int}")]
        public async Task<ActionResult> DeleteAvion(int id)
        {
            var avion = await _context.Aviones.FindAsync(id);
            if(avion == null)
            {
                return NotFound($"No existe ningun avion con el id {id}");
            }

            _context.Aviones.Remove(avion);
            await _context.SaveChangesAsync();
            return NoContent();
        }

        //buscar un avion por numRegistro, tipo, modelo, codigomodelo
        [HttpGet("/api/aviones/search/{prefixText}")]
        public async Task<ActionResult<IEnumerable<Avion>>> busqueda(string prefixText)
        {
            var aviones = await _context.Aviones.Include(a => a.Aerolinea).Where(a => a.NumRegistro.Contains(prefixText) || a.Tipo.Contains(prefixText) || 
            a.Modelo.Contains(prefixText) || a.CodigoModelo.Contains(prefixText)).ToListAsync();

            return aviones;
        }

    }

    



}

