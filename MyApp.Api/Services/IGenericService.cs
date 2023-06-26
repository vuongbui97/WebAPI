using MyApp.DTOs.Common;
using System.Threading.Tasks;

namespace MyApp.Services
{
    public interface IGenericService<TKey>
    {
        Task<Pageable<TDto>> SearchAsync<TDto, TQuery>(TQuery query) where TDto : class where TQuery : BaseQuery;
        Task<TDto> GetByIdAsync<TDto>(TKey id);
        Task<TDto> CreateAsync<TDto, TCreate>(TCreate command);
        Task DeleteAsync(TKey id);
        Task<TDto> UpdateAsync<TDto, TUpdate>(TUpdate command) where TUpdate : class;
    }
}