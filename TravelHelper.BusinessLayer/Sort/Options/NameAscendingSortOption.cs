using System;
using System.Linq.Expressions;
using BusinessLayer.Sort.Options.Interfaces;
using TravelHelper.Domain.Models;
using TravelHelper.Domain.Models.Enums;

namespace BusinessLayer.Sort.Options
{
    public class NameAscendingSortOption : ISortOption<Tour>
    {
        public SortDirection Direction => SortDirection.Ascending;
        public Expression<Func<Tour, object>> Expression => tour => tour.Name;
    }
}
