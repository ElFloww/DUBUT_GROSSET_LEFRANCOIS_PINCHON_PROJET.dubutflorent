using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using R5._08.Project.Database.Interface;
using System.Linq.Expressions;
using System.Linq;

namespace R5._08.Project.Database.EntityFramework.Repository
{
    /// <summary>
    /// Generic repository for each entity of the DbContext
    /// </summary>
    /// <typeparam name="T">Entity of type <see cref="IEntity"/></typeparam>
    internal class GenericRepository<T> : IGenericRepository<T> where T : class, IEntity
    {
        protected readonly DbContext m_DbContext;
        protected readonly DbSet<T> m_DbSet;

        public GenericRepository(DbContext p_DbContext)
        {
            m_DbContext = p_DbContext ?? throw new ArgumentNullException(nameof(p_DbContext), "DbContext cannot be null");
            m_DbSet = m_DbContext.Set<T>();
        }

        /// <summary>
        /// Get the current <see cref="DbContext"/>
        /// </summary>
        public DbContext DbContext => m_DbContext;

        public async Task AddAsync(T p_Entity, CancellationToken p_CancellationToken = default)
        {
            if (p_Entity == null)
                throw new ArgumentNullException(nameof(p_Entity), "Entity cannot be null");

            await m_DbSet.AddAsync(p_Entity, p_CancellationToken);
        }

        public async Task AddAsync(IEnumerable<T> p_Entities, CancellationToken p_CancellationToken = default)
        {
            if (p_Entities?.Any() != true)
                throw new ArgumentNullException(nameof(p_Entities), "Entity cannot be null or empty");

            await m_DbSet.AddRangeAsync(p_Entities, p_CancellationToken);
        }

        public async Task DeleteByIdAsync(object p_Id, CancellationToken p_CancellationToken = default)
        {
            if (p_Id == null)
                throw new ArgumentNullException(nameof(p_Id), "Id cannot be null");

            T? v_Entity = await m_DbSet.FindAsync(new[] { p_Id }, cancellationToken: p_CancellationToken);
            if (v_Entity != null) await DeleteAsync(v_Entity);
        }

        public Task DeleteAsync(T p_Entity)
        {
            if (p_Entity == null)
                throw new ArgumentNullException(nameof(p_Entity), "Entity cannot be null");

            if (m_DbContext.Entry(p_Entity).State == EntityState.Detached)
            {
                m_DbSet.Attach(p_Entity);
            }
            m_DbSet.Remove(p_Entity);
            return Task.CompletedTask;
        }

        public Task DeleteAsync(IEnumerable<T> p_Entities)
        {
            if (p_Entities == null)
                throw new ArgumentNullException(nameof(p_Entities), "Entity cannot be null");

            m_DbSet.RemoveRange(p_Entities);
            return Task.CompletedTask;
        }

        public IQueryable<T> FindBy(Expression<Func<T, bool>>? p_Predicate, Func<IQueryable<T>, IOrderedQueryable<T>>? p_OrderBy = null, Func<IQueryable<T>, IIncludableQueryable<T, object>>? p_Include = null, int? p_Skip = null, int? p_Take = null, bool p_DisableTracking = true)
        {
            IQueryable<T> p_Query = m_DbSet;
            if (p_DisableTracking)
                p_Query = p_Query.AsNoTracking();

            if (p_Include != null)
                p_Query = p_Include(p_Query);

            if (p_Predicate != null)
                p_Query = p_Query.Where(p_Predicate);

            if (p_OrderBy != null)
                p_Query = p_OrderBy(p_Query);

            if (p_Skip.HasValue)
                p_Query = p_Query.Skip(p_Skip.Value);

            if (p_Take.HasValue)
                p_Query = p_Query.Take(p_Take.Value);

            return p_Query;
        }

        public Task<IEnumerable<T>> GetAllAsync(Func<IQueryable<T>, IIncludableQueryable<T, object>>? p_Include = null, Func<IQueryable<T>, IOrderedQueryable<T>>? p_OrderBy = null, int? p_Skip = null, int? p_Take = null, bool p_DisableTracking = true, CancellationToken p_CancellationToken = default)
        {
            return Task.FromResult(FindBy(null, p_OrderBy, p_Include, p_Skip, p_Take, p_DisableTracking).AsEnumerable());
        }

        public async Task<T?> GetAsync(object p_Id, CancellationToken p_CancellationToken = default)
        {
            if (p_Id == null)
                throw new ArgumentNullException(nameof(p_Id), "Id cannot be null");

            return await m_DbSet.FindAsync(new[] { p_Id }, cancellationToken: p_CancellationToken);
        }

        public Task UpdateAsync(T p_Entity)
        {
            if (p_Entity == null)
                throw new ArgumentNullException(nameof(p_Entity), "Entity cannot be null");

            if ((int)m_DbContext.Entry(p_Entity).State < 2)
                m_DbContext.Entry(p_Entity).State = EntityState.Modified;
            m_DbSet.Update(p_Entity);
            return Task.CompletedTask;
        }

        public Task UpdateAsync(IEnumerable<T> p_Entities)
        {
            if (p_Entities?.Any() != true)
                throw new ArgumentNullException(nameof(p_Entities), "Entity cannot be null or empty");

            m_DbSet.UpdateRange(p_Entities);
            return Task.CompletedTask;
        }
        public void Dispose()
        {

        }
    }
}
