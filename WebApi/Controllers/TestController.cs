using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestController : ControllerBase
    {

        [HttpGet]
        public IActionResult GetErrorSample()
        {
            throw new Exception("Test exception thrown", new InvalidOperationException("Innet thrown exception"));

           
        }
    }
}
