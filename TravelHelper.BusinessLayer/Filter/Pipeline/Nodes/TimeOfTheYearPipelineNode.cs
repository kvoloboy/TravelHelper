using System;
using System.Linq.Expressions;
using BusinessLayer.Extensions.Expressions;
using BusinessLayer.Filter.Pipeline.Nodes.Interfaces;
using TravelHelper.Domain.Models;
using TravelHelper.Domain.Models.Enums;

namespace BusinessLayer.Filter.Pipeline.Nodes
{
    public class TimeOfTheYearPipelineNode: IPipelineNode<Expression<Func<Tour, bool>>>
    {
        private readonly TimeOfTheYear? _timeOfTheYear;

        public TimeOfTheYearPipelineNode(TimeOfTheYear? timeOfTheYear)
        {
            _timeOfTheYear = timeOfTheYear;
        }

        public Expression<Func<Tour, bool>> Execute(Expression<Func<Tour, bool>> input)
        {
            if (!_timeOfTheYear.HasValue)
            {
                return input;
            }

            Expression<Func<Tour, bool>> filter = tour => tour.TimeOfTheYear == _timeOfTheYear;

            return input.And(filter);
        }
    }
}
