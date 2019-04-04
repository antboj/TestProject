using System;
using System.Collections.Generic;
using System.Text;
using Abp.Application.Services.Dto;

namespace TestProject.DeviceAppService.Dto
{
    class GetAllDeviceTypesNestedDto : EntityDto
    {
        public string Name { get; set; }
        public int ParentId { get; set; }
        public string Description { get; set; }
        public List<DeviceTypePropertyDto> Properties { get; set; }
        public List<GetAllDeviceTypesNestedDto> Nested { get; set; }
    }
}
