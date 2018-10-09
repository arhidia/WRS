using Grapevine.Interfaces.Server;
using Grapevine.Server;
using Grapevine.Shared;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using WashingtonRedskins.Extensions;
using WashingtonRedskins.Models;
using WashingtonRedskins.Validation;

namespace WashingtonRedskins.Controllers
{
    class WorkHourController
    {
        public IHttpContext workhourCreate(IHttpContext context)
        {
            try
            {
                if (!context.token().hasPermission("workhour.write"))
                {
                    context.Response.StatusCode = HttpStatusCode.NotFound;
                    context.Response.SendResponse("");
                    return context;
                }

                ValidationBuilder valBuilder = new ValidationBuilder();
                ValidationCollection valCollection;
                string[] valArray =
                {
                    "name=StartTime, isRequired=,isTime=",
                    "name=EndTime, isRequired=,isTime=",
                 };

                valCollection = valBuilder.build(valArray);
                var wrkhour = BaseController.getUserInput<WorkHours>(context, valCollection);
                wrkhour.add();
                context.Response.SendResponse("");
            }
            catch (Exception ex)
            {
                context.Response.StatusCode = HttpStatusCode.InternalServerError;
                context.Response.SendResponse(ex.Message);
            }
            return context;
        }
        public IHttpContext workhourGet(IHttpContext context,string workhourId)
        {
            try
            {

                if (!context.token().hasPermission("workhour.read"))
                {
                    context.Response.StatusCode = HttpStatusCode.NotFound;
                    context.Response.SendResponse("");
                    return context;
                }
                WorkHours wrkhrs = WorkHours.get(uint.Parse(workhourId));

                context.Response.SendResponse(JsonConvert.SerializeObject(wrkhrs));

            }
            catch (Exception ex)
            {
                context.Response.StatusCode = HttpStatusCode.InternalServerError;
                context.Response.SendResponse(ex.Message);
            }
            return context;
        }

        public IHttpContext workhourList(IHttpContext context)
        {
            try
            {
                if (!context.token().hasPermission("workhour.read"))
                {
                    context.Response.StatusCode = HttpStatusCode.NotFound;
                    context.Response.SendResponse("");
                    return context;
                }
                var data = context.Request.QueryString;
                
                var workhours = WorkHours.list();

                context.Response.SendResponse(JsonConvert.SerializeObject(workhours));
            }
            catch (Exception ex)
            {
                context.Response.StatusCode = HttpStatusCode.InternalServerError;
                context.Response.SendResponse(ex.Message);
            }
            return context;
        }

        public IHttpContext workhourEdit(IHttpContext context,string workhourId)
        {
            try
            {
                if (!context.token().hasPermission("workhour.write"))
                {
                    context.Response.StatusCode = HttpStatusCode.NotFound;
                    context.Response.SendResponse("");
                    return context;
                }
                ValidationBuilder valBuilder = new ValidationBuilder();
                ValidationCollection valCollection;
                string[] valArray =
                {
                    "name=StartTime, isRequired=,isTime=",
                    "name=EndTime, isRequired=,isTime=",
                };

                valCollection = valBuilder.build(valArray);
                WorkHours workhour = BaseController.getUserInput<WorkHours>(context, valCollection);
                workhour.Id = uint.Parse(workhourId);
                WorkHours.edit(uint.Parse(context.Request.PathParameters["id"]), workhour);
                context.Response.SendResponse("");
            }
            catch (Exception ex)
            {
                context.Response.StatusCode = HttpStatusCode.InternalServerError;
                context.Response.SendResponse(ex.Message);
            }

            return context;
        }

        public IHttpContext workhourDelete(IHttpContext context, string workhourId)
        {
            try
            {
                if (!context.token().hasPermission("workhour.write"))
                {
                    context.Response.StatusCode = HttpStatusCode.NotFound;
                    context.Response.SendResponse("");
                    return context;
                }
                WorkHours.delete(uint.Parse(workhourId));
                context.Response.SendResponse("");
            }
            catch (Exception ex)
            {
                context.Response.StatusCode = HttpStatusCode.InternalServerError;
                context.Response.SendResponse(ex.Message);
            }
            return context;
        }
    }
}
