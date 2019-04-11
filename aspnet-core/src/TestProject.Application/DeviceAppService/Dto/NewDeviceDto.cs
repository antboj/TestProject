using System.Collections.Generic;
using Abp.Application.Services.Dto;

namespace TestProject.DeviceAppService.Dto
{
    public class NewDeviceDto : EntityDto
    {
        public string DeviceName { get; set; }

        public string Description { get; set; }

        public List<DeviceTypePropertyValuesDto> DeviceTypes { get; set; } = new List<DeviceTypePropertyValuesDto>();
    }
}
