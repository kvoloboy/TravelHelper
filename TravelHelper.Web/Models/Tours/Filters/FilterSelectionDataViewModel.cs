using System.Collections.Generic;
using TravelHelper.Web.Models.Shared;

namespace TravelHelper.Web.Models.Tours.Filters
{
    public class FilterSelectionDataViewModel
    {
        public IEnumerable<ListItem<int>> Categories { get; set; }
        public IEnumerable<ListItem<int>> Agencies { get; set; }
        public IEnumerable<ListItem<string>> SortOptions { get; set; }
        public IEnumerable<ListItem<int>> DestinationPoints { get; set; }
    }
}
