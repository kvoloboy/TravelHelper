using System.ComponentModel.DataAnnotations;

namespace TravelHelper.Web.Models.Categories
{
    public class CategoryViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Enter name, please")]
        public string Name { get; set; }
    }
}
