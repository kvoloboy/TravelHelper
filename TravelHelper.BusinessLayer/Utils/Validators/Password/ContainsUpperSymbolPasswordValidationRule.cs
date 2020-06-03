using System.Linq;
using BusinessLayer.Utils.Constants;
using BusinessLayer.Utils.DTO;
using BusinessLayer.Utils.Validators.Interfaces;

namespace BusinessLayer.Utils.Validators.Password
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
