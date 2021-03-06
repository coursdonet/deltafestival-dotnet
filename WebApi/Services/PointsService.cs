using System.Threading.Tasks;
using WebApi.Interfaces;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApi.Services
{
    public class PointsService
    {
        const int CHECKPOINT_POINT = 0;
        const int CHAT_POINT = 0;
        const int HEARTH_STROKE_POINT = 0;

        // TODO : Injection de dépendance pour initialiser le repo ?
        private readonly IRepositoryWrapper repository;

        public async Task AddPointsValidateCheckPoint(int id)
        {
            //TODO: Combo Management & Last CheckPoint Management
            await repository.Ranking.AddPointAsync(id, CHECKPOINT_POINT);
        }

        public async Task RemovePointsNotValidateCheckPoint(int id)
        {

            await repository.Ranking.RemovePointAsync(id, CHECKPOINT_POINT);
        }

        public async Task AddPointsPostChat(int id)
        {

            //TODO: Combo Management & Last CheckPoint Management
            await repository.Ranking.AddPointAsync(id, CHAT_POINT);
        }

        public async Task AddPointsHearthStrokeChat(int id)
        {
            await repository.Ranking.AddPointAsync(id, HEARTH_STROKE_POINT);

        }
    }
}
