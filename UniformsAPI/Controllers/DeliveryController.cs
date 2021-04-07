using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UniformsAPI.Common.Models;
using UniformsAPI.Domain.Models;
using UniformsAPI.Domain.Queries;

namespace UniformsAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DeliveryController : ControllerBase
    {
        [HttpGet]
        public Response Get()
        {
            var response = GarmentDeliveryQuery.Get();
            return response;
        }

        [HttpPost]
        public Response SaveDelivery([FromBody] GarmentDelivery garment)
        {
            var response = GarmentDeliveryQuery.SaveDelivery(garment);
            return response;
        } 
    }
}
