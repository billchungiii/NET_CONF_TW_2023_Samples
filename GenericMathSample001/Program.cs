using System.Numerics;

namespace GenericMathSample001
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var result = Enumerable.Range(1, 10).GenericSum();
            Console.WriteLine(result);
        }
    }

    public static class GenericMathExtensions
    {
        public static T GenericSum<T>(this IEnumerable<T> source)
            where T :
            IAdditionOperators<T, T, T>,
            IAdditiveIdentity<T, T>
        {
            if (source == null) throw new ArgumentNullException(nameof(source));
            var result = T.AdditiveIdentity;
            foreach (var item in source)
            {
                if (item != null)
                {
                    result = result + item;
                }
            }
            return result;
        }
    }
}
