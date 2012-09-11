using System;
using System.IO;
using System.Reflection;
using System.Threading;
using System.Web;

namespace eSpares.Levity
{
    public static class ApplicationAssemblyUtility
    {
        const string AspNetNamespace = "ASP";

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
			var ctx = HttpContext.Current;

			// Cannot use EntryAssembly for ASP.NET applications
			var assembly = ctx != null ? getWebApplicationAssembly(ctx) : Assembly.GetEntryAssembly();

			// Fallback to executing assembly
			return assembly ?? Assembly.GetExecutingAssembly();
		}

        static Assembly getWebApplicationAssembly(HttpContext context)
        {
            if (context == null) throw new ArgumentNullException("context");

            var handler = context.CurrentHandler;
            if (handler == null) return null;

            var type = handler.GetType();
            while (type != null && type != typeof(object) && type.Namespace == AspNetNamespace)
                type = type.BaseType;

            return type.Assembly;
        }

    }
}
