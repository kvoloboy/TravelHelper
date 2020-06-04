using Autofac;
using TravelHelper.Web.Factories;
using TravelHelper.Web.Factories.Interfaces;
using TravelHelper.Web.Models.Tours.Filters;

namespace TravelHelper.Web
{
    public class WebModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<FilterViewModelFactory>()
                .As<IViewModelFactory<FilterSelectedOptionsViewModel, FilterViewModel>>()
                .InstancePerLifetimeScope();
        }
    }
}
