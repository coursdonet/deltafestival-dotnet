using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Entities;


namespace WebApi.Interfaces
{
    public interface ITeamRepository
    {
        Task<IEnumerable<Team>> GetAllTeamsAsync();
        Task<Team> GetTeamByIdAsync(int id);
        Task CreateTeamAsync(Team team);
        Task UpdateTeamAsync(Team team);
        Task DeleteTeamAsync(Team team);
    }
}
