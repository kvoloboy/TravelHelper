using Autofac;
using TravelHelper.DataAccess.Repositories;
using TravelHelper.Domain.Abstractions;
using TravelHelper.Domain.Models;
using TravelHelper.Domain.Models.Identity;

namespace TravelHelper.DataAccess
{
    public class DataAccessModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<PermissionsReadonlyRepository>()
                .As<IReadonlyRepository<Permission>>()
                .InstancePerLifetimeScope();

            builder.RegisterType<AgencyRepository>()
                .As<IRepository<Agency>>()
                .InstancePerLifetimeScope();

            // builder.RegisterType(typeof(IRepository<>))
            // .AsImplementedInterfaces()
            // .InstancePerLifetimeScope();
            //
            // builder.RegisterType(typeof(GenericRepository<>))
            //     .AsSelf()
            //     .AsImplementedInterfaces()
            //     .InstancePerLifetimeScope();
        }
    }
}
