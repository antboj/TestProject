
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using Abp.Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using TestProject.DeviceTypeAppService.Dto;
using TestProject.Models;

namespace TestProject.DeviceTypeAppService
{
    public class DeviceTypeAppService : TestProjectAppServiceBase, IDeviceTypeAppService
    {
        private readonly IRepository<DeviceType> _deviceTypeRepository;
        private readonly IRepository<DeviceTypeProperty> _deviceTypePropertyRepository;
        private readonly IRepository<Device> _deviceRepository;

        public DeviceTypeAppService(IRepository<DeviceType> deviceTypeRepository, IRepository<DeviceTypeProperty> deviceTypePropertyRepository, IRepository<Device> deviceRepository)
        {
            _deviceTypeRepository = deviceTypeRepository;
            _deviceTypePropertyRepository = deviceTypePropertyRepository;
            _deviceRepository = deviceRepository;
        }

        /// <summary>
        /// Return all DeviceTypes
        /// </summary>
        /// <param name="parentId"></param>
        /// <returns></returns>
        public List<DeviceTypeNestedDto> GetDeviceTypes(int? parentId)
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
                    Children = GetDeviceTypes(deviceType.Id)
                };

                result.Add(currentType);
            }

            return result;
        }

        /// <summary>
        /// Return all DeviceTypes include Properties
        /// </summary>
        /// <param name="deviceTypeId"></param>
        /// <returns></returns>
        public IEnumerable<DeviceTypePropertiesNestedDto> GetDeviceTypesWithProperties(int? deviceTypeId)
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


            return result.Concat(GetDeviceTypesWithProperties(allDeviceTypes.ParentId)).OrderBy(x => x.Id);
        }

        /// <summary>
        /// Insert or Update DeviceType
        /// Return all DeviceTypes
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public IEnumerable<DeviceTypePropertiesNestedDto> CreateOrUpdateDeviceType(DeviceTypeDto input)
        {
            if (input.Id == 0)
            {
                var newDeviceType = ObjectMapper.Map<DeviceType>(input);

                var lastInsertedDeviceTypeId = _deviceTypeRepository.InsertAndGetId(newDeviceType);

                var deviceTypes = GetDeviceTypesWithProperties(lastInsertedDeviceTypeId);

                return deviceTypes;
            }

            var deviceType = _deviceTypeRepository.Get(input.Id);

            ObjectMapper.Map(input, deviceType);

            var updatedDeviceTypes = GetDeviceTypesWithProperties(deviceType.Id);

            return updatedDeviceTypes;
            // Insert ili Update zavisi od Ijdija
            //DeviceType : Id = 0, ParentId, PropertiesList
            // PropertiesList : Name, Type, IsMandatory

            //Insert  Name | ParentType? | Description?
            // Parent Properties?
            // Insert New properties
        }

        /// <summary>
        /// Insert DeviceTypeProperties for new DeviceType
        /// </summary>
        /// <param name="input"></param>
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

        //public IEnumerable<GetChildrenDeviceTypesDto> GetDeviceTypeWithChildren(int parentId)
        //{
        //    var type = _deviceTypeRepository.GetAll().Include(x => x.Devices).Include(x => x.DeviceTypeProperties)
        //        .Include(x => x.DeviceTypeProperties)
        //        .First(x => x.Id == parentId);

        //    var children = _deviceTypeRepository.GetAll().Include(x => x.Devices).Include(x => x.DeviceTypeProperties)
        //        .Include(x => x.DeviceTypeProperties)
        //        .Where(x => x.ParentId == parentId).ToList();

        //    var list = new List<GetChildrenDeviceTypesDto>();

        //    if (!children.Any())
        //    {
        //        list.Add(ObjectMapper.Map<GetChildrenDeviceTypesDto>(type));
        //        return list;
        //    }

        //    foreach (var child in children)
        //    {
        //        list.AddRange(GetDeviceTypeWithChildren(child.Id));
        //    }

        //    list.Add(ObjectMapper.Map<GetChildrenDeviceTypesDto>(type));
        //    return list;

        //}

        /// <summary>
        /// Return all DeviceTypes for specific DeviceType
        /// </summary>
        /// <param name="deviceTypeId"></param>
        /// <returns></returns>
        private IEnumerable<GetChildrenDeviceTypesDto> GetDeviceTypesFlatList(int? deviceTypeId)
        {
            var type = _deviceTypeRepository.GetAll().Include(x => x.DeviceTypeProperties)
                .First(x => x.Id == deviceTypeId);

            var result = new List<GetChildrenDeviceTypesDto>();

            var currentType = new GetChildrenDeviceTypesDto
            {
                Id = type.Id,
                DeviceTypeProperties = ObjectMapper.Map<List<DeviceTypePropertyDto>>(type.DeviceTypeProperties)
            };

            if (type.ParentId == null)
            {
                result.Add(currentType);
                return result;
            }

            result.Add(currentType);

            return result.Concat(GetDeviceTypesFlatList(type.ParentId)).OrderBy(x => x.Id);
        }

        /// <summary>
        /// Return all properties for DeviceType
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        private List<DeviceTypePropertyDto> GetProperties(int id)
        {
            var allProperties = new List<DeviceTypePropertyDto>();

            var allDeviceTypes = GetDeviceTypesFlatList(id);

            foreach (var deviceType in allDeviceTypes)
            {
                foreach (var prop in deviceType.DeviceTypeProperties)
                {
                    allProperties.Add(prop);
                }
            }

            return allProperties;
        }

        /// <summary>
        /// Return All Devices
        /// </summary>
        /// <param name="typeId"></param>
        /// <returns></returns>
        public List<ExpandoObject> GetDevicesByType(int typeId)
        {
            var devices = _deviceRepository.GetAll().Include(x => x.DeviceTypeValues)
                .Where(x => x.DeviceTypeId == typeId);
            var allDevicesList = new List<ExpandoObject>();
            var allProperties = GetProperties(typeId);

            foreach (var device in devices)
            {
                IDictionary<string, object> sampleDevice = new ExpandoObject();
                sampleDevice.Add("Name", device.Name);
                sampleDevice.Add("Description", device.Description);

                foreach (var prop in allProperties)
                {
                    if (!device.DeviceTypeValues.Any())
                    {
                        sampleDevice.Add(prop.NameProperty, null);
                    }
                    foreach (var val in device.DeviceTypeValues)
                    {
                        if (val.DeviceTypePropertyId == prop.Id)
                        {
                            sampleDevice.Add(prop.NameProperty, val.Value);
                        }
                    }
                }

                allDevicesList.Add((ExpandoObject) sampleDevice);
            }
            return allDevicesList;
        }

        public void DeleteDeviceType(int id)
        {

        }
    }
}
