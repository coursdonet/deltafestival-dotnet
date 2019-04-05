using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Entities;

namespace WebApi.Interfaces
{
    public interface IPreventionRepository
    {
        Task<Prevention> GetPreventionByUserIdAsync(int userId);
        Task CreatePreventionAsync(Prevention prevention);
        Task UpdatePreventionAsync(Prevention prevention);
    }
}
