using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading;
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

		public static string GetApplicationVersionNumber()
		{
			return ApplicationAssembly.GetName().Version.ToString(3);
		}

        public static string GetAssemblyVersionFromType(Type type)
        {
            return type.Assembly.GetName().Version.ToString(3);
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
            var globalAsax = BuildManager.GetGlobalAsaxType();
            if (globalAsax != null && globalAsax.BaseType != null) return globalAsax.BaseType.Assembly;

			// Fallback to executing assembly
			return Assembly.GetEntryAssembly() ?? Assembly.GetExecutingAssembly();
		}
    }
}
