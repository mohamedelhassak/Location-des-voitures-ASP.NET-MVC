using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace WebApplication4
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
               "admin",
              "admin/dashboard/{action}/{id}",
               new { controller = "Dashboard", action = "Index", id = UrlParameter.Optional }
           );
            routes.MapRoute(
               "adminc",
              "admin/clients/{action}/{id}",
               new { controller = "Clients", action = "Index", id = UrlParameter.Optional }
           ); routes.MapRoute(
                "adminm",
               "admin/marques/{action}/{id}",
                new { controller = "Marques", action = "Index", id = UrlParameter.Optional }
            ); routes.MapRoute(
                "adminmod",
               "admin/modules/{action}/{id}",
                new { controller = "Modules", action = "Index", id = UrlParameter.Optional }
            ); routes.MapRoute(
                "adminp",
               "admin/proprietaires/{action}/{id}",
                new { controller = "Propretaires", action = "Index", id = UrlParameter.Optional }
            ); routes.MapRoute(
                "adminpt",
               "adminPT/proprietaireTypes/{action}/{id}",
                new { controller = "PropretaireTypes", action = "Index", id = UrlParameter.Optional }
            ); routes.MapRoute(
                "adminv",
               "admin/voitures/{action}/{id}",
                new { controller = "Voitures", action = "Index", id = UrlParameter.Optional }
            ); routes.MapRoute(
                 "admincat",
                "admin/categories/{action}/{id}",
                 new { controller = "Categories", action = "Index", id = UrlParameter.Optional }
             ); routes.MapRoute(
                 "adminlog",
                "admin/account/{action}/{id}",
                 new { controller = "Account", action = "login", id = UrlParameter.Optional }
             );
            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
