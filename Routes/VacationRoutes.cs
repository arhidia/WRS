using Grapevine.Interfaces.Server;
using Grapevine.Server;
using Grapevine.Server.Attributes;
using Grapevine.Shared;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;
using System.Linq;
using WashingtonRedskins.Controllers;
using WashingtonRedskins.Extensions;
using WashingtonRedskins.Models;
using WashingtonRedskins.Validation;

namespace WashingtonRedskins
{
    [RestResource]
    class VacationRoutes
    {
        [RestRoute(HttpMethod = HttpMethod.POST, PathInfo = "/vacation")]
        public IHttpContext vacationCreate(IHttpContext context)
        {
            return VacationController.vacationCreate(context);
        }
        [RestRoute(HttpMethod = HttpMethod.GET, PathInfo = "/vacation/[id]")]
        public IHttpContext vacationGet(IHttpContext context)
        {
            var vacationId = context.Request.RawUrl.GrabFirst(@"^/vacation/(\d+)");
            return VacationController.vacationGet(context, vacationId);
        }
        [RestRoute(HttpMethod = HttpMethod.GET, PathInfo = "/vacation")]
        public IHttpContext vacationList(IHttpContext context)
        {
            return VacationController.vacationList(context);
        }
        [RestRoute(HttpMethod = HttpMethod.PUT, PathInfo = "/vacation/[id]")]
        public IHttpContext vacationEdit(IHttpContext context)
        {
            var vacationId = context.Request.RawUrl.GrabFirst(@"^/vacation/(\d+)");
            return VacationController.vacationEdit(context, vacationId);
        }
        [RestRoute(HttpMethod = HttpMethod.DELETE, PathInfo = "/vacation/[id]")]
        public IHttpContext vacationDelete(IHttpContext context)
        {
            var vacationId = context.Request.RawUrl.GrabFirst(@"^/vacation/(\d+)");
            return VacationController.vacationDelete(context, vacationId);
        }
    }
}