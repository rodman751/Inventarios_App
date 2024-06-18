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
    public class AjusteController : ControllerBase
    {
        private readonly DBcontext _context;

        public AjusteController(DBcontext context)
        {
            _context = context;
        }

        // GET: api/Ajuste
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Ajustes>>> GetAjuste()
        {
            //return await _context.Ajuste.ToListAsync();
            var ajustes = await _context.Ajuste
                .Include(d => d.Productos)
                .ToListAsync();
            return Ok(ajustes);
        }

        // GET: api/Ajuste/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Ajustes>> GetAjuste(int id)
        {
            var ajuste = await _context.Ajuste
                .Include(d => d.Productos)
                .FirstOrDefaultAsync(p => p.Id == id);

            if (ajuste == null)
            {
                return NotFound();
            }

            return ajuste;
        }

        // PUT: api/Ajuste/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAjuste(int id, Ajustes ajuste)
        {
            if (id != ajuste.Id)
            {
                return BadRequest();
            }

            _context.Entry(ajuste).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AjusteExists(id))
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

        // POST: api/Ajuste
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Ajustes>> PostAjuste(Ajustes ajuste)
        {
            _context.Ajuste.Add(ajuste);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAjuste", new { id = ajuste.Id }, ajuste);
        }

        // DELETE: api/Ajuste/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAjuste(int id)
        {
            var ajuste = await _context.Ajuste.FindAsync(id);
            if (ajuste == null)
            {
                return NotFound();
            }

            _context.Ajuste.Remove(ajuste);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool AjusteExists(int id)
        {
            return _context.Ajuste.Any(e => e.Id == id);
        }
    }
}
