using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Entities;
using Microsoft.AspNetCore.Mvc;
using WebApi.Interfaces;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RankingController : ControllerBase
    {
        private readonly IRepositoryWrapper repository;



        [HttpGet("{id}")]
        public async Task<IActionResult> RankingBetweenTeam(int id, [FromBody] int count) {
            try
            {
                var item = await repository.Team.GetTeamByIdAsync(id);
                if (item == null)
                {
                    return NotFound(TeamErrorCode.RecordNotFound.ToString());
                }
                return Ok(await repository.Ranking.GetRankingBetweenTeamAsync(id, count));
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpGet]
        public async Task<IActionResult> Ranking() {
            try
            {
                return Ok(await repository.Ranking.GetRankingAsync());
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
    }
}
