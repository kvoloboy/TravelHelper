using Microsoft.AspNetCore.Authorization;

namespace TravelHelper.Identity.Attributes
{
    public class HasPermissionAttribute : AuthorizeAttribute
    {
        public HasPermissionAttribute(string permission)
            : base(permission)
        {
        }
    }
}
