using StajProjesi.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace StajProjesi
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            var namespaces = new[] { typeof(HomeController).Namespace };

            routes.MapRoute("Login", "", new { controller = "Login", action = "Login" });
            routes.MapRoute("Logout", "logout", new { controller = "Login", action = "Logout" });
            routes.MapRoute("Home", "Home", new { controller = "Home", action = "Index" }, namespaces);
        }
    }
}
