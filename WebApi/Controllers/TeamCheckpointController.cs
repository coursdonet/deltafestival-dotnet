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
    public class TeamCheckpointController : Controller
    {
        private readonly EfContext _context;

        public TeamCheckpointController(EfContext context)
        {
            _context = context;
        }

        // GET: api/checkpoints
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TeamCheckpoints>>> GetTeamCheckpoint()
        {
            //if (_context.Users.Where(p => p.TicketCode == Request.Headers["Ticket"]).Count() == 0) return Unauthorized("WrongTicketNumber");

            return await _context.TeamCheckpoints.ToListAsync();
        }

        // GET: api/checkpoints/5
        [HttpGet("teamId/{TeamId}")]
        public async Task<ActionResult<IEnumerable<TeamCheckpoints>>> GetTeamCheckpoint(int TeamId)
        {
            //if (_context.Users.Where(p => p.TicketCode == Request.Headers["Ticket"]).Count() == 0) return Unauthorized("WrongTicketNumber");

            var Item = await _context.TeamCheckpoints.Where(p => p.TeamId == TeamId && p.TimeChecked > DateTime.Now.AddHours(-1)).ToListAsync();

            if (Item == null)
            {
                return NotFound();
            }

            return Item;
        }

        // GET: api/checkpoints/5
        [HttpGet("{Id}")]
        public async Task<ActionResult<TeamCheckpoints>> GetTeamCheckpointById(int Id)
        {
            //if (_context.Users.Where(p => p.TicketCode == Request.Headers["Ticket"]).Count() == 0) return Unauthorized("WrongTicketNumber");

            var Item = await _context.TeamCheckpoints.FindAsync(Id);

            if (Item == null)
            {
                return NotFound();
            }

            return Item;
        }

        // POST: api/checkpoints
        [HttpPost]
        public async Task<ActionResult<TeamCheckpoints>> PostTeamCheckpoint(TeamCheckpoints item)
        {
            item.TimeChecked = DateTime.Now;
            _context.TeamCheckpoints.Add(item);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetTeamCheckpointById), new { id = item.Id }, item);
        }

        // PUT: api/checkpoints/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTeamCheckpoint(int id, TeamCheckpoints item)
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
        public async Task<IActionResult> DeleteTeamCheckpoint(int id)
        {
            var todoItem = await _context.TeamCheckpoints.FindAsync(id);

            if (todoItem == null)
            {
                return NotFound();
            }

            _context.TeamCheckpoints.Remove(todoItem);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
