using System.Collections.Generic;
using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using TestProject.Models;

namespace TestProject.DeviceTypeAppService.Dto
{
    [AutoMap(typeof(DeviceType))]
    public class DeviceTypeDto : EntityDto
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public int? ParentId { get; set; }

        //public List<DeviceTypeNestedDto> Properties { get; set; } = new List<DeviceTypeNestedDto>();

    }
}
