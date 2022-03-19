using System;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using LightInject;
using PruebaIngreso.Controllers;
using PruebaIngreso.Models;
using Quote.ServiceDescriptor;

namespace PruebaIngreso
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            var container = new ServiceContainer();
            container.RegisterControllers();
            QuoteDefaultServiceDescriptor.Register(container);
            //register other services

            container.EnableMvc();
        }

        protected void Application_Error(object sender, EventArgs e)
        {
            var exception = Server.GetLastError();
            Response.Clear();
            RouteData routeData = new RouteData();
            routeData.Values.Add("controller", "Error");
            routeData.Values.Add("action", "Index");
            routeData.Values.Add("error", exception);
            Server.ClearError();
            try
            {
                IController errorController = new ErrorController();
                errorController.Execute(new RequestContext(
                    new HttpContextWrapper(Context), routeData));
            }
            catch
            {
                // ignored
            }
        }
    }
}
