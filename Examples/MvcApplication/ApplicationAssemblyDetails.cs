using System.Reflection;
using eSpares.Levity;

namespace MvcApplication
{
    public class ApplicationAssemblyDetails
    {
        public static ApplicationAssemblyDetails Current
        {
            get
            {
                return new ApplicationAssemblyDetails
                {
                    ApplicationAssembly = ApplicationAssemblyUtility.ApplicationAssembly,
                    VersionNumber = ApplicationAssemblyUtility.GetApplicationVersionNumber(),
                    BinFolder = ApplicationAssemblyUtility.ApplicationBinFolder,
                    BuildMode = ApplicationAssemblyUtility.ApplicationIsDebugBuild() ? "Debug" : "Release"
                };
            }
        }

        public Assembly ApplicationAssembly { get; set; }
        public string VersionNumber { get; set; }
        public string BinFolder { get; set; }
        public string BuildMode { get; set; }
    }
}