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
    public class LoginController : Controller
    {
        private readonly CpContext _context;

        public LoginController(CpContext context) => _context = context;

        // GET: login/ticketnumber
        [HttpGet("{ticket}")]
        public async Task<ActionResult<User>> Login(String ticket)
        {
            var todoItem = await _context.Users.Where(p => p.TicketCode == ticket).FirstOrDefaultAsync();

            if (todoItem == null)
            {
                return NotFound();
            }

            return todoItem;
        }

    }
}
