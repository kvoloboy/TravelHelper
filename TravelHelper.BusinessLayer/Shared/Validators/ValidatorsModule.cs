using Autofac;
using BusinessLayer.Shared.Validators.Interfaces;
using BusinessLayer.Shared.Validators.Password;
using BusinessLayer.UserManagement.DTO;

namespace BusinessLayer.Shared.Validators
{
    public class ValidatorsModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<ContainsLowerSymbolPasswordValidationRule>()
                .As<IValidationRule<PasswordDto>>()
                .SingleInstance();

            builder.RegisterType<ContainsUpperSymbolPasswordValidationRule>()
                .As<IValidationRule<PasswordDto>>()
                .SingleInstance();

            builder.RegisterType<MinPasswordLengthValidationRule>()
                .As<IValidationRule<PasswordDto>>()
                .SingleInstance();
        }
    }
}
