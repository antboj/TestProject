using Abp.Application.Services.Dto;

namespace TestProject.DeviceAppService.Dto
{
    public class DeviceDto : EntityDto
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public string DeviceTypeName { get; set; }
    }
}
