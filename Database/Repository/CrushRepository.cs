using Database;
using DeltaFestival.IRepository;
using DeltaFestival.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace DeltaFestival.Repository
{
    public class CrushRepository : GenericRepository<Crush>, ICrushRepository
    {
        public CrushRepository(EfContext efContext) : base(efContext)
        {
        }
    }
}
