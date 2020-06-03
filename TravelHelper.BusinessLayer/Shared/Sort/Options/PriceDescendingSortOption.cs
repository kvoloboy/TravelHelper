using System;
using System.Linq.Expressions;
using BusinessLayer.Shared.Sort.Options.Interfaces;
using TravelHelper.Domain.Models;
using TravelHelper.Domain.Models.Enums;

namespace BusinessLayer.Shared.Sort.Options
{
    public class PriceDescendingSortOption : ISortOption<Tour>
    {
        public SortDirection Direction => SortDirection.Descending;
        public Expression<Func<Tour, object>> Expression => tour => tour.PricePerDay;
    }
}
