using System.Collections.Generic;
using System.Threading.Tasks;

namespace MyApp.Repositories
{
    public interface IGenericRepository<TKey, TEntity>
    {
        Task<TEntity> CreateAsync(TEntity entity);
        Task<TEntity> UpdateAsync(TEntity entity);
        Task<IReadOnlyList<TDto>> SearchAsync<TDto, TParam>(TParam parameter);
        Task<TEntity> GetByIdAsync(TKey id);
        Task<int> CountAsync<TParam>(TParam param);
        Task DeleteAsync(TEntity entity);
    }
}