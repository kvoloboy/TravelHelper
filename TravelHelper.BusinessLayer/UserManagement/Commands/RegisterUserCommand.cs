using BusinessLayer.Utils;
using MediatR;

namespace BusinessLayer.UserManagement.Commands
{
    public class RegisterUserCommand : IRequest<Result>
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
