using System;
using System.Linq.Expressions;
using BusinessLayer.Utils.Extensions.Expressions;
using BusinessLayer.Utils.Filter.Pipeline.Nodes.Interfaces;
using TravelHelper.Domain.Models;

namespace BusinessLayer.Utils.Filter.Pipeline.Nodes
{
    public class NamePipelineNode: IPipelineNode<Expression<Func<Tour, bool>>>
    {
        private readonly string _tourName;

        public NamePipelineNode(string tourName)
        {
            _tourName = tourName;
        }

        public Expression<Func<Tour, bool>> Execute(Expression<Func<Tour, bool>> input)
        {
            if (string.IsNullOrEmpty(_tourName))
            {
                return input;
            }

            Expression<Func<Tour, bool>> filter = tour => tour.Name.Contains(_tourName);

            return input.And(filter);
        }
    }
}
