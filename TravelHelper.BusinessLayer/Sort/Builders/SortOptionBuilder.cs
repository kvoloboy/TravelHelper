using Autofac;
using BusinessLayer.Sort.Builders.Interfaces;
using BusinessLayer.Sort.Options.Interfaces;
using TravelHelper.Domain.Models;

namespace BusinessLayer.Sort.Builders
{
    public class SortOptionBuilder : ISortOptionBuilder
    {
        private readonly ILifetimeScope _lifetimeScope;

        public SortOptionBuilder(ILifetimeScope lifetimeScope)
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
