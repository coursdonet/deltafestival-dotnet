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
    public class MoodsController : ControllerBase
    {
        private readonly EfContext _context;

        public MoodsController(EfContext context)
        {
            _context = context;
        }

        // GET: api/Moods
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Mood>>> GetMood()
        {
            return await _context.Mood.ToListAsync();
        }

        // GET: api/Moods/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Mood>> GetMood(int id)
        {
            var mood = await _context.Mood.FindAsync(id);

            if (mood == null)
            {
                return NotFound();
            }

            return mood;
        }

        // PUT: api/Moods/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMood(int id, Mood mood)
        {
            if (id != mood.Id)
            {
                return BadRequest();
            }

            _context.Entry(mood).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MoodExists(id))
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

        // POST: api/Moods
        [HttpPost]
        public async Task<ActionResult<Mood>> PostMood(Mood mood)
        {
            _context.Mood.Add(mood);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMood", new { id = mood.Id }, mood);
        }

        // DELETE: api/Moods/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Mood>> DeleteMood(int id)
        {
            var mood = await _context.Mood.FindAsync(id);
            if (mood == null)
            {
                return NotFound();
            }

            _context.Mood.Remove(mood);
            await _context.SaveChangesAsync();

            return mood;
        }

        private bool MoodExists(int id)
        {
            return _context.Mood.Any(e => e.Id == id);
        }
    }
}
