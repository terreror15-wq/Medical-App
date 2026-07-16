using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MedicalApp.Domain.Core;

namespace MedicalApp.Domain.Entities
{
    public class MedicalOffice : BaseEntity
    {
        public string DoorNumber { get; set; } = string.Empty;
        public string? Floor { get; set; }
        public string? Descripcion { get; set; }
        public ICollection<Appointment> Citas { get; set; } = new List<Appointment>();
    }
}