using System;
using System.Linq.Expressions;
using BusinessLayer.Shared.Extensions.Expressions;
using BusinessLayer.Shared.Filter.Pipeline.Nodes.Interfaces;
using TravelHelper.Domain.Models;

namespace BusinessLayer.Shared.Filter.Pipeline.Nodes
{
    public class SourcePointPipelineNode: IPipelineNode<Expression<Func<Tour, bool>>>
    {
        private readonly int _sourcePoint;

        public SourcePointPipelineNode(int sourcePoint)
        {
            _sourcePoint = sourcePoint;
        }

        public Expression<Func<Tour, bool>> Execute(Expression<Func<Tour, bool>> input)
        {
            if (_sourcePoint == default)
            {
                return input;
            }

            Expression<Func<Tour, bool>> filter = tour => tour.SourcePointId == _sourcePoint;

            return input.And(filter);
        }
    }
}
