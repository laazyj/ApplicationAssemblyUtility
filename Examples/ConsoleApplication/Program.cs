using System;
using eSpares.Levity;

namespace ConsoleApplication
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("The application assembly is: " + ApplicationAssemblyUtility.ApplicationAssembly);
            Console.WriteLine("The application bin folder is: " + ApplicationAssemblyUtility.ApplicationBinFolder);
            Console.WriteLine("The application version number is: " + ApplicationAssemblyUtility.GetApplicationVersionNumber());
            Console.WriteLine("The application was built in {0} mode.", ApplicationAssemblyUtility.ApplicationIsDebugBuild() ? "Debug" : "Release");
            Console.WriteLine("Press any key to exit...");
            Console.Read();
        }
    }
}