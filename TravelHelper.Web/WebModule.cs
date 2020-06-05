using Autofac;
using TravelHelper.Web.Factories;
using TravelHelper.Web.Factories.Interfaces;
using TravelHelper.Web.Models.Tours;
using TravelHelper.Web.Models.Tours.Filters;
using TravelHelper.Web.Services;
using TravelHelper.Web.Services.Interfaces;

namespace TravelHelper.Web
{
    public class WebModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<FilterViewModelFactory>()
                .As<IViewModelFactory<FilterSelectedOptionsViewModel, FilterViewModel>>()
                .InstancePerLifetimeScope();

            builder.RegisterType<ModifyTourViewModelFactory>()
                .As<IViewModelFactory<ModifyTourViewModel>>()
                .InstancePerLifetimeScope();

            builder.RegisterType<FileUploadService>()
                .As<IFileUploadService>()
                .InstancePerLifetimeScope();
        }
    }
}
