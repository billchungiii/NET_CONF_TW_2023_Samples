namespace PrimaryConstructSample001
{

    internal class Program
    {
        static void Main(string[] args)
        {
            // class 不會有無參數建構式
            // var p1 = new Person();
            var p2 = new Person("Bill", 35, "good!");
            // 結構依然保留無參數建構式
            var s1 = new Student();
            var s2 = new Student("Bill", 90);
        }
    }

    public class Person(string name, int age, string memo)
    {
        public Person(string name, int age) : this(name, age, "") { }
        public string Name { get; } = name;
        public int Age { get; } = age;
        public string Memo { get; } = memo;
    }
    //public class Person
    //{
    //    public Person(string name, int age, string memo)
    //    {
    //        Name = name;
    //        Age = age;
    //        Memo = memo;
    //    }
    //    public string Name { get; }
    //    public int Age { get; }
    //    public string Memo { get; }
    //}

    public struct Student(string name, int score)
    {
        public string Name { get; } = name;
        public int Score { get; } = score;
    }
}
