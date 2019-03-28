using Entities;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using WebApi.Interfaces;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeamController : ControllerBase
    {

        private readonly IRepositoryWrapper repository;

        public TeamController(IRepositoryWrapper repository)
        {
            this.repository = repository;
        }

        [HttpGet]
        public async Task<IActionResult> List()
        {
            try
            {
                var teams = await repository.Team.GetAllTeamsAsync();
                return Ok(teams);
            }
            catch (Exception e)
            {
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetbyId(int id)
        {
            try
            {
                var user = await repository.Team.GetTeamByIdAsync(id);
                if (user == null)
                {
                    return NotFound();
                }
                return Ok(user);
            }
            catch (Exception e)
            {
                return StatusCode(500, "Internal server error ");
            }
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Team team)
        {
            try
            {
                if (team == null || !ModelState.IsValid)
                {
                    return BadRequest();
                }

                if (await repository.Team.GetTeamByIdAsync(team.Id) != null)
                {
                    return Conflict();
                }
                await repository.Team.CreateTeamAsync(team);
            }
            catch (Exception)
            {
                return BadRequest();
            }
            return Ok(team);
        }

        [HttpPut]
        public async Task<IActionResult> Edit([FromBody] Team team)
        {
            try
            {
                if (team == null || !ModelState.IsValid)
                {
                    return BadRequest();
                }
                var existingItem = await repository.Team.GetTeamByIdAsync(team.Id);
                if (existingItem == null)
                {
                    return NotFound();
                }
                await repository.Team.UpdateTeamAsync(team);
            }
            catch (Exception)
            {
                return BadRequest();
            }
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var team = await repository.Team.GetTeamByIdAsync(id);
                if (team == null)
                {
                    return NotFound();
                }
                await repository.Team.DeleteTeamAsync(team);
            }
            catch (Exception)
            {
                return BadRequest();
            }
            return NoContent();
        }
    }
}
