using System.Collections.Generic;
using System.Linq;
using Abp.Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using TestProject.DeviceAppService;
using TestProject.DeviceTypeAppService.Dto;
using TestProject.Models;

namespace TestProject.DeviceTypeAppService
{
    public class DeviceTypeAppService : TestProjectAppServiceBase, IDeviceTypeAppService
    {
        private readonly IRepository<DeviceType> _deviceTypeRepository;
        private readonly IRepository<DeviceTypeProperty> _deviceTypePropertyRepository;

        public DeviceTypeAppService(IRepository<DeviceType> deviceTypeRepository, IRepository<DeviceTypeProperty> deviceTypePropertyRepository)
        {
            _deviceTypeRepository = deviceTypeRepository;
            _deviceTypePropertyRepository = deviceTypePropertyRepository;
        }

        public List<DeviceTypeNestedDto> GetAllDeviceTypesNested(int? parentId)
        {
            var baseDeviceTypes = _deviceTypeRepository.GetAll()
                .Where(x => x.ParentId == parentId).ToList();

            var result = new List<DeviceTypeNestedDto>();

            foreach (var deviceType in baseDeviceTypes)
            {
                var currentType = new DeviceTypeNestedDto
                {
                    Id = deviceType.Id,
                    Name = deviceType.Name,
                    Description = deviceType.Description,
                    ParentId = deviceType.ParentId,
                    Children = GetAllDeviceTypesNested(deviceType.Id)
                };

                result.Add(currentType);
            }

            return result;
        }

        public IEnumerable<DeviceTypePropertiesNestedDto> GetAllDeviceTypesPropertiesNested(int? deviceTypeId)
        {
            var allDeviceTypes = _deviceTypeRepository.GetAll().Include(x => x.DeviceTypeProperties)
                .First(x => x.Id == deviceTypeId);

            var result = new List<DeviceTypePropertiesNestedDto>();

            var currentType = new DeviceTypePropertiesNestedDto()
            {
                Id = allDeviceTypes.Id,
                Name = allDeviceTypes.Name,
                Description = allDeviceTypes.Description,
                ParentId = allDeviceTypes.ParentId,
                Properties = ObjectMapper.Map<List<DeviceTypePropertyDto>>(allDeviceTypes.DeviceTypeProperties)
            };

            if (allDeviceTypes.ParentId == null)
            {
                result.Add(currentType);
                return result;
            }

            result.Add(currentType);


            return result.Concat(GetAllDeviceTypesPropertiesNested(allDeviceTypes.ParentId)).OrderBy(x => x.Id);
        }

        public IEnumerable<DeviceTypePropertiesNestedDto> InsertOrUpdateDeviceType(DeviceTypeDto input)
        {
            if (input.Id == 0)
            {
                DeviceType newDeviceType = ObjectMapper.Map<DeviceType>(input);

                var lastInsertedDeviceTypeid = _deviceTypeRepository.InsertAndGetId(newDeviceType);

                var deviceTypes = GetAllDeviceTypesPropertiesNested(lastInsertedDeviceTypeid);

                return deviceTypes;
            }

            var deviceType = _deviceTypeRepository.Get(input.Id);

            ObjectMapper.Map(input, deviceType);

            var updatedDeviceTypes = GetAllDeviceTypesPropertiesNested(deviceType.Id);

            return updatedDeviceTypes;
            // Insert ili Update zavisi od Ijdija
            //DeviceType : Id = 0, ParentId, PropertiesList
            // PropertiesList : Name, Type, IsMandatory

            //Insert  Name | ParentType? | Description?
            // Parent Properties?
            // Insert New properties
        }

        public void CreateDeviceTypeProperties(DeviceTypePropertiesCreateDto input)
        {
            var deviceType = _deviceTypeRepository.GetAll().Include(x => x.DeviceTypeProperties)
                .First(x => x.Id == input.Id);

            foreach (var property in input.Properties)
            {
                _deviceTypePropertyRepository.Insert(new DeviceTypeProperty
                {
                    Name = property.NameProperty,
                    IsMandatory = property.Required,
                    Type = property.Type,
                    DeviceTypeId = deviceType.Id
                });
            }
        }
    }
}
