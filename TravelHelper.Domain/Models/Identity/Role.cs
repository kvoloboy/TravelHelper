using System.Collections.Generic;

namespace TravelHelper.Domain.Models.Identity
{
    public class Role : BaseEntity
    {
        public string Name { get; set; }
        public ICollection<RolePermission> RolePermissions { get; set; }
    }
}
