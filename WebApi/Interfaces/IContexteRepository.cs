using System.Collections.Generic;
using System.Threading.Tasks;
using Entities;

namespace WebApi.Interfaces
{
    public interface IContexteRepository
    {
        Task<IDictionary<string, Contexte>> GetContexte();
        Task CheckAndUpdateStreak(int teamId);
        Task<int> getSteak();
    }
}
