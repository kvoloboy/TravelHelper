﻿using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using TravelHelper.Identity.Extensions;

namespace TravelHelper.Identity.Requirements.Handlers
{
    public class PermissionRequirementHandler : AuthorizationHandler<PermissionRequirement>
    {
        protected override Task HandleRequirementAsync(
            AuthorizationHandlerContext context,
            PermissionRequirement requirement)
        {
            var user = context.User;

            if (user.IsAllowedPermission(requirement.PermissionName))
            {
                context.Succeed(requirement);
            }

            return Task.CompletedTask;
        }
    }
}
