using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace MvcCharBoPinCritCji
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "ChBoPinCritCji",
                url: "charbopopincrits/subset/{Char}",
                defaults: new { controller = "CharBopoPinCrits", action = "Subset", Char = typeof(string) }
            );

            routes.MapRoute(
                name: "Char",
                url: "charbopopincrits/onechar",
                defaults: new { controller = "CharBopoPinCrits", action = "Onechar" }
            );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "CharBopoPinCrits", action = "Onechar", id = UrlParameter.Optional }
            );
        }
    }
}
