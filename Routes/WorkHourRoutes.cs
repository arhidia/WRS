using Grapevine.Interfaces.Server;
using Grapevine.Server;
using Grapevine.Server.Attributes;
using Grapevine.Shared;
using WashingtonRedskins.Controllers;
using WashingtonRedskins.Extensions;

namespace WashingtonRedskins
{
    [RestResource]
    class WorkHourRoutes
    {
        WorkHourController workhourcontroller = new WorkHourController();

        [RestRoute(HttpMethod = HttpMethod.POST, PathInfo = "/workhours")]
        public IHttpContext workhourCreate(IHttpContext context)
        {
            return workhourcontroller.workhourCreate(context);
        }
        [RestRoute(HttpMethod = HttpMethod.GET, PathInfo = "/workhours")]
        public IHttpContext workhourList(IHttpContext context)
        {
            return workhourcontroller.workhourList(context);
        }
        [RestRoute(HttpMethod = HttpMethod.GET, PathInfo = "/workhours/[id]")]
        public IHttpContext workhourGet(IHttpContext context)
        {
            var workhourId = context.Request.RawUrl.GrabFirst(@"^/workhours/(\d+)");
            return workhourcontroller.workhourGet(context, workhourId);
        }
        [RestRoute(HttpMethod = HttpMethod.PUT, PathInfo = "/workhours/[id]")]
        public IHttpContext workhourEdit(IHttpContext context)
        {
            var workhourId = context.Request.RawUrl.GrabFirst(@"^/workhours/(\d+)");
            return workhourcontroller.workhourEdit(context, workhourId);
        }
        [RestRoute(HttpMethod = HttpMethod.DELETE, PathInfo = "/workhours/[id]")]
        public IHttpContext workhourDelete(IHttpContext context)
        {
            var workhourId = context.Request.RawUrl.GrabFirst(@"^/workhours/(\d+)");
            return workhourcontroller.workhourDelete(context, workhourId);
        }
    }
}