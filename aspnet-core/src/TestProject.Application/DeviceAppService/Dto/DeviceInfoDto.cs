using System.Collections.Generic;
using Abp.Application.Services.Dto;

namespace TestProject.DeviceAppService.Dto
{
    class DeviceInfoDto : EntityDto
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public string DeviceTypeName { get; set; }

        public List<DeviceTypePropertyValuesDto> DeviceTypePropertyValues { get; set; } = new List<DeviceTypePropertyValuesDto>();
    }
}
