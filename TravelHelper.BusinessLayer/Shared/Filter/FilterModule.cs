using System;
using System.Linq.Expressions;
using Autofac;
using BusinessLayer.Shared.Filter.Builders;
using BusinessLayer.Shared.Filter.Builders.Interfaces;
using BusinessLayer.Shared.Filter.Pipeline;
using BusinessLayer.Shared.Filter.Pipeline.Interfaces;
using BusinessLayer.Shared.Filter.Pipeline.Nodes.Interfaces;
using TravelHelper.Domain.Models;

namespace BusinessLayer.Shared.Filter
{
    public class FilterModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<TourExpressionPipelineBuilder>()
                .As<IPipelineBuilder<Expression<Func<Tour, bool>>>>()
                .InstancePerLifetimeScope();

            builder.RegisterType<TourExpressionPipeline>()
                .As<IPipeline<Expression<Func<Tour, bool>>>>()
                .InstancePerLifetimeScope();

            builder.RegisterType(typeof(IPipelineNode<>))
                .AsImplementedInterfaces()
                .InstancePerLifetimeScope();
        }
    }
}
