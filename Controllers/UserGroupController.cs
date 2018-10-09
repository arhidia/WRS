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
    class UserGroupController
    {
        public static IHttpContext userGroupGet(IHttpContext context, string id)
        {
            try
            {
                if (!context.token().hasPermission("usergroups.read"))
                {
                    context.Response.StatusCode = HttpStatusCode.NotFound;
                    context.Response.SendResponse("");
                    return context;
                }

                var usrGrp = UserGroup.get(uint.Parse(id));

                context.Response.SendResponse(JsonConvert.SerializeObject(usrGrp));
            }
            catch (Exception ex)
            {
                context.Response.StatusCode = HttpStatusCode.InternalServerError;
                context.Response.SendResponse(ex.Message);
            }
            return context;
        }

        public static IHttpContext userGroupList(IHttpContext context)
        {
            try
            {
                if (!context.token().hasPermission("usergroups.read"))
                {
                    context.Response.StatusCode = HttpStatusCode.NotFound;
                    context.Response.SendResponse("");
                    return context;
                }

                var data = context.Request.QueryString;

                int pageSize = data["pagesize"] != null ? int.Parse(data["pagesize"]) : 0;
                int skip = data["skip"] != null ? int.Parse(data["skip"]) : 0;


                var userGroup = UserGroup.list(pageSize, skip);
                context.Response.SendResponse(JsonConvert.SerializeObject(userGroup));
            }
            catch (Exception ex)
            {
                context.Response.StatusCode = HttpStatusCode.InternalServerError;
                context.Response.SendResponse(ex.Message);
            }
            return context;
        }

        public static IHttpContext userGroupCreate(IHttpContext context)
        {
            try
            {
                if (!context.token().hasPermission("usergroups.write"))
                {
                    context.Response.StatusCode = HttpStatusCode.NotFound;
                    context.Response.SendResponse("");
                    return context;
                }
                string[] valArray =
{
                    "name=Name,isRequired="
                };
                var builder = new ValidationBuilder();

                var valTemplate = builder.build(valArray);
                var userGroup = BaseController.getUserInput<UserGroup>(context, valTemplate);
                userGroup.add();
                context.Response.SendResponse("");
            }
            catch (Exception ex)
            {
                context.Response.SendResponse(ex.Message);
                context.Response.StatusCode = HttpStatusCode.InternalServerError;
            }
            return context;
        }

        public static IHttpContext userGroupEdit(IHttpContext context, string id)
        {
            try
            {
                if (!context.token().hasPermission("usergroups.write"))
                {
                    context.Response.StatusCode = HttpStatusCode.NotFound;
                    context.Response.SendResponse("");
                    return context;
                }

                string[] valArray =
{
                    "name=Name,isRequired="
                };
                var builder = new ValidationBuilder();

                var valTemplate = builder.build(valArray);
                var userGroup = BaseController.getUserInput<UserGroup>(context, valTemplate);
                userGroup.Id = uint.Parse(id);

                UserGroup.edit(userGroup, userGroup.Id);
                context.Response.SendResponse("");
            }
            catch (Exception ex)
            {
                context.Response.StatusCode = HttpStatusCode.InternalServerError;
                context.Response.SendResponse(ex.Message);
            }
            return context;
        }

        public static IHttpContext userGroupDelete(IHttpContext context, string id)
        {
            try
            {
                if (!context.token().hasPermission("usergroups.write"))
                {
                    context.Response.StatusCode = HttpStatusCode.NotFound;
                    context.Response.SendResponse("");
                    return context;
                }
                UserGroup.delete(uint.Parse(id));
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
