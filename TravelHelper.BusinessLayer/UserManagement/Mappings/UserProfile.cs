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
            CreateMap<User, UserDto>()
                .ForMember(dest => dest.Roles, opt => opt.MapFrom(src => src.UserRoles));

            CreateMap<UserRole, RoleDto>()
                .ForMember(dest => dest.Permissions,
                    opt => opt.MapFrom(src =>
                        src.Role.RolePermissions.Select(rolePermission => rolePermission.Permission.Value)))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Role.Name))
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.RoleId));
        }
    }
}
