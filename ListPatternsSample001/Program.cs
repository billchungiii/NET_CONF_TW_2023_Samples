namespace ListPatternsSample001
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(CompareAllElements());
            Console.WriteLine(CompareWithDiscard());
            Console.WriteLine(CompareWithRange());
            CompareWithVar();
            Recursive();
        }

        /// <summary>
        /// 比對所有元素是否相符
        /// </summary>
        static bool CompareAllElements()
        {
            List<int> list = new List<int> { 1, 2, 3, 5, 6, 7 };
            var result = list is [1, 2, 3, 5, 7, 11];
            return result;
        }
        /// <summary>
        /// 搭配 Discard
        /// </summary>
        static bool CompareWithDiscard()
        {
            List<int> list = new List<int> { 1, 2, 3, 5, 6, 7 };
            var result = list is [_, 2, _, _, _, _];
            return result;
        }

        /// <summary>
        /// 搭配 discard and range
        /// </summary>
        static bool CompareWithRange()
        {
            List<int> list = new List<int> { 1, 2, 3, 5, 6, 7 };
            var result = list is [_, 3, _, _, 16, _, 12, ..];
            return result;
        }

        /// <summary>
        /// 搭配 var pattern
        /// </summary>
        static void CompareWithVar()
        {
            List<int> list = new List<int> { 1, 2, 3, 5, 6, 7 };         
            if (list is [.., var x])
            {
                Console.WriteLine(x);
            }
            else
            {
                Console.WriteLine("not matching");
            }
        }

        /// <summary>
        /// 利用遞迴計算兩兩元素相加
        /// </summary>
        static void Recursive()
        {
            int[] array = { 1, 9, 8, 7, 6, 5, 3 };
            List<int> result = new List<int>();
            Compute(array, result);
            Console.Write(string.Join(",", result));

            void Compute(int[] source, List<int> result)
            {
                switch (source)
                {
                    case [var x, var y, .. var z]:
                        result.Add(x + y);
                        Compute(z, result);
                        break;
                    case [var x]:
                        result.Add(x);
                        break;
                };
            }
        }
    }
}
