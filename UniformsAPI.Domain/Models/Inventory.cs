using System;
using System.Collections.Generic;

#nullable disable

namespace UniformsAPI.Domain.Models
{
    public partial class Inventory
    {
        public int InventoryId { get; set; }
        public int GarmentSizeId { get; set; }
        public int TotalInventory { get; set; }

        public virtual GarmentSize GarmentSize { get; set; }
    }
}
