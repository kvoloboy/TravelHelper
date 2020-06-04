using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using BusinessLayer.Shared;
using BusinessLayer.Shared.Constants;
using BusinessLayer.Shared.Validators.Interfaces;
using BusinessLayer.UserManagement.DTO;
using MediatR;
using TravelHelper.Domain.Abstractions;
using TravelHelper.Domain.Models.Identity;

namespace BusinessLayer.UserManagement.Commands
{
    public class RegisterUserCommandHandler : IRequestHandler<RegisterUserCommand, Result<int>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IEnumerable<IValidationRule<PasswordDto>> _passwordValidationRules;
        private readonly IRepository<User> _userRepository;
        private readonly IReadonlyRepository<Role> _roleRepository;

        public RegisterUserCommandHandler(
            IUnitOfWork unitOfWork,
            IEnumerable<IValidationRule<PasswordDto>> passwordValidationRules)
        {
            _unitOfWork = unitOfWork;
            _passwordValidationRules = passwordValidationRules;
            _userRepository = _unitOfWork.GetRepository<User>();
            _roleRepository = _unitOfWork.GetReadonlyRepository<Role>();
        }

        public async Task<Result<int>> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
        {
            var validationResults = _passwordValidationRules.Select(rule =>
            {
                var passwordDto = new PasswordDto(request.Password);
                return rule.Check(passwordDto);
            }).ToArray();

            var passwordValidationResult = Result.Combine(validationResults);

            if (passwordValidationResult.Failure)
            {
                return Result.Fail<int>(passwordValidationResult.Error);
            }

            var user = await CreateUser(request);
            await _userRepository.AddAsync(user);
            await _unitOfWork.CommitAsync();

            return Result.Ok(user.Id);
        }

        private async Task<User> CreateUser(RegisterUserCommand request)
        {
            var userRole = await _roleRepository.FindSingleAsync(r => r.Name == Roles.User);

            var user = new User
            {
                Email = request.Email,
                PasswordHash = PasswordHasher.CreateHash(request.Password),
                UserRoles = new List<UserRole>
                {
                    new UserRole
                    {
                        RoleId = userRole.Id
                    }
                }
            };

            return user;
        }
    }
}
