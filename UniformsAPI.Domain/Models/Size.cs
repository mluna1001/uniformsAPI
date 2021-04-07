using System;
using System.Collections.Generic;

#nullable disable

namespace UniformsAPI.Domain.Models
{
    public partial class Size
    {
        public int SizeId { get; set; }
        public string Description { get; set; }
        public double Centimeters { get; set; }
        public double? AmericanSize { get; set; }
        public double? EuropeanSize { get; set; }
        public double? MexicanSize { get; set; }
    }
}
