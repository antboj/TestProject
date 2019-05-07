using System.Collections.Generic;
using TestProject.DeviceTypeAppService.Dto;

namespace TestProject.DeviceTypeAppService
{
    public interface IDeviceTypeAppService
    {
        List<DeviceTypeNestedDto> GetDeviceTypes(int? parentId);
        IEnumerable<DeviceTypePropertiesNestedDto> GetDeviceTypesWithProperties(int? parentId);
        IEnumerable<DeviceTypePropertiesNestedDto> CreateOrUpdateDeviceType(DeviceTypeDto input);
    }
}