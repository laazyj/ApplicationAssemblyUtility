using System.Web.Mvc;
using System.Web.Routing;

namespace MvcApplication
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801

    public class MvcApplication : System.Web.HttpApplication
    {
        public static ApplicationAssemblyDetails ApplicationAssemblyDetails { get; set; }

        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                "Default", // Route name
                "{controller}/{action}/{id}", // URL with parameters
                new { controller = "Home", action = "Index", id = UrlParameter.Optional } // Parameter defaults
            );

        }

        protected void Application_Start()
        {
            // Call during Start of application as application instance is not yet available
            ApplicationAssemblyDetails = ApplicationAssemblyDetails.Current;

            RegisterRoutes(RouteTable.Routes);
        }
    }
}