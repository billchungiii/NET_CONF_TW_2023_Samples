namespace RefReadonlySample001
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int x = 10;
            // 若過去 Do 宣告為 ref, 現在使用 ref readonly, 呼叫端依然可以用 ref 或改為 in
            Do(ref x);
            Do(in x);
            // 但宣告為 in 的，就只能用 in
            Test(in x);
        }

        public static int Do(ref readonly int x)
        {
            return x + 1;
        }

        public static int Test(in int y)
        {
            return y - 1;
        }
    }
}
