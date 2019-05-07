using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Abp.Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using TestProject.DeviceAppService.Dto;
using TestProject.Models;
using TestProject.QueryInfoService;

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
        
        /// <summary>
        /// Create or update Device
        /// </summary>
        /// <param name="input"></param>
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

        /// <summary>
        /// Search
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public List<DeviceDto> QueryInfoSearch(QueryInfo input)
        {
            var obj = new QueryInfo();
            var skipNum = input.Skip;
            var takeNum = input.Take;
            var query = _deviceRepository.GetAll();
            var sorters = input.Sorters;
            var rules = input.Filter.Rules;
            var condition = input.Filter.Condition;
            var parameterEx = Expression.Parameter(typeof(Device), "x");
            Expression containsExpression = Expression.Constant(false);
            Expression currentContainsExpression;
            Expression result;
            foreach (var property in input.SearchProperties)
            {
                currentContainsExpression = obj.GetBinaryExpression(parameterEx, "ct", property, input.SearchText);
                containsExpression = Expression.OrElse(containsExpression,currentContainsExpression);
            }
            result = obj.GetFilteredList<Device>(parameterEx, rules, condition);
            result = Expression.AndAlso(containsExpression, result);
            
            var whereEx = obj.GetWhere<Device>(result, parameterEx);

            query = query.Where(whereEx);

            var sortedFirst = false;
            foreach (var sort in sorters)
            {
                var sortProperty = sort.Property;
                var sortDirection = sort.Direction;

                switch (sortDirection)
                {
                    case "asc":
                        if (!sortedFirst)
                        {
                            query = query.OrderBy(obj.GetOrderByExpression<Device>(sortProperty));
                            sortedFirst = true;
                        }
                        else
                        {
                            query = ((IOrderedQueryable<Device>)query).ThenBy(obj.GetOrderByExpression<Device>(sortProperty));
                        }
                        break;
                    case "desc":
                        if (!sortedFirst)
                        {
                            query = query.OrderByDescending(obj.GetOrderByExpression<Device>(sortProperty));
                            sortedFirst = true;
                        }
                        else
                        {
                            query = ((IOrderedQueryable<Device>)query).ThenByDescending(obj.GetOrderByExpression<Device>(sortProperty));
                        }
                        break;
                    default:
                        throw new InvalidOperationException();
                }
            }
            query = query.Skip(skipNum).Take(takeNum);
            var queryToReturn  = ObjectMapper.Map<List<DeviceDto>>(query);
            return queryToReturn.ToList();
        }
    }
}
