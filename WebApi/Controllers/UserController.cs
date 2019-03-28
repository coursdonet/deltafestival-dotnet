using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Database;
using DeltaFestival.IRepository;
using DeltaFestival.Models;
using DeltaFestivalAPI.Transverse;
using Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DeltaFestival.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private List<User> listOfPotentialCrushes;
        private List<int> ignoredOrCrushedPeople;

        //private readonly DeltaDbContext _context;
        private readonly IUserRepository _userRepository;

        [AllowAnonymous]
        [HttpPost("authenticate")]
        public string Authenticate(string TicketCode)
        {
            var user = _userRepository.Authenticate(TicketCode);

            if (user == null)
                return "Username or password is incorrect";

            return user.Token.ToString();
        }

        public UserController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
            listOfPotentialCrushes = new List<User>();
            ignoredOrCrushedPeople = new List<int>();
        }

        // GET all user
        [HttpGet]
        public List<User> GetAll()
        {

            //Données bouchons
            Bouchons b = new Bouchons();
            return b.GetAllBouchonUser();

            /* A décommenter pour mettre en prod */
            //return _userRepository.GetAll().ToList();
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public User Get(int id)
        {
            return _userRepository.FindBy(c => c.Id == id).FirstOrDefault();
        }

        // Add user
        [HttpPost]
        public bool Post(User user)
        {
            try
            {
                _userRepository.Add(user);
                _userRepository.Save();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }

            return true;
        }

        // Edit User
        [HttpPut("{id}")]
        public bool Put(User user)
        {
            try
            {
                User olderUser = _userRepository.FindBy(c => c.Id == user.Id).FirstOrDefault();

                #region Edit properties
                olderUser.MoodId = user.MoodId;
                olderUser.Publications = user.Publications;
                olderUser.Role = user.Role;
                olderUser.TicketCode = user.TicketCode;
                #endregion
                
                _userRepository.Save();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }

            return true;

        }

        // DELETE user by id
        [HttpDelete("{id}")]
        public bool Delete(int id)
        {
            try
            {
                User user = _userRepository.FindBy(c => c.Id == id).FirstOrDefault();
                _userRepository.Delete(user);
                _userRepository.Save();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }

            return true;

        }

    }
}
