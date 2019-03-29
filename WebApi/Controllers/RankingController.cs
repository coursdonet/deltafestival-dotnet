using System;
using System.Threading.Tasks;
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

        public RankingController(IRepositoryWrapper repository)
        {
            this.repository = repository;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> RankingBetweenTeam(int id, [FromBody] int count)
        {
            try
            {
                var item = await repository.Team.GetTeamByIdAsync(id);
                if (item == null)
                {
                    return NotFound();
                }
                return Ok(await repository.Ranking.GetRankingBetweenTeamAsync(id, count));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet]
        public async Task<IActionResult> Ranking()
        {
            try
            {
                return Ok(await repository.Ranking.GetRankingAsync());
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
