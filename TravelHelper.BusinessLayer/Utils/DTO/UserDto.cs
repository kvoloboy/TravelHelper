using System.Collections.Generic;

namespace BusinessLayer.Utils.DTO
{
    public class UserDto
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public IEnumerable<RoleDto> Roles { get; set; }
    }
}
