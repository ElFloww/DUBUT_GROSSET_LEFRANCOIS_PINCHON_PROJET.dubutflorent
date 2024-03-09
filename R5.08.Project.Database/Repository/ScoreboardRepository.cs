using Microsoft.EntityFrameworkCore;
using R5._08.Project.Database.Entities;
using R5._08.Project.Database.Interface;

namespace R5._08.Project.Database.Repository
{
    internal class ScoreboardRepository : GenericRepository<Scoreboard>, IScoreboardRepository
    {
        public ScoreboardRepository(DbContext p_DbContext) : base(p_DbContext)
        {
        }

        public Task<IEnumerable<Scoreboard>> GetAllScoreboards()
        {

            return Task.FromResult(m_DbSet.AsEnumerable());
        }

        public Task<Scoreboard?> GetScoreboardById(int p_Id)
        {
            return Task.FromResult(m_DbSet.FirstOrDefault(p_Query => p_Query.Id == p_Id));
        }

        public Task<Scoreboard?> GetScoreboardByName(string p_Name)
        {
            return Task.FromResult(m_DbSet.FirstOrDefault(p_Query => p_Query.Name == p_Name));
        }

        public async Task AddScoreboards(Scoreboard p_Scoreboard)
        {
            if (p_Scoreboard == null)
            {
                throw new ArgumentNullException(nameof(p_Scoreboard), "Scoreboard cannot be null or empty");
            }
            await m_DbSet.AddAsync(p_Scoreboard);
        }

        public Task UpdateScoreboards(Scoreboard p_Scoreboard)
        {
            if (((int)m_DbContext.Entry(p_Scoreboard).State) < 2)
                m_DbContext.Entry(p_Scoreboard).State = EntityState.Modified;
            m_DbSet.Update(p_Scoreboard);
            return Task.CompletedTask;
        }
    }
}
