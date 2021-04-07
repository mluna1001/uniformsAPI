using System;
using System.Collections.Generic;

#nullable disable

namespace UniformsAPI.Domain.Models
{
    public partial class VwdeliverStatus
    {
        public int DeliveryId { get; set; }
        public int EmployeeId { get; set; }
        public string Name { get; set; }
        public string Group { get; set; }
        public string Garment { get; set; }
        public string DeliverSize { get; set; }
        public DateTime DeliveryDate { get; set; }
    }
}
