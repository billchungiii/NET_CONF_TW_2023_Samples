using InterceptorsSample001;
using System.Runtime.CompilerServices;

namespace InterceptorsSample001
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var example = new MyClass();
            example.MyMethod("World");
            example.MyMethod("World");
            example.MyMethod("World");
        }
    }

    public class MyClass
    {
        public void MyMethod(string param)
        {
            Console.WriteLine($"Hello {param}");
        }
    }

    public static class GeneratedCode
    {
        [InterceptsLocation("""C:\NETConf\2023\NET_CONF_TW_2023_Samples\InterceptorsSample001\Program.cs""", line: 11, character: 21)]
        [InterceptsLocation("""C:\NETConf\2023\NET_CONF_TW_2023_Samples\InterceptorsSample001\Program.cs""", 12, 21)]
        public static void MyInterceptorMethod(this MyClass instance, string param)
        {
            Console.WriteLine($"Interceptor {param}");
        }

        [InterceptsLocation("""C:\NETConf\2023\NET_CONF_TW_2023_Samples\InterceptorsSample001\Program.cs""", 13, 21)]
        public static void LoggingInterceptorMethod(this MyClass instance, string param)
        {
            Console.WriteLine("Before...");
            instance.MyMethod(param);
            Console.WriteLine("After...");
        }
    }
}
namespace System.Runtime.CompilerServices
{
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = true, Inherited = false)]
    public sealed class InterceptsLocationAttribute : Attribute
    {
        public InterceptsLocationAttribute(string path, int line, int character)
        {
        }
    }
}
