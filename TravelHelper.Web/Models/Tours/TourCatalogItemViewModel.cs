using TravelHelper.Web.Models.Images;

namespace TravelHelper.Web.Models.Tours
{
    public class TourCatalogItemViewModel
    {
        public string Name { get; set; }
        public string Description{ get; set; }
        public ImageViewModel Image { get; set; }
    }
}
