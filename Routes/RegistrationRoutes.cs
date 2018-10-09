using Grapevine.Interfaces.Server;
using Grapevine.Server;
using Grapevine.Server.Attributes;
using Grapevine.Shared;
using System;
using System.Collections.Generic;
using System.Text;
using WashingtonRedskins.Controllers;
using WashingtonRedskins.Extensions;
using WashingtonRedskins.Models;

namespace WashingtonRedskins.Routes
{
    [RestResource]
    class RegistrationRoutes
    {
        [RestRoute(HttpMethod = HttpMethod.POST, PathInfo = "/registrations")]
        public IHttpContext registrationsCreate(IHttpContext context)
        {
            return RegistrationController.registrationCreate(context);
        }
        [RestRoute(HttpMethod = HttpMethod.GET, PathInfo = "/registrations")]
        public IHttpContext registrationList(IHttpContext context)
        {
            return RegistrationController.registrationList(context);
        }
        [RestRoute(HttpMethod = HttpMethod.GET, PathInfo = "/registrations/[id]")]
        public IHttpContext registrationGet(IHttpContext context)
        {
            var regId = context.Request.RawUrl.GrabFirst(@"^/registrations/(\d+)");
            return RegistrationController.registrationGet(context, regId);
        }
        [RestRoute(HttpMethod = HttpMethod.PUT, PathInfo = "/registrations/[id]")]
        public IHttpContext registrationEdit(IHttpContext context)
        {
            var regId = context.Request.RawUrl.GrabFirst(@"^/registrations/(\d+)");
            return RegistrationController.registrationEdit(context, regId);
        }
        [RestRoute(HttpMethod = HttpMethod.DELETE, PathInfo = "/registrations/[id]")]
        public IHttpContext registrationDelete(IHttpContext context)
        {
            var regId = context.Request.RawUrl.GrabFirst(@"^/registrations/(\d+)");
            return RegistrationController.registrationDelete(context, regId);
        }
    }
}

