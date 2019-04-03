﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using Abp.Domain.Entities;

namespace TestProject.Models
{
    public class Device : Entity
    {
        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        public string Description { get; set; }

        [ForeignKey(nameof(DeviceTypeId))]
        public DeviceType DeviceType { get; set; }

        public int DeviceTypeId { get; set; }

        public List<DeviceTypeProperty> DeviceTypeProperties { get; set; }
        public List<DevicePropertyValue> DeviceTypeValues { get; set; }
    }
}
