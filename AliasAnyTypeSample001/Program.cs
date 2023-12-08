using MyPoint = (int x, int y); 
// 需全名
using MyRange = System.Tuple<int, int>;
//using Scores = System.Collections.Generic.List<int>; global using
namespace AliasAnyTypeSample001
{
    internal class Program
    {
        static void Main(string[] args)
        {
            MyPoint p = new MyPoint(10, 90);
            Console.WriteLine(p.ToString());
            MyRange r = new MyRange(1, 10);
            Console.WriteLine(r.ToString());
            Scores s = new Scores { 1, 2, 3, 4, 5 };
            Console.WriteLine(s[0].ToString());
            foreach (var item in s)
            {
                Console.WriteLine(item.ToString());
            }
        }
    }
}
