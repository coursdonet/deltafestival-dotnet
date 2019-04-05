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
    public class UserValidatedCheckPointController : Controller
    {
        private readonly CpContext _context;

        public UserValidatedCheckPointController(CpContext context)
        {
            _context = context;
        }

        // GET: api/checkpoints
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserValidatedCheckpoints>>> GetUserValidatedCheckpointsItems()
        {
            //if (_context.Users.Where(p => p.TicketCode == Request.Headers["Ticket"]).Count() == 0) return Unauthorized("WrongTicketNumber");

            return await _context.UserValidatedCheckpoints.ToListAsync();
        }

        // GET: api/checkpoints/5
        [HttpGet("{UserId}")]
        public async Task<ActionResult<IEnumerable<UserValidatedCheckpoints>>> GetUserValidatedCheckpointsItem(int UserId)
        {
            //if (_context.Users.Where(p => p.TicketCode == Request.Headers["Ticket"]).Count() == 0) return Unauthorized("WrongTicketNumber");

            var todoItem = await _context.UserValidatedCheckpoints.Where(p => p.UserId == UserId).OrderBy(p => p.TimeChecked).ToListAsync();

            if (todoItem == null)
            {
                return NotFound();
            }

            return todoItem;
        }

        // POST: api/checkpoints
        [HttpPost]
        public async Task<ActionResult<UserValidatedCheckpoints>> PostUserValidatedCheckpoint(UserValidatedCheckpoints item)
        {
            //if (_context.Users.Where(p => p.TicketCode == Request.Headers["Ticket"]).Count() == 0) return Unauthorized("WrongTicketNumber");

            // Si le checkpoint est déjà validé où est désactivé on renvoie une erreur
            Checkpoint currCp = _context.Checkpoints.Find(item.CheckpointId);
            if (_context.TeamCheckpoints.Where(p => p.TeamId == item.TeamId && p.CheckpointId == item.CheckpointId && p.TimeChecked > DateTime.Now.AddHours(-1)).Count() > 0
                || _context.UserValidatedCheckpoints.Where(p => p.UserId == item.UserId && p.CheckpointId == item.CheckpointId && p.TimeChecked > DateTime.Now.AddSeconds(-5)).Count() > 0
                || (currCp.LastDisabled == null || currCp.LastDisabled > DateTime.Now.AddHours(-1)))
            {
                return Unauthorized();
            }

            item.TimeChecked = DateTime.Now;
            _context.UserValidatedCheckpoints.Add(item);
            await _context.SaveChangesAsync();

            int UserCheckedCount = _context.UserValidatedCheckpoints
                .Where(p => p.TeamId == item.TeamId && p.CheckpointId == item.CheckpointId && p.TimeChecked > DateTime.Now.AddSeconds(-5))
                .Select(p => p.UserId)
                .Distinct()
                .Count();

            // Si tous les membres du groupe ont validé le checkpoint on le renseigne dans la base
            if (UserCheckedCount == _context.Teams.Find(item.TeamId).MembersCount)
            {
                TeamCheckpoints teamCheckpoints = new TeamCheckpoints();
                teamCheckpoints.TeamId = item.TeamId;
                teamCheckpoints.CheckpointId = item.CheckpointId;
                teamCheckpoints.TimeChecked = DateTime.Now;

                _context.TeamCheckpoints.Add(teamCheckpoints);
                await _context.SaveChangesAsync();

                if (_context.TeamCheckpoints.Where(p => p.TeamId == item.TeamId && p.TimeChecked > DateTime.Now.AddHours(-1)).Count() == 12)
                {
                    DateTime dateTime = DateTime.Now;
                    item.Team.WinDate = dateTime;
                    foreach (Checkpoint checkpoint in _context.Checkpoints.ToList())
                    {
                        checkpoint.LastDisabled = dateTime;
                    }

                    Team team = await _context.Teams.FindAsync(item.TeamId);
                    team.WinDate = DateTime.Now;
                    await _context.SaveChangesAsync();
                }
            }

            return CreatedAtAction(nameof(GetUserValidatedCheckpointsItems), new { id = item.Id }, item);
        }
    }
}
