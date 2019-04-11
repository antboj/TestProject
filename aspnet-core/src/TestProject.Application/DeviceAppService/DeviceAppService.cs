using System.Collections.Generic;
using System.Linq;
using Abp.Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using TestProject.DeviceAppService.Dto;
using TestProject.Models;

namespace TestProject.DeviceAppService
{
    public class DeviceAppService : TestProjectAppServiceBase, IDeviceAppService
    {
        private readonly IRepository<Device> _deviceRepository;

        public DeviceAppService(IRepository<Device> deviceRepository)
        {
            _deviceRepository = deviceRepository;
        }

        /// <summary>
        /// Return all Devices
        /// </summary>
        /// <returns></returns>
        public List<DeviceDto> GetDevices()
        {
            var allDevices = _deviceRepository.GetAll().Include(x => x.DeviceType).ToList();

            var result = ObjectMapper.Map<List<DeviceDto>>(allDevices);

            return result;
        }
        
        public void CreateOrUpdateDevice(Device entity)
        {
            // Parent DeviceType
            // Name | Description?
            // All Parent Properties by ParentType

        }

        /// <summary>
        /// Delete Device
        /// </summary>
        /// <param name="id"></param>
        public void DeleteDevice(int id)
        {
            var deviceToDelete = _deviceRepository.Get(id);
            _deviceRepository.Delete(deviceToDelete);
        }
    }
}
