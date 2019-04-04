using System;
using System.Collections.Generic;
using System.Text;
using Abp.Application.Services.Dto;

namespace TestProject.DeviceAppService.Dto
{
    class DeviceTypePropertyDto : EntityDto
    {
        public string Name { get; set; }
        public bool Required { get; set; }
        public string Type { get; set; }
    }
}
