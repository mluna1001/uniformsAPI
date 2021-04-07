using System;
using System.Collections.Generic;

#nullable disable

namespace UniformsAPI.Domain.Models
{
    public partial class Employee
    {
        public Employee()
        {
            GarmentDeliveries = new HashSet<GarmentDelivery>();
        }

        public int EmployeeId { get; set; }
        public string Name { get; set; }
        public string GroupEmployeeId { get; set; }

        public virtual GroupEmployee GroupEmployee { get; set; }
        public virtual ICollection<GarmentDelivery> GarmentDeliveries { get; set; }
    }
}
