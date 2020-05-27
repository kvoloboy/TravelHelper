using Autofac;
using MediatR;
using System.Reflection;
using Module = Autofac.Module;

namespace BusinessLayer.Modules
{
    public class BusinessLayerModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<Mediator>()
                .As<IMediator>()
                .InstancePerLifetimeScope();

            builder.Register<ServiceFactory>(context => context.Resolve);
            builder.RegisterAssemblyTypes(typeof(BusinessLayerModule).GetTypeInfo().Assembly).AsImplementedInterfaces();
        }
    }
}
