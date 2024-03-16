using System.Collections.ObjectModel;
using System.Reflection;

namespace CollectionSample001
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] array = [1, 2, 3, 4, 5, 6, 7, 8];

            List<string> list = ["one", "two", "three"];

            Span<char> span = ['a', 'b', 'c', 'd', 'e', 'f', 'h', 'i'];

            int[][] towArray = [[1, 2, 3], [4, 5, 6], [7, 8, 9]];

            ObservableCollection<string> collection = ["A", "B", "C"];

            var readOnlyCollection = GetSomethings();
            var type = readOnlyCollection.GetType();
            Console.WriteLine(type);
            Console.WriteLine(type.Assembly.FullName);
 
        }

        static IEnumerable<int> GetSomethings() => [1, 2, 3, 4, 5, 6, 7, 8, 9, 10];

        //static IEnumerable<int> GetSomethings2()
        //{
        //    int[] array = [1, 2, 3, 4, 5, 6, 7, 8, 9, 10];
        //    <>z__ReadOnlyArray<int> readOnlyCollection =new <>z__ReadOnlyArray<int>(array);
        //    return readOnlyCollection;
        //}
    }
}
