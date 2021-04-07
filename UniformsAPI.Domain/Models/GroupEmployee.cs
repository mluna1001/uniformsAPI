using System;
using System.Collections.Generic;

#nullable disable

namespace UniformsAPI.Domain.Models
{
    public partial class GroupEmployee
    {
        public GroupEmployee()
        {
            Employees = new HashSet<Employee>();
        }

        public string GroupEmployeeId { get; set; }
        public string Description { get; set; }
        public int EmployeeTypeId { get; set; }

        public virtual EmployeeType EmployeeType { get; set; }
        public virtual ICollection<Employee> Employees { get; set; }
    }
}
