using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Database;
using Entities;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CheckpointController : Controller
    {
        private readonly CpContext _context;

        public CheckpointController(CpContext context) => _context = context;

        // GET: api/checkpoints
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Checkpoint>>> GetCheckpointsItems()
        {
            foreach (Checkpoint checkpoint in _context.Checkpoints.Where(r => !r.IsObsolete).ToList())
            {
                checkpoint.IsActive = checkpoint.LastDisabled < DateTime.Now.AddHours(-1);
            }
            await _context.SaveChangesAsync();
            return await _context.Checkpoints.Where(r => !r.IsObsolete).ToListAsync();
        }

        // GET: api/checkpoints/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Checkpoint>> GetCheckpointItem(int id)
        {
            var todoItem = await _context.Checkpoints.FindAsync(id);

            if (todoItem == null)
            {
                return NotFound();
            }

            return todoItem;
        }

        // POST: api/checkpoints
        [HttpPost]
        public async Task<ActionResult<Checkpoint>> PostCheckpointItem(Checkpoint item)
        {
            _context.Checkpoints.Add(item);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetCheckpointsItems), new { id = item.Id }, item);
        }

        // PUT: api/checkpoints/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCheckpointItem(int id, Checkpoint item)
        {
            if (id != item.Id)
            {
                return BadRequest();
            }

            _context.Entry(item).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent();
        }

        // DELETE: api/Todo/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCheckpointItem(int id)
        {
            var todoItem = await _context.Checkpoints.FindAsync(id);

            if (todoItem == null)
            {
                return NotFound();
            }

            _context.Checkpoints.Remove(todoItem);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
