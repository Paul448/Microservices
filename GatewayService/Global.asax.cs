using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using System.Web.Security;
using System.Web.SessionState;
using System.Web.Http;
using GatewayService.Models;

namespace GatewayService
{
    public class Global : HttpApplication
    {
        private static List<AuthCodes> _AuthCodes;

        public static List<AuthCodes> AuthCodes { get => _AuthCodes; set => _AuthCodes = value; }

        void Application_Start(object sender, EventArgs e)
        {
            // Code, der beim Anwendungsstart ausgeführt wird
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            AuthCodes = new List<AuthCodes>();
        }
    }
}