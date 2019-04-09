using System.Collections.Generic;
using System.Linq;
using Abp.Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using TestProject.DeviceAppService.Dto;
using TestProject.DeviceTypeAppService;
using TestProject.DeviceTypeAppService.Dto;
using TestProject.Models;

namespace TestProject.DeviceAppService
{
    public class DeviceAppService : TestProjectAppServiceBase, IDeviceAppService
    {
        private readonly IRepository<Device> _deviceRepository;
        private readonly IRepository<DevicePropertyValue> _devicePropertyValueRepository;
        private readonly IDeviceTypeAppService _deviceTypeAppService;

        public DeviceAppService(IRepository<Device> deviceRepository, IRepository<DevicePropertyValue> devicePropertyValueRepository, IDeviceTypeAppService deviceTypeAppService)
        {
            _deviceRepository = deviceRepository;
            _devicePropertyValueRepository = devicePropertyValueRepository;
            _deviceTypeAppService = deviceTypeAppService;
        }

        public List<DeviceDto> GetAllDevices()
        {
            var allDevices = _deviceRepository.GetAll().Include(x => x.DeviceType).ToList();

            var result = ObjectMapper.Map<List<DeviceDto>>(allDevices);

            return result;
        }

        public IEnumerable<DeviceTypePropertiesNestedDto> GetAllDeviceTypes(int id)
        {
            return _deviceTypeAppService.GetAllDeviceTypesPropertiesNested(id);
        }

        public void InsertOrUpdateDevice(Device entity)
        {
            // Parent DeviceType
            // Name | Description?
            // All Parent Properties by ParentType

        }
    }
}
