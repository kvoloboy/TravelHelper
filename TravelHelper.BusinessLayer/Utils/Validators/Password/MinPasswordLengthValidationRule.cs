using BusinessLayer.Utils.Constants;
using BusinessLayer.Utils.DTO;
using BusinessLayer.Utils.Validators.Interfaces;

namespace BusinessLayer.Utils.Validators.Password
{
    public class MinPasswordLengthValidationRule : IValidationRule<PasswordDto>
    {
        public static int MinPasswordLength => 8;

        public Result Check(PasswordDto input)
        {
            var isValid = !string.IsNullOrEmpty(input.Value) && input.Value.Length >= MinPasswordLength;

            return isValid ? Result.Ok() : Result.Fail(PasswordValidationErrors.MinLength);
        }
    }
}
