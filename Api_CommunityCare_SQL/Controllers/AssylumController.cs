using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Api_CommunityCare_SQL.Models;

namespace Api_CommunityCare_SQL.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AssylumController : ControllerBase
    {
        private readonly CommunityCaresDbContext _context;

        public AssylumController(CommunityCaresDbContext context)
        {
            _context = context;
        }

        // GET: api/Assylum
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Assylum>>> GetAssylums()
        {
          if (_context.Assylums == null)
          {
              return NotFound();
          }
            return await _context.Assylums.ToListAsync();
        }

        // GET: api/Assylum/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Assylum>> GetAssylum(byte id)
        {
          if (_context.Assylums == null)
          {
              return NotFound();
          }
            var assylum = await _context.Assylums.FindAsync(id);

            if (assylum == null)
            {
                return NotFound();
            }

            return assylum;
        }

        // PUT: api/Assylum/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAssylum(byte id, Assylum assylum)
        {
            if (id != assylum.Id)
            {
                return BadRequest();
            }

            _context.Entry(assylum).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AssylumExists(id))
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

        // POST: api/Assylum
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Assylum>> PostAssylum(Assylum assylum)
        {
          if (_context.Assylums == null)
          {
              return Problem("Entity set 'CommunityCaresDbContext.Assylums'  is null.");
          }
            _context.Assylums.Add(assylum);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAssylum", new { id = assylum.Id }, assylum);
        }

        // DELETE: api/Assylum/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAssylum(byte id)
        {
            if (_context.Assylums == null)
            {
                return NotFound();
            }
            var assylum = await _context.Assylums.FindAsync(id);
            if (assylum == null)
            {
                return NotFound();
            }

            _context.Assylums.Remove(assylum);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool AssylumExists(byte id)
        {
            return (_context.Assylums?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
