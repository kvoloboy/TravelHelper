using Autofac;
using TravelHelper.DataAccess.Factories.Interfaces;
using TravelHelper.Domain.Abstractions;
using TravelHelper.Domain.Models;

namespace TravelHelper.DataAccess.Factories
{
    public class RepositoryFactory : IRepositoryFactory
    {
        private readonly ILifetimeScope _lifetimeScope;

        public RepositoryFactory(ILifetimeScope lifetimeScope)
        {
            _lifetimeScope = lifetimeScope;
        }

        public IRepository<TEntity> Create<TEntity>() where TEntity : BaseEntity
        {
            var repository = _lifetimeScope.Resolve<IRepository<TEntity>>();

            return repository;
        }
    }
}
