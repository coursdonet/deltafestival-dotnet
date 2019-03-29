using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Database;
using Entities;
using WebApi.Interfaces;

namespace WebApi.Repository
{
    public class UserValidatedCheckpointsRepository : RepositoryBase<UserValidatedCheckpoints>, IUserValidatedCheckpointsRepository
    {
        public UserValidatedCheckpointsRepository(EfContext _EfContext) : base(_EfContext)
        {
        }

        public async Task<IEnumerable<UserValidatedCheckpoints>> getLastUserValidatedCheckpoints()
        {
            var userValidatedCheckpoints = await FindAllAsync();
            return userValidatedCheckpoints.OrderBy(b => b.TimeChecked).Take(8).ToList();
        }

        public async Task<int> getUserValidatedCheckpointsCount(int teamId)
        {
            var userValidatedCheckpoints = await FindByConditionAsync(o => o.TeamId.Equals(teamId));
            return userValidatedCheckpoints.Count();
        }
    }
}
