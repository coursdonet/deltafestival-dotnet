using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Database;
using Entities;
using WebApi.Interfaces;
using WebApi.Repository;

namespace WebApi.Repository
{
    public class UserRepository : RepositoryBase<User>, IUserRepository
    {
        public UserRepository(EfContext EfContext): base(EfContext)
        {

        }

        public async Task<IEnumerable<User>> GetAllUsersAsync()
        {
            var users = await FindAllAsync();
            return users.OrderBy(x => x.TicketCode);
        }

        public async Task<User> GetUserByIdAsync(int id)
        {
            var user = await FindByConditionAsync(o => o.Id.Equals(id));
            return user.DefaultIfEmpty(new User()).FirstOrDefault();
        }

        public async Task CreateUserAsync(User user)
        {
            Create(user);
            await SaveAsync();
        }

        public async Task UpdateUserAsync(User user)
        {
            Update(user);
            await SaveAsync();
        }

        public async Task DeleteUserAsync(User user)
        {
            Delete(user);
            await SaveAsync();
        }
    }
}
