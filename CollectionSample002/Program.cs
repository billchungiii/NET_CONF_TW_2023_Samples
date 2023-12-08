namespace CollectionSample002
{
    /// <summary>
    /// 使用散佈運算子
    /// </summary>
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] row0 = [1, 2, 3];
            int[] row1 = [4, 5, 6];
            int[] row2 = [7, 8, 9];
            int[] single = [.. row0, .. row1, .. row2];
            foreach (var element in single)
            {
                Console.Write($"{element}, ");
            }
        }
    }
}
