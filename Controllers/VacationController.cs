using Grapevine.Interfaces.Server;
using Grapevine.Server;
using Grapevine.Shared;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;
using System.Globalization;
using WashingtonRedskins.Extensions;
using WashingtonRedskins.Models;
using WashingtonRedskins.Validation;

namespace WashingtonRedskins.Controllers
{
    class VacationController
    {
        public static IHttpContext vacationCreate(IHttpContext context)
        {
            try
            {
                ValidationBuilder valBuilder = new ValidationBuilder();
                ValidationCollection valCollection;

                string[] valArray =
                {
                "name=Start,isRequired=,isDateTime=",
                "name=End,isRequired=,isDateTime=",
                "name=Name"
            };

                valCollection = valBuilder.build(valArray);
                var vac = BaseController.getUserInput<Vacations>(context, valCollection);
                vac.add();
                context.Response.SendResponse("");

            }
            catch (Exception ex)
            {
                context.Response.StatusCode = HttpStatusCode.InternalServerError;
                context.Response.SendResponse(ex.Message);
            }

            return context;
        }
        public static IHttpContext vacationGet(IHttpContext context, string id)
        {
            try
            {
                var vac = Vacations.get(uint.Parse(id));
                context.Response.SendResponse(JsonConvert.SerializeObject(vac));
            }
            catch (Exception ex)
            {
                context.Response.StatusCode = HttpStatusCode.InternalServerError;
                context.Response.SendResponse(ex.Message);
            }
            return context;
        }
        public static IHttpContext vacationList(IHttpContext context)
        {
            try
            {
                var data = context.Request.QueryString;

                int pageSize = data["pagesize"] != null ? int.Parse(data["pagesize"]) : 0;
                int skip = data["skip"] != null ? int.Parse(data["skip"]) : 0;

                var vacations = Vacations.list(pageSize, skip);

                context.Response.SendResponse(JsonConvert.SerializeObject(vacations));
            }
            catch (Exception ex)
            {
                context.Response.StatusCode = HttpStatusCode.InternalServerError;
                context.Response.SendResponse(ex.Message);
            }
            return context;
        }
        public static IHttpContext vacationEdit(IHttpContext context, string id)
        {
            try
            {
                ValidationBuilder valBuilder = new ValidationBuilder();
                ValidationCollection valCollection;
                string[] valArray =
                {
                "name=Start,isRequired=,isDateTime=",
                "name=End,isRequired=,isDateTime=",
            };

                valCollection = valBuilder.build(valArray);
                Vacations vac = BaseController.getUserInput<Vacations>(context, valCollection);
                vac.Id = uint.Parse(id);
                Vacations.edit(vac.Id, vac);

                context.Response.SendResponse("");
            }
            catch (Exception ex)
            {
                context.Response.StatusCode = HttpStatusCode.InternalServerError;
                context.Response.SendResponse(ex.Message);
            }
            return context;
        }
        public static IHttpContext vacationDelete(IHttpContext context, string id)
        {
            try
            {
                Vacations.delete(uint.Parse(id));
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
