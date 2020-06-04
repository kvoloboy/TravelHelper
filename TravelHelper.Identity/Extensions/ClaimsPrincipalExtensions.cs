using System;
using System.Security.Claims;

namespace TravelHelper.Identity.Extensions
{
    public static class ClaimsPrincipalExtensions
    {
        public static bool IsAllowedPermission(this ClaimsPrincipal user, string permission)
        {
            var isAllowed = user.HasClaim(c => c.Type == CustomClaimTypes.Permission && c.Value == permission);

            return isAllowed;
        }

        public static int GetId(this ClaimsPrincipal user)
        {
            var userId = user.FindFirst(c => c.Type == CustomClaimTypes.Identifier)?.Value ?? string.Empty;

            if (!int.TryParse(userId, out var id))
            {
                throw new InvalidOperationException($"Cannot parse user id {userId} to number");
            }

            return id;
        }
    }
}
