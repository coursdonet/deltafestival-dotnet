using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebApi.Interfaces;
using Entities;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PreventionController : ControllerBase
    {
        private readonly IRepositoryWrapper repository;

        const string MSG_WATER = "Attention!!! Il faut boire de l'eau.";
        const string MSG_ALCOOL = "Attention!!! ne prend pas le volant.";

        [HttpPost("{id}")]
        public async Task<IActionResult> AddGlass(int userId, [FromBody] int type)
        {
            try
            {
                var prevention = await repository.Prevention.GetPreventionByUserIdAsync(userId);
                if(prevention == null)
                {
                    prevention.UserId = userId;
                    prevention.lastAlcoolDate = DateTime.Now;
                    prevention.lastWaterDate = DateTime.Now;
                    prevention.Watercount = 0;
                    prevention.Alcoolcount = 0;
                }
                switch (type)
                {
                    case 0:
                        prevention.Watercount += 1;
                        if (prevention.lastWaterDate <= DateTime.Now.AddHours(-1))
                        {
                            prevention.message = MSG_WATER;
                        }
                        prevention.lastWaterDate = DateTime.Now;
                        break;
                    case 1:
                        prevention.Alcoolcount += 1;
                        if (prevention.lastAlcoolDate <= DateTime.Now.AddHours(-1))
                        {
                            prevention.message = MSG_ALCOOL;
                        }
                        prevention.lastAlcoolDate = DateTime.Now;
                        break;
                }
                await repository.Prevention.UpdatePreventionAsync(prevention);
                return Ok(prevention);

            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }
    }
}
