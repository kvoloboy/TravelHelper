using System;
using System.Linq.Expressions;
using BusinessLayer.Shared.Extensions.Expressions;
using BusinessLayer.Shared.Filter.Pipeline.Nodes.Interfaces;
using TravelHelper.Domain.Models;

namespace BusinessLayer.Shared.Filter.Pipeline.Nodes
{
    public class DestinationPointPipelineNode : IPipelineNode<Expression<Func<Tour, bool>>>
    {
        private readonly int _destinationPoint;

        public DestinationPointPipelineNode(int destinationPoint)
        {
            _destinationPoint = destinationPoint;
        }

        public Expression<Func<Tour, bool>> Execute(Expression<Func<Tour, bool>> input)
        {
            if (_destinationPoint == default)
            {
                return input;
            }

            Expression<Func<Tour, bool>> filter = tour => tour.DestinationPointId == _destinationPoint;

            return input.And(filter);
        }
    }
}
