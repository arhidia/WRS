using Grapevine.Interfaces.Server;
using Grapevine.Server;
using Grapevine.Server.Attributes;
using Grapevine.Shared;
using System;
using System.Collections.Generic;
using System.Text;
using WashingtonRedskins.Controllers;
using WashingtonRedskins.Extensions;

namespace WashingtonRedskins.Routes
{
    [RestResource]
    class StatisticsRoutes
    {
        [RestRoute(HttpMethod = HttpMethod.GET, PathInfo = "/statistics")]
        public IHttpContext getDailyStatistic(IHttpContext context)
        {
            return StatisticsController.statisticGet(context);
        }
    }
}
