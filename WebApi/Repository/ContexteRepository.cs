using System.Linq;
using System.Threading.Tasks;
using Database;

namespace WebApi.Repository
{
    public class StreakRepository : RepositoryBase<Streak>, IStreakRepository
    {
        public StreakRepository(EfContext _EfContext) : base(_EfContext)
        {
        }

        public async Task<Streak> GetStreak()
        {
            var streak = await FindAllAsync();
            return streak.DefaultIfEmpty(new Streak()).FirstOrDefault();
        }

        public async Task CheckAndUpdateStreak(int teamId)
        {
            var actualStreak = await GetStreak();
            if (actualStreak.TeamID == teamId)
            {
                actualStreak.Lenght += 1;
                Update(actualStreak);
                await SaveAsync();
            }
            else
            {
                actualStreak.Lenght = 1;
                actualStreak.TeamID = actualStreak.TeamID;
            }

        }
    }
}
