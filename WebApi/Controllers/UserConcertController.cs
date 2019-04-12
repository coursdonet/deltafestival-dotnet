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
    public class UserConcertController : Controller
    {
        private readonly EfContext _context;
        public UserConcertController(EfContext context) => _context = context;


        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserConcerts>>> GetUserConcertsItems()
        {
            return await _context.UserConcert.ToListAsync();
        }

        //Return all subscribed concerts from an user id
        [HttpGet("{userId}")]
        public async Task<ActionResult<IEnumerable<UserConcerts>>> GetUserConcertsById(int userId)
        {
            List<UserConcerts> find = await _context.UserConcert.Where(r => r.UserId == userId && r.Concert.Hour.AddMinutes(r.Concert.Duration) > DateTime.Now).Include(p => p.Concert).ThenInclude(p => p.ConcertLocation).OrderBy(p => p.Concert.Hour).ToListAsync();

            if (find == null)
            {
                return NotFound();
            }

            return find;
        }


        [HttpPost]
        public async Task<ActionResult<IEnumerable<UserConcerts>>> PostUserConcertItem(UserConcerts item)
        {
            Concert concert = _context.Concert.Find(item.ConcertId);
            UserConcerts userConcert = _context.UserConcert.Where(r => r.UserId == item.UserId
                && !(concert.Hour >= r.Concert.Hour.AddMinutes(r.Concert.Duration)
                || concert.Hour.AddMinutes(concert.Duration) <= r.Concert.Hour)).Include(p => p.Concert).FirstOrDefault();
            if (userConcert != null)
            {
                return Unauthorized("Tu crois vraiment pouvoir voir " + concert.Artist + " en même temps que " + userConcert.Concert.Artist + " ?" );
            }

            _context.UserConcert.Add(item);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetUserConcertsItems), item);
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUserConcertItem(int id)
        {
            var item = await _context.UserConcert.FindAsync(id);

            if (item == null)
            {
                return NotFound();
            }

            _context.UserConcert.Remove(item);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
