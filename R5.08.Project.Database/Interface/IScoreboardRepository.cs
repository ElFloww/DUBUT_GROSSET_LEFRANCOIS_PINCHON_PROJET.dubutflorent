using R5._08.Project.Database.Entities;

namespace R5._08.Project.Database.Interface
{
    public interface IScoreboardRepository
    {
        Task<IEnumerable<Scoreboard>> GetAllScoreboards();

        Task<Scoreboard?> GetScoreboardById(int p_Id);

        Task<Scoreboard?> GetScoreboardByName(string p_Name);

        Task AddScoreboards(Scoreboard p_Scoreboard);

        Task UpdateScoreboards(Scoreboard p_Scoreboard);
    }
}
