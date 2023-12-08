namespace LambdaDefaultParameterSample001
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var addBy = (int value1, int value2 = 1) => value1 + value2;
            Console.WriteLine(addBy(10, 5));
            Console.WriteLine(addBy(20));

            //隱含宣告的參數不可有預設值
            //Func<int,int,int> substractBy = (x, y =1 ) => x - y;
        }
    }
}
