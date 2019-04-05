using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Database;
using Entities;


namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlaceController : Controller
    {
        private readonly EfContext _context;

        public PlaceController(EfContext context) => _context = context;

        // GET: api/Place
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Place>>> GetPlaceItems()
        {
            return await _context.Places.ToListAsync();
        }

        // GET: api/Place/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Place>> GetPlaceItem(int id)
        {
            var find = await _context.Places.FindAsync(id);

            if (find == null)
            {
                return NotFound();
            }

            return find;
        }

        // PUT: api/Place/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPlace(int id, Place place)
        {
            if (id != place.Id)
            {
                return BadRequest();
            }

            _context.Entry(place).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PlaceExists(id))
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

        // POST: api/Place
        [HttpPost]
        public async Task<ActionResult<Place>> PostLocalization(Place Places)
        {
            _context.Places.Add(Places);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetLocalization", new { id = Places.Id }, Places);
        }

        // DELETE: api/Place/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Place>> DeleteLocalization(int id)
        {
            var Places = await _context.Places.FindAsync(id);
            if (Places == null)
            {
                return NotFound();
            }

            _context.Places.Remove(Places);
            await _context.SaveChangesAsync();

            return Places;
        }

        private bool PlaceExists(int id)
        {
            return _context.Places.Any(e => e.Id == id);
        }
    }
}
