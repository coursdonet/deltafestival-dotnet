using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebApi.Interfaces;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApi.Services
{
    [Controller]
    public class PointsService : ControllerBase
    {
        const int CHECKPOINT_POINT = 2;
        const int CHAT_POINT = 1;
        const int HEARTH_STROKE_POINT = 1;
        const int NUMBER_CHECKPOINT = 8;
        const int VALIDATE_ALL_CHECKPOINTS_POINTS = 3;

        private readonly IRepositoryWrapper repository;

        public PointsService(IRepositoryWrapper repository)
        {
            this.repository = repository;
        }

        public async Task AddPointsValidateCheckPoint(int id)
        {

            await repository.Contexte.CheckAndUpdateStreakAsync(id);

            int streak = await repository.Contexte.getSteakAsync();

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
            await repository.Ranking.AddPointAsync(id, CHAT_POINT);
        }

        public async Task AddPointsHearthStrokeChat(int id)
        {
            await repository.Ranking.AddPointAsync(id, HEARTH_STROKE_POINT);

        }
    }
}
