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
        private readonly IRepository<DeviceTypeProperty> _deviceTypePropertyRepository;
        private readonly IRepository<DevicePropertyValue> _devicePropertyValueRepository;

        public DeviceAppService(IRepository<Device> deviceRepository, IRepository<DeviceTypeProperty> deviceTypePropertyRepository, IRepository<DevicePropertyValue> devicePropertyValueRepository)
        {
            _deviceRepository = deviceRepository;
            _deviceTypePropertyRepository = deviceTypePropertyRepository;
            _devicePropertyValueRepository = devicePropertyValueRepository;
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
        
        public void CreateOrUpdateDevice(NewDeviceDto input)
        {
            if (input.Id == 0)
            {
                var newDevice = new Device
                {
                    Name = input.DeviceName,
                    Description = input.Description,
                };

                var propertyValuesList = new List<DevicePropertyValue>();
                var maxDeviceTypeId = input.DeviceTypes.Max(x => x.Id);

                foreach (var deviceType in input.DeviceTypes)
                {
                    foreach (var propertyValue in deviceType.PropValues)
                    {
                        propertyValuesList.Add(new DevicePropertyValue
                        {
                            Value = propertyValue.Value,
                            DeviceTypePropertyId = _deviceTypePropertyRepository.
                                FirstOrDefault(x => x.DeviceTypeId == deviceType.Id && x.Name == propertyValue.PropName).Id,
                            DeviceId = newDevice.Id
                        });
                    }
                }

                newDevice.DeviceTypeValues = propertyValuesList;
                newDevice.DeviceTypeId = maxDeviceTypeId;

                _deviceRepository.Insert(newDevice);
                return;
            }

            var foundDevice = _deviceRepository.GetAll().Include(x => x.DeviceTypeValues)
                .First(x => x.Id == input.Id);

            foundDevice.Name = input.DeviceName;
            foundDevice.Description = input.Description;

            foreach (var deviceType in input.DeviceTypes)
            {
                foreach (var propertyValue in deviceType.PropValues)
                {
                    var propertyValues = _devicePropertyValueRepository.GetAll()
                        .Include(x => x.Device)
                        .Include(x => x.DeviceTypeProperty);
                    var foundValue = propertyValues
                        .First(x => x.DeviceId == foundDevice.Id && x.DeviceTypeProperty.Name == propertyValue.PropName);
                    foundValue.Value = propertyValue.Value;
                }
            }
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
