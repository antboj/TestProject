using Abp.Authorization;
using TestProject.Authorization.Roles;
using TestProject.Authorization.Users;

namespace TestProject.Authorization
{
    public class PermissionChecker : PermissionChecker<Role, User>
    {
        public PermissionChecker(UserManager userManager)
            : base(userManager)
        {
        }
    }
}
