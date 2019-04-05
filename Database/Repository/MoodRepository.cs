using Database;
using DeltaFestival.IRepository;
using DeltaFestival.Repository;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DeltaFestival.Repository
{
    public class MoodRepository : GenericRepository<Mood>, IMoodRepository
    {
        public MoodRepository(EfContext efContext) : base(efContext)
        {
        }
    }
}
