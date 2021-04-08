using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniformsAPI.Common.Models;
using UniformsAPI.Domain.Models;

namespace UniformsAPI.Domain.Queries
{
    public class EmployeeQuery
    {
        public static Response Get()
        {
            var response = new Response();

            try
            {
                using (var db = new UniformsContext())
                {
                    var lst = (from e in db.Employees
                               join g in db.GroupEmployees on e.GroupEmployeeId equals g.GroupEmployeeId
                               join et in db.EmployeeTypes on g.EmployeeTypeId equals et.EmployeeTypeId
                               select new 
                                {
                                    EmployeeId = e.EmployeeId,
                                    Name = $"{ e.EmployeeId } - { e.Name }",
                                    EmployeeTypeId = et.EmployeeTypeId
                                }).ToList();
                    if (lst != null && lst.Count > 0)
                    {
                        response.Data = lst;
                        response.Success = true;
                        response.Message = "Employees are loaded";
                    }
                    else
                    {
                        response.Message = "Employees not exists";
                        response.Success = false;
                    }
                }
            }
            catch (Exception ex)
            {
                response.exception = ex;
                response.Message = ex.Message;
                response.Success = false;
            }

            return response;
        }
    }
}
