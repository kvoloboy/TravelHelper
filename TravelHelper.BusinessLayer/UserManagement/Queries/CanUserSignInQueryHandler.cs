using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Identity;
using TravelHelper.Domain.Models.Identity;

namespace BusinessLayer.UserManagement.Queries
{
    public class CanUserSignInQueryHandler : IRequestHandler<CanUserSignInQuery, bool>
    {
        private readonly UserManager<User> _userManager;
        private readonly IMapper _mapper;

        public CanUserSignInQueryHandler(UserManager<User> userManager, IMapper mapper)
        {
            _userManager = userManager;
            _mapper = mapper;
        }

        public Task<bool> Handle(CanUserSignInQuery request, CancellationToken cancellationToken)
        {
            var user = new User
            {
                Email = request.Email
            };

            return _userManager.CheckPasswordAsync(user, request.Password);
        }
    }
}
