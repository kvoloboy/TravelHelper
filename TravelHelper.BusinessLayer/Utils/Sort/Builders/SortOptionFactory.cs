using Autofac;
using BusinessLayer.Utils.Sort.Builders.Interfaces;
using BusinessLayer.Utils.Sort.Options.Interfaces;
using TravelHelper.Domain.Models;

namespace BusinessLayer.Utils.Sort.Builders
{
    public class SortOptionFactory : ISortOptionFactory
    {
        private readonly ILifetimeScope _lifetimeScope;

        public SortOptionFactory(ILifetimeScope lifetimeScope)
        {
            _lifetimeScope = lifetimeScope;
        }

        public ISortOption<TEntity> Create<TEntity>(string sortTerm) where TEntity : BaseEntity
        {
            var option = _lifetimeScope.ResolveNamed<ISortOption<TEntity>>(sortTerm);

            return option;
        }
    }
}
