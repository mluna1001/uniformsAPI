using System;
using System.Collections.Generic;

#nullable disable

namespace UniformsAPI.Domain.Models
{
    public partial class GarmentSize
    {
        public GarmentSize()
        {
            GarmentDeliveries = new HashSet<GarmentDelivery>();
            Inventories = new HashSet<Inventory>();
        }

        public int GarmentSizeId { get; set; }
        public int GarmentId { get; set; }
        public int SizeId { get; set; }
        public int MaxElements { get; set; }

        public virtual Garment Garment { get; set; }
        public virtual ICollection<GarmentDelivery> GarmentDeliveries { get; set; }
        public virtual ICollection<Inventory> Inventories { get; set; }
    }
}
