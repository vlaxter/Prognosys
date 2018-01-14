using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace Prognosys.API
{
    /// <summary>
    /// Web api configuration
    /// </summary>
    public static class WebApiConfig
    {
        /// <summary>
        /// Web applicarion settings register
        /// </summary>
        /// <param name="config"></param>
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "v1/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
