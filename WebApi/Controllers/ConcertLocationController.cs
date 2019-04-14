using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Entities;
using Database;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ConcertLocationController : Controller
    {
        private readonly CpContext _context;
        public ConcertLocationController(CpContext context) => _context = context;


        [HttpGet]
        public async Task<ActionResult<IEnumerable<ConcertLocation>>> GetConcertLocationsItems()
        {
            return await _context.ConcertLocation.ToListAsync();
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<ConcertLocation>> GetConcertLocationItem(int id)
        {
            var find = await _context.ConcertLocation.FindAsync(id);

            if (find == null)
            {
                return NotFound();
            }

            return find;
        }


        [HttpPost]
        public async Task<ActionResult<ConcertLocation>> PostConcertLocationItem(ConcertLocation item)
        {
            _context.ConcertLocation.Add(item);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetConcertLocationsItems), new { id = item.Id }, item);
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> PutConcertLocationItem(int id, ConcertLocation item)
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
        public async Task<IActionResult> DeleteConcertLocationItem(int id)
        {
            var item = await _context.ConcertLocation.FindAsync(id);

            if (item == null)
            {
                return NotFound();
            }

            _context.ConcertLocation.Remove(item);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
