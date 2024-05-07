using System.Linq.Expressions;

namespace Trello.Api.Repositories
{
    public interface IAsyncRepository<TEntity> 
        where TEntity : class
        
    {
        Task<TEntity?> GetAsync(
            Expression<Func<TEntity, bool>> predicate,
            CancellationToken cancellationToken = default);

        Task<List<TEntity>> GetAllAsync(
            Expression<Func<TEntity, bool>> predicate = null,
            CancellationToken cancellationToken = default);

        Task<TEntity> AddAsync(
            TEntity entity, 
            CancellationToken cancellationToken = default);
        Task<TEntity> UpdateAsync(
            TEntity entity, 
            CancellationToken cancellationToken = default);
        Task<TEntity> DeleteAsync(
            TEntity entity, 
            CancellationToken cancellationToken = default);
    }
}
