using System;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;
using BusinessLayer.Shared;
using MediatR;
using TravelHelper.Domain.Abstractions;
using TravelHelper.Domain.Models.Identity;

namespace BusinessLayer.UserManagement.Queries
{
    public class CanUserSignInQueryHandler : IRequestHandler<CanUserSignInQuery, Result<int>>
    {
        private readonly IRepository<User> _userRepository;

        public CanUserSignInQueryHandler(IUnitOfWork unitOfWork)
        {
            _userRepository = unitOfWork.GetRepository<User>();
        }

        public async Task<Result<int>> Handle(CanUserSignInQuery request, CancellationToken cancellationToken)
        {
            var passwordHash = PasswordHasher.CreateHash(request.Password);
            Expression<Func<User, bool>> searchExpression =
                u => u.Email == request.Email && u.PasswordHash == passwordHash;

            var user = await _userRepository.FindSingleAsync(searchExpression);
            var areValidCredentials = user != null;

            return areValidCredentials ? Result.Ok(user.Id) : Result.Fail<int>("Credentials are invalid");
        }
    }
}
