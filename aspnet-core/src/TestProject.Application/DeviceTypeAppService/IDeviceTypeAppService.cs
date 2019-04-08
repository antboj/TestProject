using System;
using System.Collections.Generic;
using System.Text;
using TestProject.DeviceTypeAppService.Dto;

namespace TestProject.DeviceAppService
{
    public interface IDeviceTypeAppService
    {
        List<DeviceTypeNestedDto> GetAllDeviceTypesNested(int? parentId);
        IEnumerable<DeviceTypePropertiesNestedDto> GetAllDeviceTypesPropertiesNested(int? parentId);
        IEnumerable<DeviceTypePropertiesNestedDto> InsertOrUpdateDeviceType(DeviceTypeDto input);
    }
}
