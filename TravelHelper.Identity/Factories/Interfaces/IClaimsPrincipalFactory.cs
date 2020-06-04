using System.Security.Claims;
using System.Threading.Tasks;

namespace TravelHelper.Identity.Factories.Interfaces
{
    public interface IClaimsPrincipalFactory
    {
        Task<ClaimsPrincipal> CreateAsync(int userId);
    }
}
