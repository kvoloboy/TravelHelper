using System.ComponentModel.DataAnnotations;

namespace TravelHelper.Web.Models.Location
{
    public class LocationViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Enter name, please")]
        public string Name { get; set; }
    }
}
