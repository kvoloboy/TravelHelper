using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using BusinessLayer.Shared;
using BusinessLayer.Shared.Validators.Interfaces;
using BusinessLayer.UserManagement.DTO;
using MediatR;
using TravelHelper.Domain.Abstractions;
using TravelHelper.Domain.Models.Identity;

namespace BusinessLayer.UserManagement.Commands
{
    public class RegisterUserCommandHandler : IRequestHandler<RegisterUserCommand, Result>
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IEnumerable<IValidationRule<PasswordDto>> _passwordValidationRules;
        private readonly IRepository<User> _userRepository;

        public RegisterUserCommandHandler(
            IMapper mapper,
            IUnitOfWork unitOfWork,
            IEnumerable<IValidationRule<PasswordDto>> passwordValidationRules)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _passwordValidationRules = passwordValidationRules;
            _userRepository = _unitOfWork.GetRepository<User>();

        }

        public async Task<Result> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
        {
            var validationResults = _passwordValidationRules.Select(rule =>
            {
                var passwordDto = new PasswordDto(request.Password);
                return rule.Check(passwordDto);
            }).ToArray();

            var passwordValidationResult = Result.Combine(validationResults);

            if (passwordValidationResult.Failure)
            {
                return passwordValidationResult;
            }

            var user = new User
            {
                Email = request.Email,
                PasswordHash = PasswordHasher.CreateHash(request.Password)
            };

            await _userRepository.AddAsync(user);
            await _unitOfWork.CommitAsync();

            return passwordValidationResult;
        }
    }
}
