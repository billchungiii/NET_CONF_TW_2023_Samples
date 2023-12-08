namespace StaticVirtualMemberSample001
{
    internal class Program
    {
        internal class Program
        {
            static void Main(string[] args)
            {
                var r1 = new Rect { Width = 10, Height = 8 };
                var r2 = new Rect { Width = 20, Height = 8 };
                var result = Shape.Add(r1, r2);
            }
        }

        public interface IAreaAddable<T, TResult>
        {
            static abstract TResult Add(T x, T y);
        }

        public interface IShape
        {
            double GetArea();
        }

        public abstract class Shape : IShape, IAreaAddable<IShape, double>
        {
            public static double Add(IShape x, IShape y)
            {
                return x.GetArea() + y.GetArea();
            }
            public abstract double GetArea();
        }

        public class Rect : Shape
        {
            public int Width { get; set; }
            public int Height { get; set; }

            public override double GetArea()
            {
                return Width * Height;
            }
        }
    }
}
