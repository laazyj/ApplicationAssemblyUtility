using System;

namespace WebFormsApplication
{
    public class Global : System.Web.HttpApplication
    {
        public static ApplicationAssemblyDetails ApplicationAssemblyDetails { get; set; }
        public static ApplicationAssemblyDetails ApplicationAssemblyDetails00 { get; set; }

        void Application_Start(object sender, EventArgs e)
        {
            ApplicationAssemblyDetails = ApplicationAssemblyDetails.Current;
            ApplicationAssemblyDetails00 = ApplicationAssemblyDetails.Current00;
        }
    }
}
