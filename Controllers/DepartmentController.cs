using Grapevine.Interfaces.Server;
using Grapevine.Server;
using Grapevine.Shared;
using Newtonsoft.Json;
using System;
using WashingtonRedskins.Extensions;
using WashingtonRedskins.Models;
using WashingtonRedskins.Validation;

namespace WashingtonRedskins.Controllers
{
    class DepartmentController
    {
        public static IHttpContext departmentGet(IHttpContext context, string id)
        {
            try
            {
                if (!context.token().hasPermission("departments.read"))
                {
                    context.Response.StatusCode = HttpStatusCode.NotFound;
                    context.Response.SendResponse("");
                    return context;
                }
                var dept = Departments.get(uint.Parse(id));
                context.Response.SendResponse(JsonConvert.SerializeObject(dept));
            }
            catch (Exception ex)
            {
                context.Response.StatusCode = HttpStatusCode.InternalServerError;
                context.Response.SendResponse(ex.Message);
            }
            return context;
        }
        public static IHttpContext departmentList(IHttpContext context, string id)
        {
            try
            {
                if (!context.token().hasPermission("departments.read"))
                {
                    context.Response.StatusCode = HttpStatusCode.NotFound;
                    context.Response.SendResponse("");
                    return context;
                }
                var data = context.Request.QueryString;

                int pageSize = data["pagesize"] != null ? int.Parse(data["pagesize"]) : 0;
                int skip = data["skip"] != null ? int.Parse(data["skip"]) : 0;


                var dept = Departments.list(pageSize, skip);
                context.Response.SendResponse(JsonConvert.SerializeObject(dept));
            }
            catch (Exception ex)
            {
                context.Response.StatusCode = HttpStatusCode.InternalServerError;
                context.Response.SendResponse(ex.Message);
            }
            return context;
        }
        public static IHttpContext departmentCreate(IHttpContext context)
        {
            try
            {
                if (!context.token().hasPermission("departments.write"))
                {
                    context.Response.StatusCode = HttpStatusCode.NotFound;
                    context.Response.SendResponse("");
                    return context;
                }

                var builder = new ValidationBuilder();

                string[] valArray =
                {
                    "name=Name,isRequired="
                };

                var valTemplate = builder.build(valArray);
                var department = BaseController.getUserInput<Departments>(context, valTemplate);
                department.add();
            }
            catch (Exception ex)
            {
                context.Response.SendResponse(ex.Message);
                context.Response.StatusCode = HttpStatusCode.InternalServerError;
            }
            return context;
        }
        public static IHttpContext departmentEdit(IHttpContext context, string id)
        {
            try
            {
                if (!context.token().hasPermission("departments.write"))
                {
                    context.Response.StatusCode = HttpStatusCode.NotFound;
                    context.Response.SendResponse("");
                    return context;
                }

                var builder = new ValidationBuilder();

                string[] valArray =
                {
                    "name=Name,isRequired="
                };

                var valTemplate = builder.build(valArray);
                var department = BaseController.getUserInput<Departments>(context, valTemplate);
                department.Id = uint.Parse(id);
                Departments.edit(department.Id, department);
            }
            catch (Exception ex)
            {
                context.Response.SendResponse(ex.Message);
                context.Response.StatusCode = HttpStatusCode.InternalServerError;
            }
            return context;
        }

        public static IHttpContext departmentDelete(IHttpContext context, string id)
        {
            try
            {
                if (!context.token().hasPermission("departments.write"))
                {
                    context.Response.StatusCode = HttpStatusCode.NotFound;
                    context.Response.SendResponse("");
                    return context;
                }

                Departments.delete(uint.Parse(id));
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
