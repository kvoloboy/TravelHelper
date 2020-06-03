using BusinessLayer.Shared;
using BusinessLayer.UserManagement.DTO;
using MediatR;

namespace BusinessLayer.UserManagement.Queries
{
    public class GetUserByIdQuery : IRequest<Result<UserDto>>
    {
        public int Id { get; set; }
    }
}
