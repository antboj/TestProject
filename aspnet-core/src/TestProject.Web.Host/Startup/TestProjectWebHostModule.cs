using Abp.Modules;
using Abp.Reflection.Extensions;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using TestProject.Configuration;

namespace TestProject.Web.Host.Startup
{
    [DependsOn(
        typeof(TestProjectWebCoreModule))]
    public class TestProjectWebHostModule : AbpModule
    {
        private readonly IConfigurationRoot _appConfiguration;
        private readonly IHostingEnvironment _env;

        public TestProjectWebHostModule(IHostingEnvironment env)
        {
            _env = env;
            _appConfiguration = env.GetAppConfiguration();
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(TestProjectWebHostModule).GetAssembly());
        }
    }
}