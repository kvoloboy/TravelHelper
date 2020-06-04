using System.Linq;
using AutoMapper;
using BusinessLayer.UserManagement.DTO;
using TravelHelper.Domain.Models.Identity;

namespace BusinessLayer.UserManagement.Mappings
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<User, UserDto>();

            CreateMap<Role, RoleDto>()
                .ForMember(dest => dest.Permissions,
                    opt => opt.MapFrom(src =>
                        src.RolePermissions.Select(rolePermission => rolePermission.Permission.Value)));
        }
    }
}
