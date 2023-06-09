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
    public class CollectController : ControllerBase
    {
        private readonly CommunityCaresDbContext _context;

        public CollectController(CommunityCaresDbContext context)
        {
            _context = context;
        }

        // GET: api/Collect
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Collect>>> GetCollects()
        {
          if (_context.Collects == null)
          {
              return NotFound();
          }
            return await _context.Collects.ToListAsync();
        }

        // GET: api/Collect/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Collect>> GetCollect(int id)
        {
          if (_context.Collects == null)
          {
              return NotFound();
          }
            var collect = await _context.Collects.FindAsync(id);

            if (collect == null)
            {
                return NotFound();
            }

            return collect;
        }

        // PUT: api/Collect/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCollect(int id, Collect collect)
        {
            if (id != collect.Id)
            {
                return BadRequest();
            }

            _context.Entry(collect).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CollectExists(id))
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

        // POST: api/Collect
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Collect>> PostCollect(Collect collect)
        {
          if (_context.Collects == null)
          {
              return Problem("Entity set 'CommunityCaresDbContext.Collects'  is null.");
          }
            _context.Collects.Add(collect);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCollect", new { id = collect.Id }, collect);
        }

        // DELETE: api/Collect/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCollect(int id)
        {
            if (_context.Collects == null)
            {
                return NotFound();
            }
            var collect = await _context.Collects.FindAsync(id);
            if (collect == null)
            {
                return NotFound();
            }

            _context.Collects.Remove(collect);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CollectExists(int id)
        {
            return (_context.Collects?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
