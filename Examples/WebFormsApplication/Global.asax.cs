using System;
using AssemblyWithoutReferenceToApplication;

namespace WebFormsApplication
{
    public class Global : System.Web.HttpApplication
    {
        public static ApplicationAssemblyDetails ApplicationAssemblyDetails { get; set; }

        void Application_Start(object sender, EventArgs e)
        {
            ApplicationAssemblyDetails = ApplicationAssemblyDetails.Current;
        }
    }
}
