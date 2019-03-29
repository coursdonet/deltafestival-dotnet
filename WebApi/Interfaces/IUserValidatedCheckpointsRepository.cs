using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Entities;

namespace WebApi.Interfaces
{
    public interface IUserValidatedCheckpointsRepository
    {
        Task<IEnumerable<UserValidatedCheckpoints>> getLastUserValidatedCheckpoints();
        Task<int> getUserValidatedCheckpointsCount(int teamId);
    }
}
