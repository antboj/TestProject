using System.Collections.Generic;
using Abp.Application.Services.Dto;

namespace TestProject.DeviceAppService.Dto
{
    public class DeviceTypePropertyValuesDto : EntityDto
    {
        public List<PropertyValueDto> PropValues { get; set; } = new List<PropertyValueDto>();
    }
}