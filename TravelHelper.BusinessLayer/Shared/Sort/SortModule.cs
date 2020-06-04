using Autofac;
using BusinessLayer.Shared.Constants;
using BusinessLayer.Shared.Sort.Builders;
using BusinessLayer.Shared.Sort.Builders.Interfaces;
using BusinessLayer.Shared.Sort.Options;
using BusinessLayer.Shared.Sort.Options.Interfaces;
using TravelHelper.Domain.Models;

namespace BusinessLayer.Shared.Sort
{
    public class SortModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<SortOptionFactory>()
                .As<ISortOptionFactory>()
                .SingleInstance();

            builder.RegisterType<MostVisitedSortOption>()
                .Named<ISortOption<Tour>>(SortOptions.MostVisited)
                .SingleInstance();

            builder.RegisterType<NameAscendingSortOption>()
                .Named<ISortOption<Tour>>(SortOptions.NameAsc)
                .SingleInstance();

            builder.RegisterType<NameDescendingSortOption>()
                .Named<ISortOption<Tour>>(SortOptions.NameDesc)
                .SingleInstance();

            builder.RegisterType<PriceAscendingSortOption>()
                .Named<ISortOption<Tour>>(SortOptions.PriceAsc)
                .SingleInstance();

            builder.RegisterType<PriceDescendingSortOption>()
                .Named<ISortOption<Tour>>(SortOptions.PriceDesc)
                .SingleInstance();
        }
    }
}
