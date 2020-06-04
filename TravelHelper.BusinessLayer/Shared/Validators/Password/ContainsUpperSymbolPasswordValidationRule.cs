using System.Linq;
using BusinessLayer.Shared.Constants;
using BusinessLayer.Shared.Validators.Interfaces;
using BusinessLayer.UserManagement.DTO;

namespace BusinessLayer.Shared.Validators.Password
{
    public class ContainsUpperSymbolPasswordValidationRule : IValidationRule<PasswordDto>
    {
        public Result Check(PasswordDto input)
        {
            var isValid = input.Value.Any(char.IsUpper);

            return isValid ? Result.Ok() : Result.Fail(PasswordValidationErrors.ShouldContainUpperSymbol);
        }
    }
}
