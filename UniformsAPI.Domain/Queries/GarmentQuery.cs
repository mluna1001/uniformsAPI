using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniformsAPI.Common.Models;
using UniformsAPI.Domain.Models;

namespace UniformsAPI.Domain.Queries
{
    public class GarmentQuery
    {
        public static Response Get(int employeeTypeId)
        {
            var response = new Response();

            try
            {
                using (var db = new UniformsContext())
                {
                    var lst = (from g in db.Garments
                               where g.EmployeeTypeId == employeeTypeId
                               select new
                               {
                                   g.GarmentId,
                                   g.Description
                               }).ToList();

                    if (lst != null && lst.Count > 0)
                    {
                        response.Data = lst;
                        response.Success = true;
                        response.Message = "Garments are loaded!";
                    }
                    else
                    {
                        response.Success = false;
                        response.Message = "Garments dont exist";
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

        public static Response GetSizes(int garmentId)
        {
            var response = new Response();

            try
            {
                using (var db = new UniformsContext())
                {
                    var lst = (from gs in db.GarmentSizes
                               join s in db.Sizes on gs.SizeId equals s.SizeId
                               where gs.GarmentId == garmentId
                               select new Size
                               {
                                   SizeId = s.SizeId,
                                   Description = s.Description + " - CM:" + s.Centimeters + "; US:" + s.AmericanSize + "; EU:" + s.EuropeanSize + "; MX:" + s.MexicanSize
                               }).ToList();

                    if (lst != null && lst.Count >= 0)
                    {
                        response.Data = lst;
                        response.Success = true;
                        response.Message = "Sizes are loaded";
                    }
                    else
                    {
                        response.Success = false;
                        response.Message = "Sizes not registered for this garment";
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
