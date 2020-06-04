using System.ComponentModel.DataAnnotations;

namespace TravelHelper.Web.Models.Agencies
{
    public class AgencyViewModel
    {
        public int Id { get; set; }
        
        [Required(ErrorMessage = "Enter name, please")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Enter phone, please")]
        public string Phone { get; set; }

        [Required(ErrorMessage = "Enter description , please")]
        public string Description { get; set; }
    }
}
