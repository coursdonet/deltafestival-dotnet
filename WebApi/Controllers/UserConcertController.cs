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
    public class UserConcertController : Controller
    {
        private readonly EfContext _context;
        public UserConcertController(EfContext context) => _context = context;


        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserConcert>>> GetUserConcertsItems()
        {
            return await _context.UserConcerts.ToListAsync();
        }

        //Return all subscribed concerts from an user id
        [HttpGet("{userId}")]
        public async Task<ActionResult<IEnumerable<UserConcert>>> GetUserConcertsById(int userId)
        {
            List<UserConcert> find = await _context.UserConcerts.Where(r => r.UserId == userId).ToListAsync();

            foreach (UserConcert userConcert in find)
            {
                userConcert.Concert = _context.Concert.Find(userConcert.ConcertId);
            }

            if (find == null)
            {
                return NotFound();
            }

            return find;
        }


        [HttpPost]
        public async Task<ActionResult<IEnumerable<UserConcert>>> PostUserConcertItem(UserConcert item)
        {
            Concert concert = _context.Concert.Find(item.ConcertId);
            if ( _context.UserConcerts.Where(r => r.UserId == item.UserId && concert.Hour >= r.Concert.Hour && concert.Hour < r.Concert.Hour.AddMinutes(r.Concert.Duration)).Count() > 0)
            {
                return Unauthorized();
            }

            _context.UserConcerts.Add(item);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetUserConcertsItems), item);
        }


        [HttpDelete("{concertId}")]
        public async Task<IActionResult> DeleteUserConcertItem(int concertId, int userId)
        {
            var item = await _context.UserConcerts.FindAsync(concertId, userId);

            if (item == null)
            {
                return NotFound();
            }

            _context.UserConcerts.Remove(item);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
