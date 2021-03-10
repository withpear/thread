using System;
using System.Collections.Generic;
using System.Text;

namespace ThreadSample
{
    public delegate T Transformer<T>(T arg);

    public class Util
    {
        public static void Tranform<T>(T[] values,Func<T,T> t)
        {
            for (int i = 0; i < values.Length; i++)
            {
                values[i] = t(values[i]);
            }
        }
    }
    //public static class DelegateTTest
    //{
    //    public static void Main()
    //    {
    //        var values = new int[] { 1, 2, 3 };
    //        Util.Tranform(values, Square);
    //        foreach (var item in values)
    //        {
    //            Console.WriteLine(item);
    //        }
    //    }

    //    public static int Square(int n)
    //    {
    //        return n * n;
    //    }
    //}
}
