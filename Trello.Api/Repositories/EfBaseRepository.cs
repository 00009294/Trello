using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using Trello.Infrastructure.DataContext;

namespace Trello.Api.Repositories
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
            await this.context.AddAsync(entity, cancellationToken);
            await this.context.SaveChangesAsync();

            return entity;
        }

        public async Task<TEntity> DeleteAsync(TEntity entity, 
            CancellationToken cancellationToken = default)
        {
            this.context.Remove(entity);
            await this.context.SaveChangesAsync();

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
            this.context.Update(entity);
            await this.context.SaveChangesAsync(cancellationToken);

            return entity;
        
        }

        private IQueryable<TEntity> Query()
        {
            return this.context.Set<TEntity>();
        }
    }
}
