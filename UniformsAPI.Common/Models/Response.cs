using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniformsAPI.Common.Models
{
    public class Response
    {
        public object Data { get; set; }
        public bool Success { get; set; }
        public Exception exception { get; set; }
        public string Message { get; set; }

    }
}
