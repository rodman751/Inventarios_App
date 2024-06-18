using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Entidades;

namespace Inventaio.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuditoriaController : ControllerBase
    {
        private readonly DBcontext _context;

        public AuditoriaController(DBcontext context)
        {
            _context = context;
        }

        // GET: api/Auditoria
        [HttpGet]
        public async Task<ActionResult<IEnumerable<object>>> GetAuditoria()
        {
            var auditoriaList = await _context.Auditoria
                .Include(a => a.Usuarios)
                .Include(a => a.Ajustes)
                .ToListAsync();

            var result = auditoriaList.Select(a => new
            {
                Id = a.Id,
                UsuarioId = a.usuario_id,
                Usuarios = a.Usuarios == null ? null : new
                {
                    Id = a.Usuarios.Id,
                    NombreUsuario = a.Usuarios.nombre_usuario,
                    Contrasena = a.Usuarios.contrasena,
                    RolId = a.Usuarios.rol_id,
                    Roles = a.Usuarios.Roles == null ? null : new
                    {
                        Id = a.Usuarios.Roles.Id,
                        NombreRol = a.Usuarios.Roles.nombre_rol,
                        Usuarios = a.Usuarios.Roles.Usuarios.Select(u => u.nombre_usuario).ToList()
                    }
                },
                Accion = a.accion,
                Fecha = a.fecha,
                Ajustes = a.Ajustes == null ? null : new
                {
                    Id = a.Ajustes.Id,
                    Descripcion = a.Ajustes.descripcion,
                    Fecha = a.Ajustes.fecha,
                    NumeroAjuste = a.Ajustes.numero_ajuste
                }

            }).ToList();

            return Ok(result);
        }


        // GET: api/Auditoria/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Auditoria>> GetAuditoria(int id)
        {
            var auditoria = await _context.Auditoria.FindAsync(id);

            if (auditoria == null)
            {
                return NotFound();
            }

            return auditoria;
        }

        // PUT: api/Auditoria/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAuditoria(int id, Auditoria auditoria)
        {
            if (id != auditoria.Id)
            {
                return BadRequest();
            }

            _context.Entry(auditoria).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AuditoriaExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Auditoria
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Auditoria>> PostAuditoria(Auditoria auditoria)
        {
            _context.Auditoria.Add(auditoria);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAuditoria", new { id = auditoria.Id }, auditoria);
        }

        // DELETE: api/Auditoria/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAuditoria(int id)
        {
            var auditoria = await _context.Auditoria.FindAsync(id);
            if (auditoria == null)
            {
                return NotFound();
            }

            _context.Auditoria.Remove(auditoria);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool AuditoriaExists(int id)
        {
            return _context.Auditoria.Any(e => e.Id == id);
        }
    }
}
