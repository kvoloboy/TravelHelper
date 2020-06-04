using System.Reflection;
using Autofac;
using BusinessLayer.Shared.Filter;
using BusinessLayer.Shared.Sort;
using BusinessLayer.Shared.Validators;
using MediatR;
using Module = Autofac.Module;

namespace BusinessLayer.Shared.Modules
{
    public class BusinessLayerModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<Mediator>()
                .As<IMediator>()
                .InstancePerLifetimeScope();

            builder.Register<ServiceFactory>(context => context.Resolve);

            // builder.Register<ServiceFactory>(context =>
            // {
            //     var c = context.Resolve<IComponentContext>();
            //     return t => c.Resolve(t);
            // });

            builder.RegisterAssemblyTypes(typeof(BusinessLayerModule).GetTypeInfo().Assembly)
                .AsImplementedInterfaces();

            builder.RegisterModule(new SortModule());
            builder.RegisterModule(new FilterModule());
            builder.RegisterModule(new ValidatorsModule());
        }
    }
}
