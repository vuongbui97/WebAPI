using System;
using MyApp.DTOs.Common;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using MyApp.Repositories;

namespace MyApp.Services
{
    public class GenericService<TKey, TEntity> : IGenericService<TKey>
    {
        private readonly IMapper _mapper;
        private readonly IGenericRepository<TKey, TEntity> _repository;

        public GenericService(IMapper mapper, IGenericRepository<TKey, TEntity> repository)
        {
            _mapper = mapper;
            _repository = repository;
        }
        
        public virtual async Task<Pageable<TDto>> SearchAsync<TDto, TQuery>(TQuery query) where TDto : class where TQuery : BaseQuery
        {
            if (query is null) throw new ArgumentNullException(nameof(query));
            var data = await _repository.SearchAsync<TDto, TQuery>(query).ConfigureAwait(false);

            var totalItem = await _repository.CountAsync(query).ConfigureAwait(false);

            return new Pageable<TDto>(data, totalItem, query.PageSize)
            {
                PageSize = query.PageSize,
                PageIndex = query.PageIndex
            };
        }

        public virtual async Task<TDto> GetByIdAsync<TDto>(TKey id)
        {
            var data = await _repository.GetByIdAsync(id).ConfigureAwait(false);
            if (data == null) throw new BadHttpRequestException("BadRequestException");
            return _mapper.Map<TDto>(data);
        }

        public virtual async Task<TDto> CreateAsync<TDto, TCreate>(TCreate command)
        {
            if (command == null) throw new ArgumentNullException(nameof(command));
            var entity = _mapper.Map<TEntity>(command);
            await  _repository.CreateAsync(entity);
            return _mapper.Map<TDto>(entity);
        }

        public virtual async Task DeleteAsync(TKey id)
        {
            var entity = await _repository.GetByIdAsync(id);
            if (entity == null) throw new Exception("Not found!");
            await _repository.DeleteAsync(entity);
        }

        public virtual async Task<TDto> UpdateAsync<TDto, TUpdate>(TUpdate command) where TUpdate : class
        {
            if (command == null) throw new ArgumentNullException(nameof(command));
            var entity = _mapper.Map<TEntity>(command);
            await _repository.UpdateAsync(entity);
            return _mapper.Map<TDto>(entity);
        }
    }
}