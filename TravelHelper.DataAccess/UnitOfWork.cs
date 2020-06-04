using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TravelHelper.DataAccess.Context;
using TravelHelper.DataAccess.Factories.Interfaces;
using TravelHelper.Domain.Abstractions;
using TravelHelper.Domain.Models;

namespace TravelHelper.DataAccess
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly TravelHelperDbContext _dbContext;
        private readonly IRepositoryFactory _repositoryFactory;

        public UnitOfWork(TravelHelperDbContext dbContext, IRepositoryFactory repositoryFactory)
        {
            _dbContext = dbContext;
            _repositoryFactory = repositoryFactory;
        }

        public IRepository<TEntity> GetRepository<TEntity>() where TEntity : BaseEntity
        {
            var repository = _repositoryFactory.Create<TEntity>();

            return repository;
        }

        public IReadonlyRepository<TEntity> GetReadonlyRepository<TEntity>() where TEntity : BaseEntity
        {
            var repository = _repositoryFactory.Create<TEntity>();

            return repository;
        }

        public async Task CommitAsync()
        {
            await _dbContext.SaveChangesAsync();
        }
    }
}
