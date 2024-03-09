namespace R5._08.Project.Database.Interface
{
    public interface IUnitOfWork
    {
        IScoreboardRepository ScoreboardRepository { get; }
        int Save();
    }
}
