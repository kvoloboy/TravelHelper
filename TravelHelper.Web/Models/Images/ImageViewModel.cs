using System.ComponentModel.DataAnnotations;

namespace TravelHelper.Web.Models.Images
{
    public class ImageViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Enter path, please")]
        public string Path { get; set; }
    }
}
