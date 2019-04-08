using System;
using System.Collections.Generic;
using System.Text;
using TestProject.DeviceAppService.Dto;
using TestProject.Models;

namespace TestProject.DeviceAppService
{
    public interface IDeviceAppService
    {
        void InsertOrUpdateDevice(Device entity);
        List<DeviceDto> GetAllDevices();
    }
}
