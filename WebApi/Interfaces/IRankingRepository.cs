using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Entities;

namespace WebApi.Interfaces
{
    public interface IRankingRepository
    {
        Task<IEnumerable<Team>> GetRankingAsync();
        Task<IEnumerable<Team>> GetRankingBetweenTeamAsync(int id, int count);
        Task AddPointAsync(int id, int point);
        Task RemovePointAsync(int id, int point);
    }
}
