using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using UniformsAPI.Common.Models;
using UniformsAPI.Domain.Models;

namespace UniformsAPI.Domain.Queries
{
    public class GarmentDeliveryQuery
    {
        public static Response Get()
        {
            var response = new Response();

            try
            {
                using (var db = new UniformsContext())
                {
                    var lst = db.VwdeliverStatuses.ToList();
                    if (lst != null && lst.Count > 0)
                    {
                        response.Data = lst;
                        response.Success = true;
                        response.Message = "Data loaded!";
                    }
                    else
                    {
                        response.Data = lst;
                        response.Success = false;
                        response.Message = "No information";
                    }
                }
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message;
                response.exception = ex;
            }

            return response;
        }

        public static Response SaveDelivery(GarmentDelivery delivery)
        {
            var response = new Response();

            try
            {
                using (var db = new UniformsContext())
                {
                    var storeResponse = db.StoreResponse.FromSqlRaw($"usp_GarmentDelivery_CreateDeliver { delivery.GarmentSizeId }, { delivery.EmployeeId }").ToList();
                    if (storeResponse != null)
                    {
                        var element = storeResponse.FirstOrDefault();
                        if (element.Status == 1)
                        {
                            response.Success = true;
                            response.Message = element.Message;
                        }
                        else
                        {
                            response.Success = false;
                            response.Message = element.Message;
                        }
                    }
                    else
                    {
                        response.Success = false;
                    }
                }
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message;
                response.exception = ex;
            }

            return response;
        }

    }
}
