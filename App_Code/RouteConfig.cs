using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Routing;
using Microsoft.AspNet.FriendlyUrls;
using System.Web.Http;

namespace Instrum
{
    public static class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            var settings = new FriendlyUrlSettings();
            settings.AutoRedirectMode = RedirectMode.Permanent;
            routes.EnableFriendlyUrls(settings);
            //routes.MapHttpAttributeRoutes();
            routes.MapHttpRoute(name: "OrgnoApi", routeTemplate: "api/{controller}/GetByOrgno/{Orgno}", defaults: new { Orgno = System.Web.Http.RouteParameter.Optional });
            routes.MapHttpRoute(name: "PostnoApi", routeTemplate: "api/{controller}/GetByPostal/{Postno}", defaults: new { Postno = System.Web.Http.RouteParameter.Optional });
            routes.MapHttpRoute(name: "PeriodpositionApi", routeTemplate: "api/{controller}/GetByPeriod/{fromTime}/{toTime}");
        }
    }
}
