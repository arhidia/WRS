using Grapevine.Interfaces.Server;
using Grapevine.Server;
using Grapevine.Server.Attributes;
using Grapevine.Shared;
using WashingtonRedskins.Controllers;
using WashingtonRedskins.Extensions;

namespace WashingtonRedskins
{
    [RestResource]
    class BreakRoutes
    {
        BreakController breakcontroller = new BreakController();

        [RestRoute(HttpMethod = HttpMethod.POST, PathInfo = "/break")]
        public IHttpContext breakCreate(IHttpContext context)
        {
            return breakcontroller.breakCreate(context);
        }
        [RestRoute(HttpMethod = HttpMethod.GET, PathInfo = "/break")]
        public IHttpContext breakList(IHttpContext context)
        {
            return breakcontroller.breakList(context);
        }
        [RestRoute(HttpMethod = HttpMethod.GET, PathInfo = "/break/[id]")]
        public IHttpContext breakGet(IHttpContext context)
        {
            var breakId = context.Request.RawUrl.GrabFirst(@"^/break/(\d+)");
            return breakcontroller.breakGet(context,breakId);
        }
        [RestRoute(HttpMethod = HttpMethod.PUT, PathInfo = "/break/[id]")]
        public IHttpContext breakEdit(IHttpContext context)
        {
            var breakId = context.Request.RawUrl.GrabFirst(@"^/break/(\d+)");
            return breakcontroller.breakEdit(context,breakId);
        }
        [RestRoute(HttpMethod = HttpMethod.DELETE, PathInfo = "/break/[id]")]
        public IHttpContext breakDelete(IHttpContext context)
        {
            var breakId = context.Request.RawUrl.GrabFirst(@"^/break/(\d+)");
            return breakcontroller.breakDelete(context,breakId);
        }


        [RestRoute(HttpMethod = HttpMethod.POST, PathInfo = "/")]
        public IHttpContext test(IHttpContext context)
        {
            var text = Parsers.parseURLEncoded(context.Request.Payload);
            context.Response.SendResponse("test");
            return context;
        }
    }
}