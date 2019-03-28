using DeltaFestival.IRepository;
using Entities;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace DeltaFestival.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TinderController : ControllerBase
    {
        private readonly ITinderRepository _tinderRepository;
        private readonly ICrushRepository _crushRepository;
        private readonly IIgnoredRepository _ignoredRepository;
        private readonly IUserRepository _userRepository;

        public TinderController(ITinderRepository tinderRepository,
            ICrushRepository crushRepository,
            IIgnoredRepository ignoredRepository,
            IUserRepository userRepository)
        {
            _tinderRepository = tinderRepository;
            _crushRepository = crushRepository;
            _ignoredRepository = ignoredRepository;
            _userRepository = userRepository;
        }

        public TinderController(ITinderRepository tinderRepository)
        {
            _tinderRepository = tinderRepository;
        }

        /// <summary>
        /// Retourne le premier utilisateur qui n'a pas encore été match ou ignoré par l'user
        /// </summary>
        [HttpGet]
        public User GetRandomUser(int idCurrentUser)
        {
            List<int> excludedUsers = _crushRepository.FindBy(x => x.IdCurrentUser == idCurrentUser).Select(x => x.IdCrush).ToList();
            excludedUsers.AddRange(_ignoredRepository.FindBy(x => x.IdCurrentUser == idCurrentUser).Select(x => x.IdIgnored).ToList());

            return _userRepository.GetRandomUser(excludedUsers);

        }
    }
}
