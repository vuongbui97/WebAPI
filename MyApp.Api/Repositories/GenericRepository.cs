using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using MyApp.Entities;

namespace MyApp.Repositories
{
    public class GenericRepository<TKey, TEntity> : IGenericRepository<TKey, TEntity> where TEntity : class
    {
        private readonly IMapper _mapper;
        private readonly MyDbContext _dbContext;

        protected GenericRepository(IMapper mapper, MyDbContext myDbContext)
        {
            _mapper = mapper;
            _dbContext = myDbContext;
        }
        public virtual  async Task<TEntity> CreateAsync(TEntity entity)
        {
            _dbContext.Set<TEntity>().Add(entity);
            await _dbContext.SaveChangesAsync();
            return entity;
        }

        public virtual async  Task<TEntity> UpdateAsync(TEntity entity)
        {
            _dbContext.Set<TEntity>().Update(entity);
            await _dbContext.SaveChangesAsync();
            return entity;
        }

        public virtual async Task<IReadOnlyList<TDto>> SearchAsync<TDto, TParam>(TParam parameter)
        {
            return await _dbContext.Set<Product>().ProjectTo<TDto>(_mapper.ConfigurationProvider)
                .ToListAsync()
                .ConfigureAwait(false);
        }

        public virtual async Task<TEntity> GetByIdAsync(TKey id)
        {
            var entity = await _dbContext.Set<TEntity>().FindAsync(id).ConfigureAwait(false);
            if (entity == null) throw new NullReferenceException();
            return entity;
        }

        public virtual async Task<int> CountAsync<TParam>(TParam param)
        {
            return await _dbContext.Set<TEntity>().CountAsync().ConfigureAwait(false);
        }

        public virtual async Task DeleteAsync(TEntity entity)
        {
            if (entity == null) throw new NullReferenceException();
            _dbContext.Set<TEntity>().Remove(entity);
            await _dbContext.SaveChangesAsync();
        }
    }
}