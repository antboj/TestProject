using Abp.AspNetCore.Mvc.Controllers;
using Abp.IdentityFramework;
using Microsoft.AspNetCore.Identity;

namespace TestProject.Controllers
{
    public abstract class TestProjectControllerBase: AbpController
    {
        protected TestProjectControllerBase()
        {
            LocalizationSourceName = TestProjectConsts.LocalizationSourceName;
        }

        protected void CheckErrors(IdentityResult identityResult)
        {
            identityResult.CheckErrors(LocalizationManager);
        }
    }
}
