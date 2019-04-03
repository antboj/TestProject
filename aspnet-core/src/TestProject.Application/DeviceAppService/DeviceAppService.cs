﻿using Abp.Domain.Repositories;
using TestProject.Models;

namespace TestProject.DeviceAppService
{
    class DeviceAppService : TestProjectAppServiceBase, IDeviceAppService
    {
        private readonly IRepository<DeviceType> _deviceTypeRepository;
        private readonly IRepository<DeviceTypeProperty> _deviceTypePropertyRepository;
        private readonly IRepository<Device> _deviceRepository;
        private readonly IRepository<DevicePropertyValue> _devicePropertyValueRepository;

        public DeviceAppService(IRepository<DeviceType> deviceTypeRepository, IRepository<DeviceTypeProperty> deviceTypePropertyRepository, IRepository<Device> deviceRepository, IRepository<DevicePropertyValue> devicePropertyValueRepository)
        {
            _deviceTypeRepository = deviceTypeRepository;
            _deviceTypePropertyRepository = deviceTypePropertyRepository;
            _deviceRepository = deviceRepository;
            _devicePropertyValueRepository = devicePropertyValueRepository;
        }

        public void InsertDeviceType(DeviceType entity)
        {
            //Insert  Name | ParentType? | Description?
            // Parent Properties?
            // Insert New properties?
        }

        public void InsertDevice(Device entity)
        {
            // Parent DeviceType
            // Name | Description?
            // All Parent Properties by ParentType

        }
    }
}
