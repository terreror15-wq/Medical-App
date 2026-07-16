using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MedicalApp.Domain.Core;

namespace MedicalApp.Domain.Entities
{
    public class Specialy : BaseEntity
    {
        public string? Name { get; set; }
        public string? Description { get; set; }

        // public ICollection<Doctor> Doctores { get; set; } = new List<Doctor>();

    }
}