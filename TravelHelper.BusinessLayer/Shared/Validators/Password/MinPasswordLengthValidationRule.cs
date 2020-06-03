using BusinessLayer.Shared.Constants;
using BusinessLayer.Shared.Validators.Interfaces;
using BusinessLayer.UserManagement.DTO;

namespace BusinessLayer.Shared.Validators.Password
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
