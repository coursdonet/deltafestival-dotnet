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
    public interface IUserService
    {
        User Authenticate(string username, string password);
        IEnumerable<User> GetAll();
    }

    public class UserService 
    {
        private readonly EfContext _context;

        // users hardcoded for simplicity, store in a db with hashed passwords in production applications
        private List<User> _users;


        private readonly AppSettings _appSettings;

        public UserService(IOptions<AppSettings> appSettings, EfContext context)
        {
            _appSettings = appSettings.Value;
            _context = context;
            //TODO make async
            _users = _context.Users.ToList();
        }

        //public User Authenticate(string email, string password)
        //{

        //    var user = _users.SingleOrDefault(x => x.Email == email && x.Password == password);

        //    // return null if user not found
        //    if (user == null)
        //        return null;

        //    // authentication successful so generate jwt token
        //    var tokenHandler = new JwtSecurityTokenHandler();
        //    var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
        //    var tokenDescriptor = new SecurityTokenDescriptor
        //    {
        //        Subject = new ClaimsIdentity(new Claim[]
        //        {
        //            new Claim(ClaimTypes.Name, user.Id.ToString())
        //        }),
        //        Expires = DateTime.UtcNow.AddDays(7),
        //        SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
        //    };
        //    var token = tokenHandler.CreateToken(tokenDescriptor);
        //    user.Token = tokenHandler.WriteToken(token);

        //    // remove password before returning
        //    user.Password = null;

        //    return user;
        //}

        // TODO authenticate with qrcode
        //   public User AuthenticateID(String code)


        public List<User> GetAll()
        {
            // return users without passwords
            return _users.ToList();
        }
    }
}
