using System;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using BusinessLayer.Utils;
using MediatR;
using Microsoft.AspNetCore.Identity;
using TravelHelper.Domain.Models.Identity;

namespace BusinessLayer.UserManagement.Commands
{
    public class RegisterUserCommandHandler : IRequestHandler<RegisterUserCommand, Result>
    {
        private readonly UserManager<User> _userManager;
        private readonly IMapper _mapper;

        public RegisterUserCommandHandler(UserManager<User> userManager, IMapper mapper)
        {
            _userManager = userManager;
            _mapper = mapper;
        }

        public async Task<Result> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
        {
            var user = _mapper.Map<RegisterUserCommand, User>(request);

            var result = await _userManager.CreateAsync(user);

            return result.Succeeded ? Result.Ok() : Result.Fail(string.Join(Environment.NewLine, result.Errors));
        }
    }
}
