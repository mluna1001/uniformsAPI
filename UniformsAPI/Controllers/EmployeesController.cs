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
    public class EmployeesController : ControllerBase
    {
        [HttpGet]
        public Response Get()
        {
            var response = EmployeeQuery.Get();
            return response;
        }
    }
}
