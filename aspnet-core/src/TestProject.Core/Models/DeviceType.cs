﻿using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Abp.Domain.Entities;
using JetBrains.Annotations;

namespace TestProject.Models
{
    public class DeviceType : Entity
    {
        [Required] [StringLength(255)] public string Name { get; set; }

        public string Description { get; set; }

        [CanBeNull]
        [ForeignKey(nameof(ParentId))]
        public DeviceType ParentDeviceType { get; set; }

        public int? ParentId { get; set; }

        public List<Device> Devices { get; set; } = new List<Device>();
        public List<DeviceTypeProperty> DeviceTypeProperties { get; set; } = new List<DeviceTypeProperty>();
    }
}