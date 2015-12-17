using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace BookMarket
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            
            routes.MapRoute(
                name: "Product",
                url: "Product/CatalogView/{bookTagId}",
                defaults: new { controller = "Product", action = "CatalogView"
                }
            );
            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = //"Admin" 
                    "Product"
                    , action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}