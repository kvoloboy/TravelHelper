using System;
using System.Linq.Expressions;
using BusinessLayer.Utils.Sort.Options.Interfaces;
using TravelHelper.Domain.Models;
using TravelHelper.Domain.Models.Enums;

namespace BusinessLayer.Utils.Sort.Options
{
    public class NameDescendingSortOption : ISortOption<Tour>
    {
        public SortDirection Direction => SortDirection.Descending;
        public Expression<Func<Tour, object>> Expression => tour => tour.Name;
    }
}
