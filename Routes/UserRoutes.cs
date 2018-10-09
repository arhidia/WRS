using Grapevine.Interfaces.Server;
using Grapevine.Server;
using Grapevine.Server.Attributes;
using Grapevine.Shared;
using WashingtonRedskins.Controllers;
using WashingtonRedskins.Extensions;


namespace WashingtonRedskins
{
    [RestResource]
    class UserRoutes
    {
        [RestRoute(HttpMethod = HttpMethod.POST, PathInfo = "/user")]
        public IHttpContext userCreate(IHttpContext context)
        {
            return UserController.userCreate(context);
        }
        [RestRoute(HttpMethod = HttpMethod.GET, PathInfo = "/user")]
        public IHttpContext userList(IHttpContext context)
        {
            return UserController.userList(context);
        }
        [RestRoute(HttpMethod = HttpMethod.GET, PathInfo = "/user/[id]")]
        public IHttpContext userGet(IHttpContext context)
        {
            var userId = context.Request.RawUrl.GrabFirst(@"^/user/(\d+)");
            return UserController.userGet(context, userId);
        }
        [RestRoute(HttpMethod = HttpMethod.PUT, PathInfo = "/user/[id]")]
        public IHttpContext userEdit(IHttpContext context)
        {
            var userId = context.Request.RawUrl.GrabFirst(@"^/user/(\d+)");
            return UserController.userEdit(context, userId);
        }
        [RestRoute(HttpMethod = HttpMethod.DELETE, PathInfo = "/user/[id]")]
        public IHttpContext userDelete(IHttpContext context)
        {
            var userId = context.Request.RawUrl.GrabFirst(@"^/user/(\d+)");
            return UserController.userDelete(context,userId);
        }
        [RestRoute(HttpMethod = HttpMethod.POST, PathInfo = "/user/login")]
        public IHttpContext userLogin(IHttpContext context)
        {
            return UserController.userLogin(context);
        }
    }
}
