using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DeltaFestival.IRepository;
using DeltaFestival.Models;
using Microsoft.AspNetCore.Mvc;

namespace DeltaFestival.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IgnoredController : ControllerBase
    {
        private readonly IIgnoredRepository _ignoredRepository;

        public IgnoredController (IIgnoredRepository ignoredRepository)
        {
            _ignoredRepository = ignoredRepository;
        }

        // GET api/values/5/6
        [HttpGet("{idCurrentUser}/{idIgnored}")]
        public Ignored Get(int idCurrentUser, int idIgnored)
        {
            return _ignoredRepository.FindBy(c => c.IdCurrentUser == idCurrentUser && c.IdIgnored == idIgnored).FirstOrDefault();
        }

        // GET api/values/5
        [HttpGet("{idCurrentUser}")]
        public List<Ignored> GetIgnoredByUser(int idCurrentUser)
        {
            return _ignoredRepository.FindBy(c => c.IdCurrentUser == idCurrentUser).ToList();
        }

        // POST api/values
        [HttpPost]
        public void Post(int idCurrentUser, int idCrush)
        {
            _ignoredRepository.Add(
                new Ignored
                {
                    IdCurrentUser = idCurrentUser,
                    IdIgnored = idCrush
                });
            _ignoredRepository.Save();
        }

    }
}
