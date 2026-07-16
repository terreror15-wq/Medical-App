using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MedicalApp.Domain.Core;

namespace MedicalApp.Domain.Entities
{
    public class MedicalOffice : BaseEntity
    {
        public string Numero { get; set; } = string.Empty;
        public string? Piso { get; set; }
        public string? Descripcion { get; set; }
        //public ICollection<Cita> Citas { get; set; } = new List<Cita>();
    }
}