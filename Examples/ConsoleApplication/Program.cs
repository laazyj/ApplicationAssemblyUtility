using System;
using AssemblyWithoutReferenceToApplication;

namespace ConsoleApplication
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var assemblyDetails = ApplicationAssemblyDetails.Current;
            Console.WriteLine("The application assembly is: " + assemblyDetails.ApplicationAssembly);
            Console.WriteLine("The application bin folder is: " + assemblyDetails.BinFolder);
            Console.WriteLine("The application version number is: " + assemblyDetails.VersionNumber);
            Console.WriteLine("The application was built in " + assemblyDetails.BuildMode + " mode.");
            Console.WriteLine("Press any key to exit...");
            Console.Read();
        }
    }
}