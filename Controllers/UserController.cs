using Grapevine.Interfaces.Server;
using Grapevine.Server;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;
using System.Linq;
using WashingtonRedskins.Models;
using WashingtonRedskins.Validation;
using WashingtonRedskins.Extensions;
using System.Collections.Generic;
using Grapevine.Shared;

namespace WashingtonRedskins.Controllers
{
    public class UserController
    {
        public static IHttpContext userLogin(IHttpContext context)
        {
            try
            {
                var data = Parsers.parseURLEncoded(context.Request.Payload);
                var token = Users.login(data["email"], data["password"]);

                if (token == null)
                {
                    context.Response.StatusCode = Grapevine.Shared.HttpStatusCode.NotFound;
                    return context;
                }
                context.Response.SendResponse(token);
            }
            catch (Exception ex)
            {
                context.Response.StatusCode = HttpStatusCode.InternalServerError;
                context.Response.SendResponse(ex.Message);
            }
            return context;
        }

        public static IHttpContext userCreate(IHttpContext context)
        {
            try
            {
                if (!context.token().hasPermission("users.write"))
                {
                    context.Response.StatusCode = HttpStatusCode.NotFound;
                    context.Response.SendResponse("");
                    return context;
                }
                ValidationBuilder valBuilder = new ValidationBuilder();
                ValidationCollection valCollection;

                string[] valArray =
                    {
                "name=Firstname,isRequired=",
                "name=Lastname,isRequired=",
                "name=UsersName,isRequired=",
                "name=Password,isRequired=,minLength=6",
                "name=Email,isRequired=",
                "name=UserGroupId,isNumeric=",
                "name=Address,isRequired=",
                "name=Postcode,isNumeric=,isRequired=,length=4",
                "name=Phone,isRequired=",
                "name=CprNr,isNumeric=,isRequired=,length=10",
                "name=DepartmentId,isNumeric=",
            };

                valCollection = valBuilder.build(valArray);

                Users usr = BaseController.getUserInput<Users>(context, valCollection);

                usr.Password = AuthController.hashPassword(usr.Password);

                usr.add();
                context.Response.SendResponse("");
            }
            catch (Exception ex)
            {
                context.Response.StatusCode = HttpStatusCode.InternalServerError;
                context.Response.SendResponse(ex.Message);
            }
            return context;
        }
        public static IHttpContext userGet(IHttpContext context, string userId)
        {
            try
            {
                var usr = Users.get(uint.Parse(userId));
                context.Response.SendResponse(JsonConvert.SerializeObject(usr));
            }
            catch (Exception ex)
            {
                context.Response.StatusCode = HttpStatusCode.InternalServerError;
                context.Response.SendResponse(ex.Message);
            }
            return context;
        }
        public static IHttpContext userList(IHttpContext context)
        {
            try
            {
                if (!context.token().hasPermission("users.read"))
                {
                    context.Response.StatusCode = HttpStatusCode.NotFound;
                    context.Response.SendResponse("");
                    return context;
                }

                var data = context.Request.QueryString;

                int pageSize = data["pagesize"] != null ? int.Parse(data["pagesize"]) : 0;
                int skip = data["skip"] != null ? int.Parse(data["skip"]) : 0;
                uint userGroupId = data["usergroup_id"] != null ? uint.Parse(data["usergroup_id"]) : 0;
                uint departmentId = data["department_id"] != null ? uint.Parse(data["department_id"]) : 0;

                var users = Users.list(pageSize, skip, userGroupId, departmentId);
                context.Response.SendResponse(JsonConvert.SerializeObject(users));
            }
            catch (Exception ex)
            {
                context.Response.StatusCode = HttpStatusCode.InternalServerError;
                context.Response.SendResponse(ex.Message);

            }
            return context;
        }
        public static IHttpContext userEdit(IHttpContext context, string userId)
        {
            try
            {
                var data = Parsers.parseURLEncoded(context.Request.Payload);

                if (uint.Parse(userId) != context.token().SID())
                {
                    if (!context.token().hasPermission("users.write"))
                    {
                        context.Response.StatusCode = HttpStatusCode.NotFound;
                        context.Response.SendResponse("");
                        return context;
                    }
                }
                else
                {
                    if (!context.token().hasPermission("users.write") && !context.token().hasPermission("users.self.write"))
                    {
                        context.Response.StatusCode = HttpStatusCode.NotFound;
                        context.Response.SendResponse("");
                        return context;
                    }
                }

                ValidationBuilder valBuilder = new ValidationBuilder();
                ValidationCollection valCollection;

                string[] valArray =
                {
                "name=Firstname,isRequired=1",
                "name=Lastname,isRequired=1",
                "name=UsersName,isRequired=1",
                "name=Password,isRequired=1,minLength=6",
                "name=Email,isRequired=1",
                "name=UserGroupId,isNumeric=1",
                "name=Address,isRequired=1",
                "name=Postcode,isNumeric=1,isRequired=1,length=4",
                "name=Phone,isRequired=1",
                "name=CprNr,isNumeric=1,isRequired=1,length=10",
                "name=DepartmentId,isNumeric=1",
            };

                valCollection = valBuilder.build(valArray);
                var usr = BaseController.getUserInput<Users>(context, valCollection);
                usr.Id = uint.Parse(userId);
                Users.edit(usr.Id, usr);

                context.Response.SendResponse("");
            }
            catch (Exception ex)
            {
                context.Response.StatusCode = HttpStatusCode.InternalServerError;
                context.Response.SendResponse(ex.Message);
            }
            return context;
        }
        public static IHttpContext userDelete(IHttpContext context, string userId)
        {
            try
            {
                Users.delete(uint.Parse(userId));

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
