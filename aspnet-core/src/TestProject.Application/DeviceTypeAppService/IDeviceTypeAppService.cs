using System.Collections.Generic;
using TestProject.DeviceTypeAppService.Dto;

namespace TestProject.DeviceTypeAppService
{
    public interface IDeviceTypeAppService
    {
        List<DeviceTypeNestedDto> GetAllDeviceTypesNested(int? parentId);
        IEnumerable<DeviceTypePropertiesNestedDto> GetAllDeviceTypesPropertiesNested(int? parentId);
        IEnumerable<DeviceTypePropertiesNestedDto> InsertOrUpdateDeviceType(DeviceTypeDto input);
        //List<DeviceTypePropertyDto> GetProperties(int typeId);

    }
}
