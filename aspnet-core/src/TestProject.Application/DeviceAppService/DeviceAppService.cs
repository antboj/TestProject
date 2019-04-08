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
        private readonly IRepository<DevicePropertyValue> _devicePropertyValueRepository;

        public DeviceAppService(IRepository<Device> deviceRepository, IRepository<DevicePropertyValue> devicePropertyValueRepository)
        {
            _deviceRepository = deviceRepository;
            _devicePropertyValueRepository = devicePropertyValueRepository;
        }

        public List<DeviceDto> GetAllDevices()
        {
            var allDevices = _deviceRepository.GetAll().Include(x => x.DeviceType).ToList();

            var result = ObjectMapper.Map<List<DeviceDto>>(allDevices);

            return result;
        }

        public void InsertOrUpdateDevice(Device entity)
        {
            // Parent DeviceType
            // Name | Description?
            // All Parent Properties by ParentType

        }
    }
}
