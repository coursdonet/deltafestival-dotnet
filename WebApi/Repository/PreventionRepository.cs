using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Database;
using Entities;
using WebApi.Interfaces;

namespace WebApi.Repository
{
    public class PreventionRepository : RepositoryBase<Prevention>, IPreventionRepository
    {

        public PreventionRepository(EfContext _EfContext) : base(_EfContext)
        {
        }

        public async Task CreatePreventionAsync(Prevention prevention)
        {
            Create(prevention);
            await SaveAsync();
        }

        public async Task<Prevention> GetPreventionByUserIdAsync(int userId)
        {
            var prevention = await FindByConditionAsync(o => o.UserId.Equals(userId));
            return prevention.DefaultIfEmpty(new Prevention()).FirstOrDefault();
        }

        public async Task UpdatePreventionAsync(Prevention prevention)
        {
            Update(prevention);
            await SaveAsync();
        }
    }
}
