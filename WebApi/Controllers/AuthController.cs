using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Entities;
using WebApi.Services;
using Database;

namespace WebApi.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private IUserService _userService;
        private readonly BrownContext _context;

        public AuthController(IUserService userService, BrownContext context)
        {
            _userService = userService;
            _context = context;
        }

        [AllowAnonymous]
        [HttpPost("authenticate")]
        public IActionResult Authenticate([FromBody]User userParam)
        {
            /*
            User userT = new User();
            //{ Email = "Test@test.fr", Password = "test" };
            userT.Email = "Test@test.fr";
            userT.Password = "test";
            userT.UserRoleId = 1;
            userT.MoodId = 0;
            userT.TicketCode = "ticket1";
            userT.CanPublish = true;
            userT.Demission = 1;
            userT.IsActive = true;
            userT.Token = "token";
            _context.Add(userT);
            _context.SaveChanges();
            */

            var user = _userService.Authenticate(userParam.Email, userParam.Password);

            if (user == null)
                return BadRequest(new { message = "Email password is incorrect" });

            return Ok(user);
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var users = _userService.GetAll();
            return Ok(users);
        }
    }
}
