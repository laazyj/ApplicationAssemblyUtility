using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading;
using System.Web;
using System.Web.Compilation;

namespace eSpares.Levity
{
    public static class ApplicationAssemblyUtility
    {
        static readonly Lazy<Assembly> _applicationAssembly = new Lazy<Assembly>(getApplicationAssembly, LazyThreadSafetyMode.ExecutionAndPublication);
        static readonly Lazy<string> _applicationBinFolder = new Lazy<string>(getApplicationBinFolder, LazyThreadSafetyMode.ExecutionAndPublication);

        public static Assembly ApplicationAssembly
        {
            get { return _applicationAssembly.Value; }
        }

        public static string ApplicationBinFolder
        {
            get { return _applicationBinFolder.Value; }
        }

        /// <summary>
        /// Returns the version number with depth 3 <seealso cref="https://msdn.microsoft.com/en-us/library/bff8h2e1%28v=vs.110%29.aspx"/>
        /// </summary>
        /// <param name="double00">Specify if you want double digits in minor and  </param>
        /// <returns></returns>
        public static string GetApplicationVersionNumber(bool double00 = false)
        {
            Version v = ApplicationAssembly.GetName().Version;
            return getVersionString(v, double00);
        }

        public static string GetAssemblyVersionFromType(Type type, bool double00 = false)
        {
            Version v = type.Assembly.GetName().Version;
            return getVersionString(v, double00);
        }

        //depth field is a stub for future extension 
        private static string getVersionString(Version v, bool double00 = false, int depth = 3)
        {
            if (double00)
                return v.ToStringDouble00();
            else
                return v.ToString(depth);
        }


        /// <summary>
        /// Returns true if the current application assembly is built in Debug mode.
        /// </summary>
        public static bool ApplicationIsDebugBuild()
        {
            return AssemblyIsDebugBuild(ApplicationAssembly);
        }

        /// <summary>
        /// Checks for the DebuggableAttribute on the assembly provided to determine
        /// whether it has been built in Debug mode.
        /// </summary>
        public static bool AssemblyIsDebugBuild(Assembly assembly)
        {
            return assembly
                .GetCustomAttributes(false)
                .OfType<DebuggableAttribute>()
                .Select(attr => attr.IsJITTrackingEnabled)
                .FirstOrDefault();
        }

        static string getApplicationBinFolder()
        {
            var codeBase = ApplicationAssembly.CodeBase;
            var uri = new UriBuilder(codeBase);
            var path = Uri.UnescapeDataString(uri.Path);
            return Path.GetDirectoryName(path);
        }

        static Assembly getApplicationAssembly()
        {
            // Are we in a web application?
            if (HttpContext.Current != null)
            {
                // Get the global application type
                var globalAsax = BuildManager.GetGlobalAsaxType();
                if (globalAsax != null && globalAsax.BaseType != null) return globalAsax.BaseType.Assembly;
            }

            // Provide entry assembly and fallback to executing assembly
            return Assembly.GetEntryAssembly() ?? Assembly.GetExecutingAssembly();
        }
    }
}
