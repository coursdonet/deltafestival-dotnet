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
        const int NUMBER_CHECKPOINT = 8;
        const int VALIDATE_ALL_CHECKPOINTS_POINTS = 3;

        private readonly IRepositoryWrapper repository;

        public async Task AddPointsValidateCheckPoint(int id)
        {

            await repository.Contexte.CheckAndUpdateStreak(id);

            int streak = await repository.Contexte.getSteak();

            await repository.Ranking.AddPointAsync(id, CHECKPOINT_POINT * streak);

            int checkpointCount = await repository.UserValidatedCheckpoints.getUserValidatedCheckpointsCount(id);

            if (checkpointCount == NUMBER_CHECKPOINT)
            {
                await repository.Ranking.AddPointAsync(id, VALIDATE_ALL_CHECKPOINTS_POINTS);
            }

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
