namespace WebApi.Interfaces
{
    public interface IRepositoryWrapper
    {
        IUserRepository User { get; }
        ITeamRepository Team { get; }
        IRankingRepository Ranking { get; }
        IUserValidatedCheckpointsRepository UserValidatedCheckpoints { get; }
        IContexteRepository Contexte { get; }
        IPreventionRepository Prevention { get; }
    }
}
