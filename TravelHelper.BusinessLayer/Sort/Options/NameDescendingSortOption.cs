﻿using System;
using System.Linq.Expressions;
using BusinessLayer.Sort.Options.Interfaces;
using TravelHelper.Domain.Models;

namespace BusinessLayer.Sort.Options
{
    public class NameDescendingSortOption : ISortOption<Tour>
    {
        public SortDirection Direction => SortDirection.Descending;
        public Expression<Func<Tour, object>> Expression => tour => tour.Name;
    }
}