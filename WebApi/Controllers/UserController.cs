using System;
using System.Threading.Tasks;
using Entities;
using Microsoft.AspNetCore.Mvc;
using WebApi.Interfaces;


namespace WebApi.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IRepositoryWrapper repository;

        public UserController(IRepositoryWrapper repository)
        {
            this.repository = repository;
        }

        [HttpGet]
        public async Task<IActionResult> List()
        {
            try
            {
                var users = await repository.User.GetAllUsersAsync();
                return Ok(users);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetbyId(int id)
        {
            try
            {
                var user = await repository.User.GetUserByIdAsync(id);
                if (user == null)
                {
                    return NotFound();
                }
                return Ok(user);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] User user)
        {
            try
            {
                if (user == null || !ModelState.IsValid)
                {
                    return BadRequest();
                }

                if (await repository.User.GetUserByIdAsync(user.Id) != null)
                {
                    return Conflict();
                }
                await repository.User.CreateUserAsync(user);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
            return Ok(user);
        }

        [HttpPut]
        public async Task<IActionResult> Edit([FromBody] User user)
        {
            try
            {
                if (user == null || !ModelState.IsValid)
                {
                    return BadRequest();
                }
                var existingItem = await repository.User.GetUserByIdAsync(user.Id);
                if (existingItem == null)
                {
                    return NotFound();
                }
                await repository.User.UpdateUserAsync(user);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var user = await repository.User.GetUserByIdAsync(id);
                if (user == null)
                {
                    return NotFound();
                }
                await repository.User.DeleteUserAsync(user);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
            return NoContent();
        }
    }
}
