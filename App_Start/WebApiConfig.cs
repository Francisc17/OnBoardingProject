using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using static OnBoardingProject.App_Start.AutofaConfig;

namespace OnBoardingProject
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services
            AutofacConfig.Register();


            // Web API routes
            config.MapHttpAttributeRoutes();

            //I will define the routes mannualy
            /*
             config.Routes.MapHttpRoute(
                 name: "DefaultApi",
                 routeTemplate: "api/{controller}/{id}",
                 defaults: new { id = RouteParameter.Optional }
             );
            */
        }
    }
}
