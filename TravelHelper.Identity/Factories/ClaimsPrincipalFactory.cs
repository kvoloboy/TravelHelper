using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using BusinessLayer.UserManagement.Queries;
using MediatR;
using Microsoft.AspNetCore.Authentication.Cookies;
using TravelHelper.Identity.Factories.Interfaces;

namespace TravelHelper.Identity.Factories
{
    public class ClaimsPrincipalFactory : IClaimsPrincipalFactory
    {
        private readonly IMediator _mediator;

        public ClaimsPrincipalFactory(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<ClaimsPrincipal> CreateAsync(int userId)
        {
            var query = new GetUserByIdQuery
            {
                Id = userId
            };

            var result = await _mediator.Send(query);

            if (result.Failure)
            {
                throw new InvalidOperationException(result.Error);
            }

            var permissionNames = result.Value.Roles.SelectMany(r => r.Permissions).Distinct();

            var claims = new List<Claim>
            {
                new Claim(CustomClaimTypes.Identifier, userId.ToString()),
            };

            claims.AddRange(permissionNames.Select(name => new Claim(CustomClaimTypes.Permission, name)));

            var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
            var claimPrincipal = new ClaimsPrincipal(identity);

            return claimPrincipal;
        }
    }
}
