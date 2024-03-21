using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace InlineArraySample001
{
    internal class Program
    {
        static void Main(string[] args)
        {
            UseInlineArray();
            Console.WriteLine();
            Console.WriteLine("------------------");
            UseCustomInlineArray();
        }

        public static void UseInlineArray()
        {
            var arr = new MyInlineArray();
            for (int i = 0; i < 10; i++)
            {
                arr[i] = i;
            }

            foreach (var item in arr)
            {
                Console.WriteLine(item);
            }
            Span<int> span1 = arr;
            foreach (var item in span1)
            {
                Console.Write($"{item},");
            }
            Console.WriteLine();
            ReadOnlySpan<int> span2 = arr;
            foreach (var item in span2)
            {
                Console.Write($"{item}#");
            }
        }

        public static void UseCustomInlineArray()
        {
            MyInlineArray arr = new MyInlineArray();
            PrivateImplementationDetails.InlineArrayAsSpan<MyInlineArray, int>(ref buffer, 10);
            for (int index = 0; index < 10; ++index)
            {
                PrivateImplementationDetails.InlineArrayAsSpan<MyInlineArray, int>(ref buffer, 10)[index] = index;
            }
            ref MyInlineArray local = ref buffer;
            for (int index = 0; index < 10; ++index)
            {
                Console.WriteLine(PrivateImplementationDetails.InlineArrayElementRef<MyInlineArray, int>(ref local, index));
            }

            Span<int> span1 = PrivateImplementationDetails.InlineArrayAsSpan<MyInlineArray, int>(ref buffer, 10);

            foreach (var item in span1)
            {
                Console.Write($"{item},");
            }
            Console.WriteLine();
            ReadOnlySpan<int> span2 = PrivateImplementationDetails.InlineArrayAsReadOnlySpan<MyInlineArray, int>(in buffer, 10);
            foreach (var item in span2)
            {
                Console.Write($"{item}#");
            }
        }
    }

    [System.Runtime.CompilerServices.InlineArray(10)]
    public struct MyInlineArray
    {
        // 只能有一個欄位，而且命名可以亂取
        private int _e;
    }
    /// <summary>
    /// 編譯器長出來的輔助型別會長這樣
    /// </summary>
    internal sealed class PrivateImplementationDetails
    {
        // 這個依據需求，不一定會有
        internal static ReadOnlySpan<TElement> InlineArrayAsReadOnlySpan<TBuffer, TElement>(in TBuffer buffer, int length)
        {
            return MemoryMarshal.CreateReadOnlySpan<TElement>(ref Unsafe.As<TBuffer, TElement>(ref Unsafe.AsRef<TBuffer>(in buffer)), length);
        }

        internal static Span<TElement> InlineArrayAsSpan<TBuffer, TElement>(ref TBuffer buffer, int length)
        {
            return MemoryMarshal.CreateSpan<TElement>(ref Unsafe.As<TBuffer, TElement>(ref buffer), length);
        }

        internal static ref TElement InlineArrayElementRef<TBuffer, TElement>(ref TBuffer buffer, int index)
        {
            return ref Unsafe.Add<TElement>(ref Unsafe.As<TBuffer, TElement>(ref buffer), index);
        }
    }
}
