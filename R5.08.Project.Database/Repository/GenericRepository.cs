using Microsoft.EntityFrameworkCore;
using R5._08.Project.Database.Interface;

namespace R5._08.Project.Database.Repository
{
    /// <summary>
    /// Generic repository for each entity of the DbContext
    /// </summary>
    /// <typeparam name="T">Entity of type <see cref="IEntity"/></typeparam>
    internal class GenericRepository<T> where T : class, IEntity
    {
        protected readonly DbContext m_DbContext;
        protected readonly DbSet<T> m_DbSet;

        public GenericRepository(DbContext p_DbContext)
        {
            m_DbContext = p_DbContext ?? throw new ArgumentNullException(nameof(p_DbContext), "DbContext cannot be null");
            m_DbSet = m_DbContext.Set<T>();
        }
    }
}
