using Database;
using WebApi.Interfaces;

namespace WebApi.Repository
{
    public class RepositoryWrapper : IRepositoryWrapper
    {
        private EfContext _efContext;
        private IUserRepository _user;
        private ITeamRepository _team;
        private IRankingRepository _ranking;
        private IContexteRepository _contexte;
        private IUserValidatedCheckpointsRepository _userValidatedCheckpoints;

        public RepositoryWrapper(EfContext context)
        {
            _efContext = context;
        }

        public IUserValidatedCheckpointsRepository UserValidatedCheckpoints
        {
            get
            {
                if (_userValidatedCheckpoints == null)
                {
                    _userValidatedCheckpoints = new UserValidatedCheckpointsRepository(_efContext);
                }

                return UserValidatedCheckpoints;
            }
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

        public IContexteRepository Contexte
        {
            get
            {
                if (_contexte == null)
                {
                    _contexte = new ContexteRepository(_efContext);
                }

                return _contexte;
            }
        }

    }
}
