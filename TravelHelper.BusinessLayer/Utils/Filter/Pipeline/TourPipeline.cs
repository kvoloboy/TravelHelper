using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using BusinessLayer.Utils.Filter.Pipeline.Interfaces;
using BusinessLayer.Utils.Filter.Pipeline.Nodes.Interfaces;
using TravelHelper.Domain.Models;

namespace BusinessLayer.Utils.Filter.Pipeline
{
    public class TourExpressionPipeline : IPipeline<Expression<Func<Tour, bool>>>
    {
        private readonly IEnumerable<IPipelineNode<Expression<Func<Tour, bool>>>> _pipelineNodes;

        public TourExpressionPipeline(IEnumerable<IPipelineNode<Expression<Func<Tour, bool>>>> pipelineNodes)
        {
            _pipelineNodes = pipelineNodes;
        }

        public Expression<Func<Tour, bool>> Execute()
        {
            var expression = _pipelineNodes
                .Aggregate<IPipelineNode<Expression<Func<Tour, bool>>>, Expression<Func<Tour, bool>>>
                    (tour => true, (current, node) => node.Execute(current));

            return expression;
        }
    }
}
