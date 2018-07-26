using CustomErrorsRepro.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Caching;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace CustomErrorsRepro
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }

        // if you have exceptionfilters registered they handle exceptions before this
        protected void Application_Error(object sender, EventArgs e)
        {
            Exception unhandledException = Server.GetLastError();

            LogError(unhandledException);

            var httpContext = HttpContext.Current;

            httpContext.Response.Clear();
            httpContext.Response.StatusCode = 500; // this tells IIS to request the httpErrors specified page

            Server.ClearError();
            httpContext.Response.End();
        }

        private void LogError(Exception unhandledException)
        {
            var app = System.Web.Configuration.WebConfigurationManager.OpenWebConfiguration("~/");
            var appCustomErrorsMode = ((System.Web.Configuration.SystemWebSectionGroup)app.GetSectionGroup("system.web")).CustomErrors.Mode;

            var logMessage = new LogMessage { LogDate = DateTime.Now.ToString("MMM dd hh:mm:ss"), Message = unhandledException.Message, CustomErrorsMode = appCustomErrorsMode.ToString() };

            var cache = new Cache();
            List<LogMessage> log = cache.Get("log") as List<LogMessage>;
            if (log == null)
            {
                log = new List<LogMessage> { logMessage };
            }
            else
            {
                log.Add(logMessage);
            }
            cache.Insert("log", log);
        }
    }
}
