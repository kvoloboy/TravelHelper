using System.Linq;
using BusinessLayer.Shared.Constants;
using BusinessLayer.Shared.Validators.Interfaces;
using BusinessLayer.UserManagement.DTO;

namespace BusinessLayer.Shared.Validators.Password
{
    public class ContainsLowerSymbolPasswordValidationRule : IValidationRule<PasswordDto>
    {
        public Result Check(PasswordDto input)
        {
            var isValid = input.Value.Any(char.IsLower);

            return isValid ? Result.Ok() : Result.Fail(PasswordValidationErrors.ShouldContainLowerSymbol);
        }
    }
}
