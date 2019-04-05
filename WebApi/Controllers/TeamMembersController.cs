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
    public class TeamMembersController : ControllerBase
    {
        private readonly EfContext _context;

        public TeamMembersController(EfContext context)
        {
            _context = context;
        }

        // GET: api/TeamMembers
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TeamMembers>>> GetTeamMembers()
        {
            return await _context.TeamMembers.ToListAsync();
        }

        // GET: api/TeamMembers/5
        [HttpGet("{userId}")]
        public async Task<ActionResult<TeamMembers>> GetUserTeam(int userId)
        {
            var teamMembers = await _context.TeamMembers.Where(p => p.UserId == userId && p.IsActive).SingleOrDefaultAsync();

            if (teamMembers == null)
            {
                return NotFound();
            }

            return teamMembers;
        }

        // PUT: api/TeamMembers/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTeamMembers(int id, TeamMembers teamMembers)
        {
            if (id != teamMembers.Id)
            {
                return BadRequest();
            }

            _context.Entry(teamMembers).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TeamMembersExists(id))
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

        // POST: api/TeamMembers
        [HttpPost]
        public async Task<ActionResult<TeamMembers>> PostTeamMembers(TeamMembers teamMembers)
        {
            _context.TeamMembers.Add(teamMembers);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTeamMembers", new { id = teamMembers.Id }, teamMembers);
        }

        // DELETE: api/TeamMembers/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<TeamMembers>> DeleteTeamMembers(int id)
        {
            var teamMembers = await _context.TeamMembers.FindAsync(id);
            if (teamMembers == null)
            {
                return NotFound();
            }

            _context.TeamMembers.Remove(teamMembers);
            await _context.SaveChangesAsync();

            return teamMembers;
        }

        private bool TeamMembersExists(int id)
        {
            return _context.TeamMembers.Any(e => e.Id == id);
        }
    }
}
