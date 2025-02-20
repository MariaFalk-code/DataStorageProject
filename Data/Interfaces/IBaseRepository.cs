using System.Linq.Expressions;

namespace Data.Interfaces
{
    public interface IBaseRepository<TEntity> where TEntity : class
    {
        Task<TEntity> CreateAsync(TEntity entity);
        Task<bool> DeleteAsync(Expression<Func<TEntity, bool>> expression);
        Task<bool> ExistsAsync(Expression<Func<TEntity, bool>> expression);
        Task<List<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>> expression);
        Task<TEntity?> GetAsync(Expression<Func<TEntity, bool>> expression);
        Task<TEntity> UpdateAsync(TEntity entity);
    }
}