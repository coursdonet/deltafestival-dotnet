using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Entities;
using WebApi.Helpers;
using Database;

namespace WebApi.Services
{
    /*
     * Interface for service authentification
     */
    public interface IUserService
    {
        User Authenticate(string username, string password);
        User AuthenticateId(int idCode);
        User AuthenticateEmail(string Email);
        User AuthenticateTicket(string ticket);
        IEnumerable<User> GetAll();
    }

    /*
     * Class Service for authentification
     * 
     */
    public class UserService : IUserService
    {
        private readonly BrownContext _context;

        // users hardcoded for simplicity, store in a db with hashed passwords in production applications
        private List<User> _users;


        private readonly AppSettings _appSettings;

        public UserService(IOptions<AppSettings> appSettings, BrownContext context)
        {
            _appSettings = appSettings.Value;
            _context = context;
            //TODO make async
            _users = _context.Users.ToList();
        }

        /*
         * Auth. by Email and Password on JWT
         */
        public User Authenticate(string email, string password)
        {

            var user = _users.SingleOrDefault(x => x.Email == email && x.Password == password);

            // return null if user not found
            if (user == null)
                return null;

            // authentication successful so generate jwt token
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, user.Id.ToString())
                }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            user.Token = tokenHandler.WriteToken(token);

            // remove password before returning
            user.Password = null;

            return user;
        }

        /*
         * Auth. with User'sId
         * 
         */
        public User AuthenticateId(int idCode)
        {
            var user = _users.SingleOrDefault(x => x.Id == idCode);
            return user;

        }
        
        /*
         * Auth with User's Email
         * 
         */
        public User AuthenticateEmail(string Email)
        {
            var user = _users.SingleOrDefault(x => x.Email == Email);
            return user;

        }

        /*
        * Auth with User's Ticket
        * 
        */
        public User AuthenticateTicket(string ticket)
        {
            var user = _users.SingleOrDefault(x => x.TicketCode == ticket);
            return user;
        }

        /*
         *  Service function to get all users
         */
        public IEnumerable<User> GetAll()
        {
            // return users without passwords
            return _users.Select(x => {
                x.Password = null;
                return x;
            });
        }
    }
}
