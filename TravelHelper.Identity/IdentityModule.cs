using Autofac;
using Microsoft.AspNetCore.Authorization;
using TravelHelper.Identity.Factories;
using TravelHelper.Identity.Factories.Interfaces;
using TravelHelper.Identity.PolicyProviders;
using TravelHelper.Identity.Requirements.Handlers;

namespace TravelHelper.Identity
{
    public class IdentityModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<AuthorizationPolicyProvider>()
                .As<IAuthorizationPolicyProvider>()
                .SingleInstance();

            builder.RegisterType<PermissionRequirementHandler>()
                .As<IAuthorizationHandler>()
                .SingleInstance();

            builder.RegisterType<ClaimsPrincipalFactory>()
                .As<IClaimsPrincipalFactory>()
                .InstancePerLifetimeScope();
        }
    }
}
