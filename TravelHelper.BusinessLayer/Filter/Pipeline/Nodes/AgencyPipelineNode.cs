using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using BusinessLayer.Extensions.Expressions;
using BusinessLayer.Filter.Pipeline.Nodes.Interfaces;
using TravelHelper.Domain.Models;

namespace BusinessLayer.Filter.Pipeline.Nodes
{
    public class AgencyPipelineNode : IPipelineNode<Expression<Func<Tour, bool>>>
    {
        private readonly IEnumerable<int> _agencies;

        public AgencyPipelineNode(IEnumerable<int> agencies)
        {
            _agencies = agencies;
        }

        public Expression<Func<Tour, bool>> Execute(Expression<Func<Tour, bool>> input)
        {
            if (_agencies == null || !_agencies.Any())
            {
                return input;
            }

            Expression<Func<Tour, bool>> filter = tour => _agencies.Contains(tour.AgencyId);

            return input.And(filter);
        }
    }
}
