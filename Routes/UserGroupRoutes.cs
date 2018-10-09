using Grapevine.Interfaces.Server;
using Grapevine.Server.Attributes;
using Grapevine.Shared;
using WashingtonRedskins.Controllers;
using WashingtonRedskins.Extensions;

namespace WashingtonRedskins.Routes
{

    [RestResource]
    class UserGroupRoutes
    {
        [RestRoute(HttpMethod = HttpMethod.POST, PathInfo = "/usergroup")]
        public IHttpContext userGroupCreate(IHttpContext context)
        {
            return UserGroupController.userGroupCreate(context);
        }
        [RestRoute(HttpMethod = HttpMethod.GET, PathInfo = "/usergroup")]
        public IHttpContext userGroupList(IHttpContext context)
        {
            return UserGroupController.userGroupList(context);
        }
        [RestRoute(HttpMethod = HttpMethod.GET, PathInfo = "/usergroup/[id]")]
        public IHttpContext userGroupGet(IHttpContext context)
        {
            var userGroupId = context.Request.RawUrl.GrabFirst(@"^/usergroup/(\d+)");
            return UserGroupController.userGroupGet(context, userGroupId);
        }
        [RestRoute(HttpMethod = HttpMethod.PUT, PathInfo = "/usergroup/[id]")]
        public IHttpContext userGroupEdit(IHttpContext context)
        {
            var userGroupId = context.Request.RawUrl.GrabFirst(@"^/usergroup/(\d+)");
            return UserGroupController.userGroupEdit(context, userGroupId);
        }
        [RestRoute(HttpMethod = HttpMethod.DELETE, PathInfo = "/usergroup/[id]")]
        public IHttpContext userGroupDelete(IHttpContext context)
        {
            var userGroupId = context.Request.RawUrl.GrabFirst(@"^/usergroup/(\d+)");
            return UserGroupController.userGroupDelete(context, userGroupId);
        }
    }
}

