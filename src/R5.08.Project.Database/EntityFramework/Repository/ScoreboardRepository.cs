using Microsoft.EntityFrameworkCore;
using R5._08.Project.Database.Entities;
using R5._08.Project.Database.Interface;

namespace R5._08.Project.Database.EntityFramework.Repository
{
    internal class ScoreboardRepository : GenericRepository<Scoreboard>, IScoreboardRepository
    {
        public ScoreboardRepository(DbContext p_DbContext) : base(p_DbContext)
        {
        }

        public Task<IEnumerable<Scoreboard>> GetAllScoreboards()
        {
            return GetAllAsync();
        }

        public Task<Scoreboard?> GetScoreboardById(int p_Id)
        {
            Scoreboard? v_Entity = FindBy(p_P => p_P.Id == p_Id).FirstOrDefault();
            return Task.FromResult(v_Entity);
        }

        public Task<Scoreboard?> GetScoreboardByName(string p_Name)
        {
            Scoreboard? v_Entity = FindBy(p_P => p_P.Name == p_Name).FirstOrDefault();
            return Task.FromResult(v_Entity);
        }

        public async Task AddScoreboards(Scoreboard p_Scoreboard)
        {
            await AddAsync(p_Scoreboard);
        }

        public async Task UpdateScoreboards(Scoreboard p_Scoreboard)
        {
            await UpdateAsync(p_Scoreboard);
        }
    }
}
