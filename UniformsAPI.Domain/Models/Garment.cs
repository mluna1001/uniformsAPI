using System;
using System.Collections.Generic;

#nullable disable

namespace UniformsAPI.Domain.Models
{
    public partial class Garment
    {
        public Garment()
        {
            GarmentSizes = new HashSet<GarmentSize>();
        }

        public int GarmentId { get; set; }
        public string Description { get; set; }
        public int EmployeeTypeId { get; set; }

        public virtual EmployeeType EmployeeType { get; set; }
        public virtual ICollection<GarmentSize> GarmentSizes { get; set; }
    }
}
