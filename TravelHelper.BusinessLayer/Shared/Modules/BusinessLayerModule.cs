using System.Collections.Generic;
using Autofac;
using BusinessLayer.Shared.Filter;
using BusinessLayer.Shared.Sort;
using BusinessLayer.Shared.Validators;
using BusinessLayer.TourManagement.DTO;
using BusinessLayer.TourManagement.Queries;
using MediatR;

namespace BusinessLayer.Shared.Modules
{
    public class BusinessLayerModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<Mediator>()
                .As<IMediator>()
                .InstancePerLifetimeScope();

            builder.Register<ServiceFactory>(context =>
            {
                var c = context.Resolve<IComponentContext>();
                return t => c.Resolve(t);
            });

            builder.RegisterType<GetHotToursQueryHandler>()
                .As<IRequestHandler<GetHotToursQuery, List<TourDto>>>()
                .InstancePerLifetimeScope();

            builder.RegisterModule(new SortModule());
            builder.RegisterModule(new FilterModule());
            builder.RegisterModule(new ValidatorsModule());

            builder
                .RegisterAssemblyTypes(typeof(BusinessLayerModule).Assembly)
                .Where(t => t.IsClosedTypeOf(typeof(IRequest<>)))
                .AsImplementedInterfaces();

            builder
                .RegisterAssemblyTypes(typeof(BusinessLayerModule).Assembly)
                .Where(t => t.IsClosedTypeOf(typeof(IRequestHandler<>)))
                .AsImplementedInterfaces();

            builder
                .RegisterAssemblyTypes(typeof(BusinessLayerModule).Assembly)
                .Where(t => t.IsClosedTypeOf(typeof(IRequestHandler<,>)))
                .AsImplementedInterfaces();
        }
    }
}
