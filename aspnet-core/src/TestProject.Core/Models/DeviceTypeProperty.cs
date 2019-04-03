using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using Abp.Domain.Entities;

namespace TestProject.Models
{
    public class DeviceTypeProperty : Entity
    {
        [StringLength(255)]
        public string Name { get; set; }

        [ForeignKey(nameof(DeviceTypeId))]
        public DeviceType DeviceType { get; set; }
        public int DeviceTypeId { get; set; }

        public bool IsMandatory { get; set; }


    }
}
