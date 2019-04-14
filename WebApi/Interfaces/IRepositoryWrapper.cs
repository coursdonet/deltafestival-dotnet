using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Interfaces
{
    public interface IRepositoryWrapper
    {
        IUserRepository User { get; }
        ITeamRepository Team { get; }
        IRankingRepository Ranking { get; }

    }
}
