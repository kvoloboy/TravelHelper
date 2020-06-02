using System;
using System.Linq.Expressions;
using BusinessLayer.Utils.Extensions.Expressions;
using BusinessLayer.Utils.Filter.Pipeline.Nodes.Interfaces;
using TravelHelper.Domain.Models;

namespace BusinessLayer.Utils.Filter.Pipeline.Nodes
{
    public class PriceRangePipelineNode : IPipelineNode<Expression<Func<Tour, bool>>>
    {
        private readonly int _minPrice;
        private readonly int _maxPrice;

        public PriceRangePipelineNode(int minPrice, int maxPrice)
        {
            _minPrice = minPrice;
            _maxPrice = maxPrice;
        }

        public Expression<Func<Tour, bool>> Execute(Expression<Func<Tour, bool>> input)
        {
            var areNotAssigned = _minPrice == 0 && _maxPrice == 0;

            if (areNotAssigned)
            {
                return input;
            }

            Expression<Func<Tour, bool>> filter = tour =>
                tour.PricePerDay >= _minPrice && tour.PricePerDay <= _maxPrice;

            return input.And(filter);
        }
    }
}
