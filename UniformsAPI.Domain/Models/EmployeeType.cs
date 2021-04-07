using System;
using System.Collections.Generic;

#nullable disable

namespace UniformsAPI.Domain.Models
{
    public partial class EmployeeType
    {
        public EmployeeType()
        {
            Garments = new HashSet<Garment>();
            GroupEmployees = new HashSet<GroupEmployee>();
        }

        public int EmployeeTypeId { get; set; }
        public string Description { get; set; }

        public virtual ICollection<Garment> Garments { get; set; }
        public virtual ICollection<GroupEmployee> GroupEmployees { get; set; }
    }
}
