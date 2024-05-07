using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using Trello.Infrastructure.DataContext;

namespace Trello.Api.Repositories.Persistence
{
    public class EfBaseRepository<TEntity, TContext> : IAsyncRepository<TEntity>
        where TEntity : class
        where TContext : DbContext
    {
        protected readonly TContext context;
        public EfBaseRepository(TContext context)
        {
            this.context = context;
        }

        public async Task<TEntity> AddAsync(TEntity entity,
            CancellationToken cancellationToken = default)
        {
            await context.AddAsync(entity, cancellationToken);
            await context.SaveChangesAsync();

            return entity;
        }

        public async Task<TEntity> DeleteAsync(TEntity entity,
            CancellationToken cancellationToken = default)
        {
            context.Remove(entity);
            await context.SaveChangesAsync();

            return entity;
        }

        public Task<List<TEntity>> GetAllAsync(
            Expression<Func<TEntity, bool>> predicate = null,
            CancellationToken cancellationToken = default)
        {
            IQueryable<TEntity> queryable = Query();

            return queryable.ToListAsync();
        }

        public async Task<TEntity?> GetAsync(Expression<Func<TEntity, bool>> predicate,
            CancellationToken cancellationToken = default)
        {
            IQueryable<TEntity> queryable = Query();

            return await queryable.FirstOrDefaultAsync(predicate, cancellationToken);
        }

        public async Task<TEntity> UpdateAsync(TEntity entity,
            CancellationToken cancellationToken = default)
        {
            context.Update(entity);
            await context.SaveChangesAsync(cancellationToken);

            return entity;

        }

        private IQueryable<TEntity> Query()
        {
            return context.Set<TEntity>();
        }
    }
}
