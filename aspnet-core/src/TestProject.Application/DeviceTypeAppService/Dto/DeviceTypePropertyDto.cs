using Abp.Application.Services.Dto;

namespace TestProject.DeviceTypeAppService.Dto
{
    public class DeviceTypePropertyDto : EntityDto
    {
        public string NameProperty { get; set; }
        public bool Required { get; set; }
        public string Type { get; set; }
    }
}
