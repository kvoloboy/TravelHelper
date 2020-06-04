using Autofac;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using TravelHelper.DataAccess.Context;
using TravelHelper.DataAccess.Factories;
using TravelHelper.DataAccess.Factories.Interfaces;
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
            builder.RegisterType<UnitOfWork>()
                .As<IUnitOfWork>()
                .InstancePerLifetimeScope();

            builder.RegisterType<RepositoryFactory>()
                .As<IRepositoryFactory>()
                .InstancePerLifetimeScope();

            builder.Register(c =>
                {
                    var config = c.Resolve<IConfiguration>();
                    var connectionString = config["ConnectionStrings:TravelHelperDbContext"];
                    var optionBuilder = new DbContextOptionsBuilder<TravelHelperDbContext>();
                    optionBuilder.UseSqlServer(connectionString);

                    return new TravelHelperDbContext(optionBuilder.Options);
                })
                .AsSelf()
                .As<DbContext>()
                .InstancePerLifetimeScope();

            builder
            .RegisterAssemblyTypes(typeof(DataAccessModule).Assembly)
            .Where(t => t.IsClosedTypeOf(typeof(IReadonlyRepository<>)))
            .AsImplementedInterfaces();

            builder
                .RegisterAssemblyTypes(typeof(DataAccessModule).Assembly)
                .Where(t => t.IsClosedTypeOf(typeof(IRepository<>)))
                .AsImplementedInterfaces();
        }
    }
}
