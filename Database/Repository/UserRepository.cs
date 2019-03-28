using Database;
using DeltaFestival.IRepository;
using DeltaFestivalAPI.Helpers;
using Entities;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;


namespace DeltaFestival.Repository
{
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        //private readonly AppSettings _appSettings;

        public UserRepository(EfContext efContext) : base(efContext)
        {
            //_appSettings = appSettings;
        }

        public User Authenticate(string ticketCode)
        {
            //var user = _dbContext.Users.SingleOrDefault(x => x.TicketCode == ticketCode);

            AppSettings app = new AppSettings();

            User user = new User
            {
                Id = 1,
                TicketCode = "5131"
            };
            // return null if user not found
            if (user == null)
                return null;

            // authentication successful so generate jwt token
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes("TESTTOKEN");
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

            //// remove password before returning
            //user.Token = null;

            return user;
        }

        public User GetRandomUser(List<int> excludedUser)
        {
            return _efContext.Set<User>().FirstOrDefault(x => !excludedUser.Contains(x.Id));
        }
    }
}
