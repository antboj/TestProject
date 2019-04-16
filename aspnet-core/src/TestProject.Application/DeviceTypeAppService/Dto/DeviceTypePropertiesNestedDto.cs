using System.Collections.Generic;
using Abp.Application.Services.Dto;

namespace TestProject.DeviceTypeAppService.Dto
{
    public class DeviceTypePropertiesNestedDto : EntityDto
    {
        public string Name { get; set; }
        public int? ParentId { get; set; }
        public string Description { get; set; }
        public List<DeviceTypePropertyDto> Properties { get; set; } = new List<DeviceTypePropertyDto>();
    }
}
