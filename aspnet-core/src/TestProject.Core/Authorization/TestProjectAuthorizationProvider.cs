using System.Linq;
using System.Reflection;
using Abp.Authorization;
using Abp.Localization;
using Abp.MultiTenancy;
using Castle.DynamicProxy.Internal;

namespace TestProject.Authorization
{
    public class TestProjectAuthorizationProvider : AuthorizationProvider
    {
        public override void SetPermissions(IPermissionDefinitionContext context)
        {
            //var configuration = context.CreatePermission("Configuration");
            //var roles = configuration.CreateChildPermission("Configuration.Roles");
            //roles.CreateChildPermission("Configuration.Roles.Delete");

            //context.CreatePermission(PermissionNames.Pages_Users, L("Users"));
            //context.CreatePermission(PermissionNames.Pages_Roles, L("Roles"));
            //context.CreatePermission(PermissionNames.Pages_Tenants, L("Tenants"),
            //    multiTenancySides: MultiTenancySides.Host);

            MakePermissions(context);
        }

        private static ILocalizableString L(string name)
        {
            return new LocalizableString(name, TestProjectConsts.LocalizationSourceName);
        }

        private void MakePermissions(IPermissionDefinitionContext context)
        {
            var allPermissions = typeof(PermissionNames).GetAllFields();

            foreach (var currentPermission in allPermissions)
            {
                string[] currentPermissionStrings = currentPermission.GetValue(currentPermission).ToString().Split(".");

                var rootPermission = currentPermissionStrings.First();
                var isCreated = context.GetPermissionOrNull(rootPermission);
                Permission lastCreatedPermission = null;
                if (isCreated == null)
                {
                    lastCreatedPermission = context.CreatePermission(rootPermission);

                }
                else
                {
                    lastCreatedPermission = isCreated;
                }
                if (currentPermissionStrings.Length == 1)
                {
                    continue;
                }
                foreach (var currentString in currentPermissionStrings)
                {
                    if (currentString == rootPermission)
                    {
                        continue;
                    }

                    rootPermission = rootPermission + "." + currentString;

                    var isChildCreated = lastCreatedPermission.Children.FirstOrDefault(x => x.Name == rootPermission);
                        //context.GetPermissionOrNull(rootPermission);
                    if (isChildCreated == null)
                    {
                        lastCreatedPermission = lastCreatedPermission.CreateChildPermission(rootPermission);
                    }
                    else
                    {
                        continue;
                    }

                    if (currentPermissionStrings.Last() == currentString)
                    {
                        rootPermission = "";
                        lastCreatedPermission = null;
                    }
                }

            }
        }
    }
}