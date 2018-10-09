using Grapevine.Interfaces.Server;
using Grapevine.Server;
using Newtonsoft.Json;
using System;
using System.Linq;
using WashingtonRedskins.Models;
using System.Collections.Generic;
using System.Data;
using Microsoft.EntityFrameworkCore;
using WashingtonRedskins.Models;
using WashingtonRedskins.Extensions;
using Grapevine.Shared;

namespace WashingtonRedskins.Controllers
{
    class StatisticsController
    {
        public static IHttpContext statisticGet(IHttpContext context)
        {
            try
            {
                if (!context.token().hasPermission("statistics.read"))
                {
                    context.Response.StatusCode = HttpStatusCode.NotFound;
                    context.Response.SendResponse("");
                    return context;
                }
                var startDate = context.Request.QueryString["start"] != null ? DateTime.Parse(context.Request.QueryString["start"]) : DateTime.Parse("1970-01-01 00:00:00");
                bool groupDay = context.Request.QueryString["groupDay"] != null ? bool.Parse(context.Request.QueryString["groupDay"]) : false;
                bool groupWeek = context.Request.QueryString["groupWeek"] != null ? bool.Parse(context.Request.QueryString["groupWeek"]) : false;
                bool groupMonth = context.Request.QueryString["groupMonth"] != null ? bool.Parse(context.Request.QueryString["groupMonth"]) : false;
               

                List<RegistrationSummary> summary = RegistrationSummary.list(startDate, groupDay, groupWeek, groupMonth);

                context.Response.SendResponse(JsonConvert.SerializeObject(summary));
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
