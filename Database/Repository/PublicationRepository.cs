using DeltaFestival.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Entities;
using Database;

namespace DeltaFestival.Repository
{
    public class PublicationRepository : GenericRepository<Publication>, IPublicationRepository
    {
        public PublicationRepository(EfContext efContext) : base(efContext)
        {
        }
    }
}
