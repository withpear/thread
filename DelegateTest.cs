using System;
using System.Collections.Generic;
using System.Text;

namespace ThreadSample
{
    public delegate void Del(string message);
    public delegate int Transformer(int x);
    public static class DelegateTest
    {
        static int Square(int x)
        {
            int result = x * x;
            Console.WriteLine(result);
            return result;
        }
        static int Cube(int x)
        {
            int result = x * x * x;
            Console.WriteLine(result);
            return result;
        }

        static void ConsoleMessage(string msg)
        {
            Console.WriteLine(msg);
        }

        public static void Demo()
        {
            Del dm = ConsoleMessage;
            MethodWithCallback(1, 2, dm);
            dm("hello");

            Transfromer t = Square;
            t += Cube;
            t -= Cube;
            int result = t(3);
            Console.WriteLine(result);

            X x = new X();
            ProgressReporter p = x.InstanceProgress;
            p(99);
            Console.WriteLine(p.Target == x);//True
            Console.WriteLine(p.Method);//Void InstanceProgress(Int32)
        }

        static void MethodWithCallback(int param1,int param2, Del del)
        {
            del("The number is:" + (param1 + param2).ToString());
        }
    }

    public delegate void ProgressReporter(int percentComplete);
    public class X
    {
        public void InstanceProgress(int percentComplete) => Console.WriteLine(percentComplete);
    }
}
