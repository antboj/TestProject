using System.Collections.Generic;
using System.Linq;
using TestProject.DeviceAppService.Dto;
using TestProject.Models;
using TestProject.QueryInfoService;

namespace TestProject.DeviceAppService
{
    public interface IDeviceAppService
    {
        void CreateOrUpdateDevice(NewDeviceDto input);
        List<DeviceDto> GetDevices();
        void DeleteDevice(int id);
        List<Device> QueryInfoSearch(QueryInfo input);
    }
}
