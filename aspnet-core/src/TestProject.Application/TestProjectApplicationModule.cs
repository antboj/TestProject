using Abp.AutoMapper;
using Abp.Modules;
using Abp.Reflection.Extensions;
using TestProject.Authorization;

namespace TestProject
{
    [DependsOn(
        typeof(TestProjectCoreModule), 
        typeof(AbpAutoMapperModule))]
    public class TestProjectApplicationModule : AbpModule
    {
        public override void PreInitialize()
        {
            Configuration.Authorization.Providers.Add<TestProjectAuthorizationProvider>();
        }

        public override void Initialize()
        {
            var thisAssembly = typeof(TestProjectApplicationModule).GetAssembly();

            IocManager.RegisterAssemblyByConvention(thisAssembly);

            Configuration.Modules.AbpAutoMapper().Configurators.Add(
                // Scan the assembly for classes which inherit from AutoMapper.Profile
                cfg => cfg.AddProfiles(thisAssembly)
            );
        }
    }
}
