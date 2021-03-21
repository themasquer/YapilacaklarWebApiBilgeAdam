using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace _037_YapilacaklarWebApiBilgeAdam
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "CustomApiKulYap",
                routeTemplate: "kulyap/{controller}",
                defaults: new { controller = "KullaniciYapilacak" }
            ); // route constraints üzerinden buradaki route tanımlamalarına kısıtlamalar getirilebilir.

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
