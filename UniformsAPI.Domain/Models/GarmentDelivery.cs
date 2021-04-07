using System;
using System.Collections.Generic;

#nullable disable

namespace UniformsAPI.Domain.Models
{
    public partial class GarmentDelivery
    {
        public int DeliveryId { get; set; }
        public int GarmentSizeId { get; set; }
        public int EmployeeId { get; set; }
        public DateTime ActionDate { get; set; }

        public virtual Employee Employee { get; set; }
        public virtual GarmentSize GarmentSize { get; set; }
    }
}
