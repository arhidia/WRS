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
    class BreakController
    {
        public IHttpContext breakCreate(IHttpContext context)
        {
            try
            {
                if (!context.token().hasPermission("breaks.write"))
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
                var brk = BaseController.getUserInput<Breaks>(context, valCollection);
                brk.add();
                context.Response.SendResponse("");
            }
            catch (Exception ex)
            {
                context.Response.StatusCode = HttpStatusCode.InternalServerError;
                context.Response.SendResponse(ex.Message);
            }
            return context;
        }
        public IHttpContext breakGet(IHttpContext context,string breakId)
        {
            try
            {

                if (!context.token().hasPermission("breaks.read"))
                {
                    context.Response.StatusCode = HttpStatusCode.NotFound;
                    context.Response.SendResponse("");
                    return context;
                }
                Breaks brk = Breaks.get(uint.Parse(breakId));

                context.Response.SendResponse(JsonConvert.SerializeObject(brk));

            }
            catch (Exception ex)
            {
                context.Response.StatusCode = HttpStatusCode.InternalServerError;
                context.Response.SendResponse(ex.Message);
            }
            return context;
        }

        public IHttpContext breakList(IHttpContext context)
        {
            try
            {
                if (!context.token().hasPermission("breaks.read"))
                {
                    context.Response.StatusCode = HttpStatusCode.NotFound;
                    context.Response.SendResponse("");
                    return context;
                }
                var data = context.Request.QueryString;

                int pageSize = data["pagesize"] != null ? int.Parse(data["pagesize"]) : 0;
                int skip = data["skip"] != null ? int.Parse(data["skip"]) : 0;

                var breaks = Breaks.list(pageSize, skip);

                context.Response.SendResponse(JsonConvert.SerializeObject(breaks));
            }
            catch (Exception ex)
            {
                context.Response.StatusCode = HttpStatusCode.InternalServerError;
                context.Response.SendResponse(ex.Message);
            }
            return context;
        }

        public IHttpContext breakEdit(IHttpContext context,string breakId)
        {
            try
            {
                if (!context.token().hasPermission("breaks.write"))
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
                Breaks brk = BaseController.getUserInput<Breaks>(context, valCollection);
                brk.Id = uint.Parse(breakId);
                Breaks.edit(brk.Id, brk);

                context.Response.SendResponse("");
            }
            catch (Exception ex)
            {
                context.Response.StatusCode = HttpStatusCode.InternalServerError;
                context.Response.SendResponse(ex.Message);
            }

            return context;
        }

        public IHttpContext breakDelete(IHttpContext context, string breakId)
        {
            try
            {
                if (!context.token().hasPermission("breaks.write"))
                {
                    context.Response.StatusCode = HttpStatusCode.NotFound;
                    context.Response.SendResponse("");
                    return context;
                }
                Breaks.delete(uint.Parse(breakId));
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
