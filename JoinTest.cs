using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace ThreadSample
{
    public static class JoinTest
    {
        public static void MainThread()
        {
            Thread t = new Thread(WriteY);
            t.Start();
            if (t.Join(200))
            {
                Console.WriteLine("Thread t has ended.");
            }
            else
            {
                Console.WriteLine("Thread t was timeout.");
            }
        }

        static void WriteY()
        {
            for (int i = 0; i < 1000; i++)
            {
                Console.Write("y");
            }
        }

        public static void SleepTest()
        {
            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine("Sleep for 2 seconds.");
                Thread.Sleep(2000);
            }

            Console.WriteLine("Main Thread exits.");
        }
    }
}
