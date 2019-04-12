using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Entities;
using Database;
using System;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ConcertController : Controller
    {
        private readonly EfContext _context;
        public ConcertController(EfContext context) => _context = context;

        [HttpGet("user={userId}")]
        public async Task<ActionResult<IEnumerable<Concert>>> GetConcertsItems(int userId)
        {
            var excludedConcerts = await _context.UserConcert.Where(p => p.UserId == userId).Select(p => p.ConcertId).ToArrayAsync();
            List<Concert> concerts = await _context.Concert.Where(p => !excludedConcerts.Contains(p.Id) && p.Hour.AddMinutes(p.Duration) > DateTime.Now).Include(p => p.ConcertLocation).OrderBy(p => p.Hour).ToListAsync();
            return concerts;
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<Concert>> GetConcertItem(int id)
        {
            var find = await _context.Concert.FindAsync(id);

            if (find == null)
            {
                return NotFound();
            }

            return find;
        }


        [HttpPost]
        public async Task<ActionResult<Concert>> PostConcertItem(Concert item)
        {
            _context.Concert.Add(item);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetConcertsItems), new { id = item.Id }, item);
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> PutConcertItem(int id, Concert item)
        {
            if (id != item.Id)
            {
                return BadRequest();
            }

            _context.Entry(item).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent();
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteConcertItem(int id)
        {
            var item = await _context.Concert.FindAsync(id);

            if (item == null)
            {
                return NotFound();
            }

            _context.Concert.Remove(item);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
