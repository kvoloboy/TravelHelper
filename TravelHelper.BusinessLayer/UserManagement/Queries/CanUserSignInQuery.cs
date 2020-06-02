using MediatR;

namespace BusinessLayer.UserManagement.Queries
{
    public class CanUserSignInQuery : IRequest<bool>
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
