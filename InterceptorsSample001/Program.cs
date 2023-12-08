using InterceptorsSample001;
using System.Runtime.CompilerServices;

namespace InterceptorsSample001
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var example = new Example();
            example.MyMethod("World");
            example.MyMethod("World");
            example.MyMethod("World");
        }
    }

    public class Example
    {
        public void MyMethod(string param)
        {
            Console.WriteLine($"Hello {param}");
        }
    }

    public static class GeneratedCode
    {
        [InterceptsLocation("""C:\NETConf\2023\NET_CONF_TW_2023_Samples\InterceptorsSample001\Program.cs""", line: 11, character: 21)]
        [InterceptsLocation("""C:\NETConf\2023\NET_CONF_TW_2023_Samples\InterceptorsSample001\Program.cs""", line: 12, character: 21)]
        public static void MyInterceptorMethod(this Example example, string param)
        {
            Console.WriteLine($"Interceptor {param}");
        }

        [InterceptsLocation("""C:\NETConf\2023\NET_CONF_TW_2023_Samples\InterceptorsSample001\Program.cs""", line: 13, character: 21)] 
        public static void LoggingInterceptorMethod(this Example c, string s)
        {
            Console.WriteLine("Before...");
            c.MyMethod(s);
            Console.WriteLine("After...");
        }
    } 
}
namespace System.Runtime.CompilerServices
{
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = true, Inherited = false)]
    public sealed class InterceptsLocationAttribute : Attribute
    {
        public InterceptsLocationAttribute(string filePath, int line, int character)
        {
        }
    }
}
