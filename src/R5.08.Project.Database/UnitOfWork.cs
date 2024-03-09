using LinqKit;
using Microsoft.EntityFrameworkCore;
using R5._08.Project.Database.Interface;
using R5._08.Project.Database.Repository;

namespace R5._08.Project.Database
{
    public class UnitOfWork<T> : IUnitOfWork where T : DbContext
    {
        private readonly T m_DbContext;
        private readonly IScoreboardRepository m_ScoreboardRepository;

        public UnitOfWork(T p_DbContext)
        {
            m_DbContext = p_DbContext ?? throw new ArgumentNullException(nameof(p_DbContext));

            m_ScoreboardRepository = new ScoreboardRepository(m_DbContext);
        }
        public IScoreboardRepository ScoreboardRepository => m_ScoreboardRepository;

        public int Save()
        {
            m_DbContext?.ChangeTracker?.Entries().Where(p_E => p_E.State == EntityState.Unchanged).ForEach(p_E => p_E.State = EntityState.Detached);
            return m_DbContext?.SaveChanges() ?? 0;
        }
    }
}
