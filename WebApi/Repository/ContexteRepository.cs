using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Database;
using Entities;
using WebApi.Interfaces;

namespace WebApi.Repository
{
    public class ContexteRepository : RepositoryBase<Contexte>, IContexteRepository
    {


        public ContexteRepository(EfContext _EfContext) : base(_EfContext)
        {
        }

        public async Task CheckAndUpdateStreakAsync(int teamId)
        {

            //Definir les noms des clés en BBD.
            Contexte teamIdStreak, lenghtStreak = new Contexte();
            var contexte = await GetContexte();
            if (contexte.TryGetValue("", out teamIdStreak) && contexte.TryGetValue("", out lenghtStreak))
            {
                if (int.Parse(teamIdStreak.value) == teamId)
                {
                    int lenght = int.Parse(lenghtStreak.value) + 1;
                    lenghtStreak.value = lenght.ToString();
                    Update(lenghtStreak);
                    await SaveAsync();
                } else {
                    
                    int lenght = int.Parse(lenghtStreak.value) + 1;
                    lenghtStreak.value = "0";
                    teamIdStreak.value = teamId.ToString();
                    Update(teamIdStreak);
                    Update(lenghtStreak);
                    await SaveAsync();
                }
            }
        }

        public async Task<int> getSteakAsync()
        {
            Contexte lenghtStreak = new Contexte();
            var contexte = await GetContexte();
            if (contexte.TryGetValue("", out lenghtStreak))
            {
                return int.Parse(lenghtStreak.value);
            }
            return -1;
        }

        public async Task<IDictionary<string, Contexte>> GetContexte()
        {
            var contextes = await FindAllAsync();
            return contextes.ToDictionary(x => x.key);
        }
    }
}
