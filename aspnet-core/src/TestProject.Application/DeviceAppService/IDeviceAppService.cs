using System.Collections.Generic;
using TestProject.DeviceAppService.Dto;
using TestProject.Models;

namespace TestProject.DeviceAppService
{
    public interface IDeviceAppService
    {
        void CreateOrUpdateDevice(NewDeviceDto input);
        List<DeviceDto> GetDevices();
        void DeleteDevice(int id);
    }
}
