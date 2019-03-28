using Database;
using DeltaFestival.IRepository;
using DeltaFestival.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DeltaFestival.Repository
{
    public class RoleRepository : GenericRepository<Role>, IRoleRepository
    {
        public RoleRepository(EfContext efContext) : base(efContext)
        {
        }
    }
}
