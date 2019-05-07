using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Abp.Domain.Entities;

namespace TestProject.Models
{
    public class DeviceTypeProperty : Entity
    {
        [Required] [StringLength(255)] public string Name { get; set; }

        [ForeignKey(nameof(DeviceTypeId))] public DeviceType DeviceType { get; set; }

        public int DeviceTypeId { get; set; }

        public string Type { get; set; }

        public bool IsMandatory { get; set; }

        public string MachineKey { get; set; }
    }
}