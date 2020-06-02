using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using BusinessLayer.Filter.Builders.Interfaces;
using BusinessLayer.Filter.Pipeline;
using BusinessLayer.Filter.Pipeline.Interfaces;
using BusinessLayer.Filter.Pipeline.Nodes.Interfaces;
using TravelHelper.Domain.Models;

namespace BusinessLayer.Filter.Builders
{
    public class ExpressionPipelineBuilder : IPipelineBuilder<Expression<Func<Tour, bool>>>
    {
        private readonly List<IPipelineNode<Expression<Func<Tour, bool>>>> _expressions =
            new List<IPipelineNode<Expression<Func<Tour, bool>>>>();

        public IPipelineBuilder<Expression<Func<Tour, bool>>> WithNode(IPipelineNode<Expression<Func<Tour, bool>>> node)
        {
            _expressions.Add(node);

            return this;
        }

        public IPipeline<Expression<Func<Tour, bool>>> Execute()
        {
            var pipeline = new TourExpressionPipeline(_expressions);

            return pipeline;
        }
    }
}
