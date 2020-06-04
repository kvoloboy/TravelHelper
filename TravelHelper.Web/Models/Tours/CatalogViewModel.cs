using System.Collections.Generic;
using TravelHelper.Web.Models.Tours.Filters;

namespace TravelHelper.Web.Models.Tours
{
    public class CatalogViewModel
    {
        public FilterViewModel Filter { get; set; }
        public IEnumerable<TourCatalogItemViewModel> Items { get; set; }
    }
}
