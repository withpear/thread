using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace ThreadSample
{
    public static class ThreadTest
    {
        public static void MainThread()
        {
            Thread.CurrentThread.Name = "Main Thread...";

            Thread t = new Thread(WriteY);
            t.Name = "Y Thread...";
            t.Start();

            Console.WriteLine(Thread.CurrentThread.Name);
            for (int i = 0; i < 1000; i++)
            {
                Console.Write("x");
            }
        }

        static void WriteY()
        {
            Console.WriteLine(Thread.CurrentThread.Name);
            for (int i = 0; i < 1000; i++)
            {
                Console.Write("y");
            }
        }
    }
}
