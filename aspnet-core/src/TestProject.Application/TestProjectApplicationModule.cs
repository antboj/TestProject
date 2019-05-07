using Abp.AutoMapper;
using Abp.Modules;
using Abp.Reflection.Extensions;
using TestProject.Authorization;
using TestProject.DeviceAppService.Dto;
using TestProject.DeviceTypeAppService.Dto;
using TestProject.Models;

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

            Configuration.Modules.AbpAutoMapper().Configurators.Add(config =>
            {
                config.CreateMap<DeviceType, DeviceTypeNestedDto>()
                    .ForMember(dest => dest.Name, source => source.MapFrom(src => src.Name))
                    .ForMember(dest => dest.Description, source => source.MapFrom(src => src.Description))
                    .ForMember(dest => dest.ParentId, source => source.MapFrom(src => src.ParentDeviceType.Id))
                    .ForMember(d => d.Items, s => s.Ignore());

                config.CreateMap<DeviceTypeProperty, DeviceTypePropertyDto>()
                    .ForMember(d => d.NameProperty, s => s.MapFrom(x => x.Name))
                    .ForMember(d => d.Required, s => s.MapFrom(x => x.IsMandatory))
                    .ForMember(d => d.Type, s => s.MapFrom(x => x.Type));

                config.CreateMap<DeviceTypeProperty, DeviceTypePropertyDto>()
                    .ForMember(dest => dest.NameProperty, source => source.MapFrom(src => src.Name))
                    .ForMember(dest => dest.Required, source => source.MapFrom(src => src.IsMandatory))
                    .ForMember(dest => dest.Type, source => source.MapFrom(src => src.Type));

                config.CreateMap<DeviceType, DeviceTypePropertiesNestedDto>()
                    .ForMember(dest => dest.Name, source => source.MapFrom(src => src.Name))
                    .ForMember(dest => dest.Description, source => source.MapFrom(src => src.Description))
                    .ForMember(dest => dest.ParentId, source => source.MapFrom(src => src.ParentDeviceType.Id))
                    .ForMember(dest => dest.Properties, source => source.MapFrom(src => src.DeviceTypeProperties));

                config.CreateMap<DeviceTypePropertiesCreateDto, DeviceType>()
                    .ForMember(dest => dest.Id, source => source.MapFrom(src => src.Id))
                    .ForMember(dest => dest.DeviceTypeProperties, source => source.MapFrom(src => src.Properties));


                config.CreateMap<Device, DeviceDto>()
                    .ForMember(dest => dest.Name, source => source.MapFrom(src => src.Name))
                    .ForMember(dest => dest.Description, source => source.MapFrom(src => src.Description))
                    .ForMember(dest => dest.DeviceTypeName, source => source.MapFrom(src => src.DeviceType.Name));
            });
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