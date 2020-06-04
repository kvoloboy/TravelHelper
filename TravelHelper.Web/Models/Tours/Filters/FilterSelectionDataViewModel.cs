using System.Collections.Generic;
using TravelHelper.Web.Models.Shared;

namespace TravelHelper.Web.Models.Tours.Filters
{
    public class FilterSelectionDataViewModel
    {
        public IEnumerable<ListItem> Categories { get; set; }
        public IEnumerable<ListItem> Agencies { get; set; }
        public IEnumerable<ListItem> SortOptions { get; set; }
        public IEnumerable<ListItem> DestinationPoints { get; set; }
    }
}
