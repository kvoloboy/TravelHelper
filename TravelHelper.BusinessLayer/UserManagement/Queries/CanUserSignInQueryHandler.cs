using System;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using TravelHelper.Domain.Abstractions;
using TravelHelper.Domain.Models.Identity;

namespace BusinessLayer.UserManagement.Queries
{
    public class CanUserSignInQueryHandler : IRequestHandler<CanUserSignInQuery, bool>
    {
        private readonly IRepository<User> _userRepository;

        public CanUserSignInQueryHandler(IUnitOfWork unitOfWork)
        {
            _userRepository = unitOfWork.GetRepository<User>();
        }

        public async Task<bool> Handle(CanUserSignInQuery request, CancellationToken cancellationToken)
        {
            var passwordHash = PasswordHasher.CreateHash(request.Password);
            Expression<Func<User, bool>> searchExpression =
                u => u.Email == request.Email && u.PasswordHash == passwordHash;

            var areValidCredentials = await _userRepository.AnyAsync(searchExpression);

            return areValidCredentials;
        }
    }
}
