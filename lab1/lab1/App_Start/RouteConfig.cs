using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace lab1
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
               name: "Home",
               url: "",
               defaults: new { controller = "Home", action = "Index" }
           );

            routes.MapRoute(
                name: "Notepad",
                url: "notepad/create",
                defaults: new { controller = "Home", action = "Create" }
            );

            routes.MapRoute(
                name: "Notepadss",
                url: "notepad/{Name}",
                defaults: new { controller = "Home", action = "SelectNotepad", Name = UrlParameter.Optional }
            );
            routes.MapRoute(
               name: "Notepadsss",
               url: "Home/{action}",
               defaults: new { controller = "Home", action = "Index" }
           );

           

        }
    }
}
