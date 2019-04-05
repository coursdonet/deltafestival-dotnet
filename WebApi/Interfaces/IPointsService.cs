using System.Threading.Tasks;

namespace WebApi.Interfaces
{
    public interface IPointsService
    {
        Task AddPointsValidateCheckPoint(int id);
        Task RemovePointsNotValidateCheckPoint(int id);
        Task AddPointAsync(int id, int point);
        Task RemovePointAsync(int id, int point);

    }
}
