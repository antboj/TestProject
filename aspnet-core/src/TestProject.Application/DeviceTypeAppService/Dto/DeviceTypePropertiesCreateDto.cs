using System;
using System.Collections.Generic;
using System.Text;
using Abp.Application.Services.Dto;

namespace TestProject.DeviceTypeAppService.Dto
{
    public class DeviceTypePropertiesCreateDto : EntityDto
    {
        public List<DeviceTypePropertyDto> Properties { get; set; } = new List<DeviceTypePropertyDto>();
    }
}
