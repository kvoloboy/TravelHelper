using System.Collections.Generic;
using TravelHelper.Domain.Models.Enums;

namespace TravelHelper.Web.Models.Tours.Filters
{
    public class FilterSelectedOptionsViewModel
    {
        public int MinPrice { get; set; }
        public int MaxPrice { get; set; }
        public string Name { get; set; }
        public TimeOfTheYear? TimeOfTheYear { get; set; }
        public int DestinationPointId { get; set; }
        public IEnumerable<int> Categories { get; set; }
        public IEnumerable<int> Agencies { get; set; }
        public string SortOption { get; set; }
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
    }
}
