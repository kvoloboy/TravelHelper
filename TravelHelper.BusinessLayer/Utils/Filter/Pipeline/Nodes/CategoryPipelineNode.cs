using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using BusinessLayer.Utils.Extensions.Expressions;
using BusinessLayer.Utils.Filter.Pipeline.Nodes.Interfaces;
using TravelHelper.Domain.Models;

namespace BusinessLayer.Utils.Filter.Pipeline.Nodes
{
    public class CategoryPipelineNode : IPipelineNode<Expression<Func<Tour, bool>>>
    {
        private readonly IEnumerable<int> _categories;

        public CategoryPipelineNode(IEnumerable<int> categories)
        {
            _categories = categories;
        }

        public Expression<Func<Tour, bool>> Execute(Expression<Func<Tour, bool>> input)
        {
            if (_categories == null || !_categories.Any())
            {
                return input;
            }

            Expression<Func<Tour, bool>> filter = tour => _categories.Contains(tour.CategoryId);

            return input.And(filter);
        }
    }
}
