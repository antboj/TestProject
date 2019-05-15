using Abp.Authorization;
using Abp.Localization;
using Abp.MultiTenancy;

namespace TestProject.Authorization
{
    public class TestProjectAuthorizationProvider : AuthorizationProvider
    {
        public override void SetPermissions(IPermissionDefinitionContext context)
        {
            var configuration = context.CreatePermission("Configuration");
            var roles = configuration.CreateChildPermission("Configuration.Roles");
            roles.CreateChildPermission("Configuration.Roles.Delete");

            context.CreatePermission(PermissionNames.Pages_Users, L("Users"));
            context.CreatePermission(PermissionNames.Pages_Roles, L("Roles"));
            context.CreatePermission(PermissionNames.Pages_Tenants, L("Tenants"),
                multiTenancySides: MultiTenancySides.Host);
        }

        private static ILocalizableString L(string name)
        {
            return new LocalizableString(name, TestProjectConsts.LocalizationSourceName);
        }
    }
}