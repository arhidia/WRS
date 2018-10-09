using Grapevine.Interfaces.Server;
using Grapevine.Server.Attributes;
using Grapevine.Shared;
using WashingtonRedskins.Controllers;
using WashingtonRedskins.Extensions;

namespace WashingtonRedskins.Routes
{

    [RestResource]
    class DepartmentRoutes
    {
        [RestRoute(HttpMethod = HttpMethod.POST, PathInfo = "/department")]
        public IHttpContext departmentCreate(IHttpContext context)
        {
            return DepartmentController.departmentCreate(context);
        }
        [RestRoute(HttpMethod = HttpMethod.GET, PathInfo = "/department")]
        public IHttpContext departmentList(IHttpContext context)
        {
            var departmentId = context.Request.RawUrl.GrabFirst(@"^/department/(\d+)");
            return DepartmentController.departmentList(context, departmentId);
        }
        [RestRoute(HttpMethod = HttpMethod.GET, PathInfo = "/department/[id]")]
        public IHttpContext departmentGet(IHttpContext context)
        {
            var departmentId = context.Request.RawUrl.GrabFirst(@"^/department/(\d+)");
            return DepartmentController.departmentGet(context, departmentId);
        }
        [RestRoute(HttpMethod = HttpMethod.PUT, PathInfo = "/department/[id]")]
        public IHttpContext departmentEdit(IHttpContext context)
        {
            var departmentId = context.Request.RawUrl.GrabFirst(@"^/department/(\d+)");
            return DepartmentController.departmentEdit(context, departmentId);
        }
        [RestRoute(HttpMethod = HttpMethod.DELETE, PathInfo = "/department/[id]")]
        public IHttpContext departmentDelete(IHttpContext context)
        {
            var departmentId = context.Request.RawUrl.GrabFirst(@"^/department/(\d+)");
            return DepartmentController.departmentDelete(context, departmentId);
        }
    }
}

