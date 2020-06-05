using BusinessLayer.Shared;
using MediatR;

namespace BusinessLayer.UserManagement.Queries
{
    public class CanUserSignInQuery : IRequest<Result<int>>
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
