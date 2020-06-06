using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace QuanLiCuaHang
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Default",
                url: "{area}/{controller}/{action}/{id}",
                defaults: new { area = "Manager", controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
