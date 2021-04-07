using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UniformsAPI.Common.Models;
using UniformsAPI.Domain.Queries;

namespace UniformsAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GarmentController : ControllerBase
    {
        [HttpGet]
        public Response Get(int employeeTypeId)
        {
            var response = GarmentQuery.Get(employeeTypeId);
            return response;
        }

        [HttpGet("[action]")]
        public Response GetSizes(int garmentId)
        {
            var response = GarmentQuery.GetSizes(garmentId);
            return response;
        }
    }
}
