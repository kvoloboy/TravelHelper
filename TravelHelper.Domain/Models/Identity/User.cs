using System.Collections.Generic;

namespace TravelHelper.Domain.Models.Identity
{
    public class User : BaseEntity
    {
        public string Email { get; set; }
        public string PasswordHash { get; set; }

        public ICollection<UserRole> UserRoles { get; set; }
        public ICollection<Rating> TourRatings { get; set; }
    }
}
