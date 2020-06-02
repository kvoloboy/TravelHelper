using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TravelHelper.Domain.Abstractions;
using TravelHelper.Domain.Models;

namespace TravelHelper.DataAccess.Repositories
{
    public abstract class GenericRepository<TEntity> : IRepository<TEntity> where TEntity: BaseEntity
    {
        private readonly DbContext _dbContext;
        private readonly DbSet<TEntity> _entityDbSet;

        protected GenericRepository(DbContext dbContext)
        {
            _dbContext = dbContext;
            _entityDbSet = _dbContext.Set<TEntity>();
        }

        public abstract Task<TEntity> FindSingleAsync(Expression<Func<TEntity, bool>> predicate);

        public abstract Task<List<TEntity>> FindAllAsync(
            Expression<Func<TEntity, bool>> predicate = null,
            int? skip = null,
            int? take = null);

        public Task<bool> AnyAsync(Expression<Func<TEntity, bool>> predicate)
        {
            var any = _entityDbSet.AnyAsync(predicate);

            return any;
        }

        public virtual async Task<int> AddAsync(TEntity item)
        {
            _entityDbSet.Attach(item);
            await _entityDbSet.AddAsync(item);

            return item.Id;
        }

        public virtual async Task UpdateAsync(TEntity item)
        {
            var existingEntity = await FindSingleAsync(e => e.Id == item.Id);
            _dbContext.Entry(existingEntity).CurrentValues.SetValues(item);
        }

        public virtual async Task DeleteAsync(int id)
        {
            var existingEntity = await FindSingleAsync(e => e.Id == id);
            _entityDbSet.Remove(existingEntity);
        }
    }
}
