using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApi.Interfaces;
using Entities;


namespace WebApi.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IRepositoryWrapper repository;

        [HttpGet]
        public async Task<IActionResult> List()
        {
            try
            {
                var users = await repository.User.GetAllUsersAsync();
                return Ok(users);
            }catch (Exception e){
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetbyId (int id)
        {
            try
            {
                var user = await repository.User.GetUserByIdAsync(id);
                if (user == null)
                {
                    return NotFound(UserErrorCode.RecordNotFound.ToString());
                }
                return Ok(user);
            }
            catch (Exception e)
            {
                return StatusCode(500, "Internal server error ");
            }
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] User user)
        {
            try
            {
                if (user == null || !ModelState.IsValid)
                {
                    return BadRequest(UserErrorCode.UserPseudonymeAndEtatRequired.ToString());
                }
                    
                if (await repository.User.GetUserByIdAsync(user.Id) != null)
                {
                    return StatusCode(StatusCodes.Status409Conflict, UserErrorCode.UserIdInUse.ToString());
                }
                await repository.User.CreateUserAsync(user);
            }
            catch (Exception)
            {
                return BadRequest(UserErrorCode.CouldNotCreateUser.ToString());
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
                    return BadRequest(UserErrorCode.UserPseudonymeAndEtatRequired.ToString());
                }
                var existingItem = await repository.User.GetUserByIdAsync(user.Id);
                if (existingItem == null)
                {
                    return NotFound(UserErrorCode.RecordNotFound.ToString());
                }
                await repository.User.UpdateUserAsync(user);
            }
            catch (Exception)
            {
                return BadRequest(UserErrorCode.CouldNotUpdateUser.ToString());
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
                    return NotFound(UserErrorCode.RecordNotFound.ToString());
                }
                await repository.User.DeleteUserAsync(user);
            }
            catch (Exception)
            {
                return BadRequest(UserErrorCode.CouldNotDeleteUser.ToString());
            }
            return NoContent();
        }
    }

    public enum UserErrorCode
    {
        UserPseudonymeAndEtatRequired,
        UserIdInUse,
        RecordNotFound,
        CouldNotCreateUser,
        CouldNotUpdateUser,
        CouldNotDeleteUser
    }
}
