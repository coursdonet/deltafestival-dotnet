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
        private readonly CpContext _context;
        public UserConcertController(CpContext context) => _context = context;


        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserConcert>>> GetUserConcertsItems()
        {
            return await _context.UserConcerts.ToListAsync();
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<UserConcert>> GetUserConcertItem(int id)
        {
            var find = await _context.UserConcerts.FindAsync(id);

            if (find == null)
            {
                return NotFound();
            }

            return find;
        }


        [HttpPost]
        public async Task<ActionResult<UserConcert>> PostUserConcertItem(UserConcert item)
        {
            _context.UserConcerts.Add(item);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetUserConcertsItems), new { id = item.Id }, item);
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> PutUserConcertItem(int id, UserConcert item)
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
        public async Task<IActionResult> DeleteUserConcertItem(int id)
        {
            var item = await _context.UserConcerts.FindAsync(id);

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
