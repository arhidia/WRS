using Grapevine.Interfaces.Server;
using Grapevine.Server;
using System;
using System.Collections.Generic;
using System.Linq;
using WashingtonRedskins.Models;
using Newtonsoft.Json;
using WashingtonRedskins.Validation;
using WashingtonRedskins.Extensions;
using Grapevine.Shared;

namespace WashingtonRedskins.Controllers
{
    public static class RegistrationController
    {
        public static IHttpContext registrationCreate(IHttpContext context)
        {
            try
            {
                var data = Parsers.parseURLEncoded(context.Request.Payload);

                if (context.token().SID() != uint.Parse(data["UserId"]))
                {
                    if (!context.token().hasPermission("registrations.write"))
                    {
                        context.Response.StatusCode = HttpStatusCode.NotFound;
                        context.Response.SendResponse("");
                        return context;
                    }
                }
                else
                {
                    if (!context.token().hasPermission("registrations.self.write") && !context.token().hasPermission("registrations.write"))
                    {
                        context.Response.StatusCode = HttpStatusCode.NotFound;
                        context.Response.SendResponse("");
                        return context;
                    }
                }

                Registrations.add(uint.Parse(data["UserId"]), uint.Parse(data["StatusId"]));
                context.Response.SendResponse("");
            }
            catch (Exception ex)
            {
                context.Response.StatusCode = HttpStatusCode.InternalServerError;
                context.Response.SendResponse(ex.Message);
            }

            return context;
        }
        public static IHttpContext registrationGet(IHttpContext context, string regId)
        {
            try
            {
                if (!context.token().hasPermission("registrations.read"))
                {
                    context.Response.StatusCode = HttpStatusCode.NotFound;
                    context.Response.SendResponse("");
                    return context;
                }

                var data = context.Request.QueryString;
                var reg = Registrations.get(uint.Parse(regId));
                context.Response.SendResponse(JsonConvert.SerializeObject(reg));
            }
            catch (Exception ex)
            {
                context.Response.StatusCode = HttpStatusCode.InternalServerError;
                context.Response.SendResponse(ex.Message);
            }
            return context;
        }
        public static IHttpContext registrationList(IHttpContext context)
        {
            try
            {
                if (!context.token().hasPermission("registrations.read"))
                {
                    context.Response.StatusCode = HttpStatusCode.NotFound;
                    context.Response.SendResponse("");
                    return context;
                }
                var data = context.Request.QueryString;
             
                DateTime start = data["start_time"] != null ? DateTime.Parse(data["start_time"]) : DateTime.Parse("1970-01-01 00:00:00");

                int pageSize = data["pagesize"] != null ? int.Parse(data["pagesize"]) : 50;
                int skip = data["skip"] != null ? int.Parse(data["skip"]) : 0;
                uint userId = data["usergroup_id"] != null ? uint.Parse(data["user_id"]) : 0;

                var regs = Registrations.list(start, pageSize, skip, userId);

                context.Response.SendResponse(JsonConvert.SerializeObject(regs));
            }
            catch (Exception ex)
            {
                context.Response.StatusCode = HttpStatusCode.InternalServerError;
                context.Response.SendResponse(ex.Message);
            }
            return context;
        }
        public static IHttpContext registrationGetByUser(IHttpContext context)
        {
            try
            {
                uint userId = uint.Parse(context.Request.QueryString["userID"]);

                List<Registrations> regs;

                using (var dbContext = new WashingtonRedskinsContext())
                {
                    regs = dbContext.Registrations.Where(r => r.UserId == userId).ToList();
                }

                context.Response.SendResponse(JsonConvert.SerializeObject(regs));
            }
            catch (Exception ex)
            {
                context.Response.SendResponse(ex.Message);
                context.Response.StatusCode = HttpStatusCode.InternalServerError;
            }
            return context;
        }
        public static IHttpContext registrationDelete(IHttpContext context, string regId)
        {
            try
            {
                if (!context.token().hasPermission("registrations.delete"))
                {
                    context.Response.StatusCode = HttpStatusCode.NotFound;
                    context.Response.SendResponse("");
                    return context;
                }
                var data = Parsers.parseURLEncoded(context.Request.Payload);

                Registrations.delete(uint.Parse(regId));
                context.Response.SendResponse("");
            }
            catch (Exception ex)
            {
                context.Response.SendResponse(ex.Message);
                context.Response.StatusCode = HttpStatusCode.InternalServerError;
            }
            return context;
        }

        public static IHttpContext registrationEdit(IHttpContext context, string regId)
        {
            try
            {
                if (!context.token().hasPermission("registrations.write"))
                {
                    context.Response.StatusCode = HttpStatusCode.NotFound;
                    context.Response.SendResponse("");
                    return context;
                }

                var valBuilder = new ValidationBuilder();
                string[] valArray =
                {
                "name=Id,isRequired=,isNumeric=",
                "name=Time,isRequired=,isDateTime=",
                "name=UserId,isRequired=",
                "name=DepartmentId,isRequired=",
                "name=StatusId,isRequired="
            };
                var collection = valBuilder.build(valArray);

                var reg = BaseController.getUserInput<Registrations>(context, collection);

                Registrations.edit(reg, uint.Parse(regId));

                var data = Parsers.parseURLEncoded(context.Request.Payload);
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
