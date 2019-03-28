using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Entities;
using WebApi.Interfaces;
using Database;

namespace WebApi.Repository
{
    public class RankingRepository : RepositoryBase<Team>, IRankingRepository
    {

        public RankingRepository(EfContext EfContext) : base(EfContext)
        {

        }

        public async Task<IEnumerable<Team>> GetRankingAsync()
        {
            var ranking = await FindAllAsync();
            return ranking.OrderBy(x => x.score);
        }

        public async Task<IEnumerable<Team>> GetRankingBetweenTeamAsync(int id, int count)
        {
            var ranking = await GetRankingAsync();
            var team = await FindByConditionAsync(o => o.Id.Equals(id));
            int pos = ranking.ToList().IndexOf(team.DefaultIfEmpty(new Team()).FirstOrDefault());
            return ranking.OrderBy(b => b.score).Skip(pos - (count / 2)).Take(count).ToList();
        }

        public async Task AddPointAsync(int id, int point)
        {
            var teams = await FindByConditionAsync(o => o.Id.Equals(id));
            Team team = teams.DefaultIfEmpty(new Team()).FirstOrDefault();
            team.score += point;
            Update(team);
            await SaveAsync();
        }

        public async Task RemovePointAsync(int id, int point)
        {
            var teams = await FindByConditionAsync(o => o.Id.Equals(id));
            Team team = teams.DefaultIfEmpty(new Team()).FirstOrDefault();
            team.score -= point;
            Update(team);
            await SaveAsync();
        }
    }
}
