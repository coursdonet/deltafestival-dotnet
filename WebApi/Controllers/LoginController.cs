using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Database;
using Entities;
using WebApi.Interfaces;
// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {

        private readonly IRepositoryWrapper repository;

        [HttpGet("{ticket}")]
        public async Task<IActionResult> Login(String ticket)
        {
            var user = await repository.User.GetUserByTicketAsync(ticket);

            if (user == null)
            {
                return NotFound();
            }

            return Ok(user);
        }
    }
}
