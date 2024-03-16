using System.Collections.ObjectModel;

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
        }

        IEnumerable<int> GetSomethings => [1, 2, 3, 4, 5, 6, 7, 8, 9, 10];
    }
}
