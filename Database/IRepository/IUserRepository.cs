using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DeltaFestival.IRepository
{
    public interface IUserRepository : IGenericRepository<User>
    {
        User Authenticate(string ticketCode);
        User GetRandomUser(List<int> excludedUser);        
    }
}
