﻿using System.ComponentModel.DataAnnotations.Schema;
using Abp.Domain.Entities;

namespace TestProject.Models
{
    public class DevicePropertyValue : Entity
    {
        [ForeignKey(nameof(DeviceTypePropertyId))]
        public DeviceTypeProperty DeviceTypeProperty { get; set; }

        public int DeviceTypePropertyId { get; set; }

        [ForeignKey(nameof(DeviceId))] public Device Device { get; set; }

        public int DeviceId { get; set; }

        public string Value { get; set; }
    }
}