using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Database;
using WebApi.Interfaces;
using WebApi.Repository;

namespace WebApi.Repository
{
    public class RepositoryWrapper : IRepositoryWrapper
    {
        private EfContext _efContext;
        private IUserRepository _user;
        private ITeamRepository _team;
        private IRankingRepository _ranking;

        public RepositoryWrapper(EfContext context)
        {
            _efContext = context;
        }

        public IUserRepository User
        {
            get
            {
                if (_user == null)
                {
                    _user = new UserRepository(_efContext);
                }

                return _user;
            }
        }

        public IRankingRepository Ranking
        {
            get
            {
                if (_ranking == null)
                {
                    _ranking = new RankingRepository(_efContext);
                }

                return _ranking;
            }
        }

        public ITeamRepository Team
        {
            get
            {
                if (_team == null)
                {
                    _team = new TeamRepository(_efContext);
                }

                return _team;
            }
        }
    }
}
