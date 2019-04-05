using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Entities;
using WebApi.Interfaces;
using Database;
using WebApi.Repository;

namespace WebApi.Repository
{
    public class TeamRepository : RepositoryBase<Team>, ITeamRepository
    {

        public TeamRepository(EfContext EfContext) : base(EfContext)
        {

        }              

        public async Task<IEnumerable<Team>> GetAllTeamsAsync()
        {
            var teams = await FindAllAsync();
            return teams.OrderBy(x => x.Name);
        }

        public async Task<Team> GetTeamByIdAsync(int id)
        {
            var team = await FindByConditionAsync(o => o.Id.Equals(id));
            return team.DefaultIfEmpty(new Team()).FirstOrDefault();
        }

        public async Task CreateTeamAsync(Team team)
        {
            Create(team);
            await SaveAsync();
        }

        public async Task UpdateTeamAsync(Team team)
        {
            Update(team);
            await SaveAsync();
        }

        public async Task DeleteTeamAsync(Team user)
        {
            Delete(user);
            await SaveAsync();
        }
    }
}
