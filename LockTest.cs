using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace ThreadSample
{
    public static class LockTest
    {
        static bool _done;
        static readonly object _locker = new object();

        public static void MainTest()
        {
            new Thread(Go).Start();
            Go();
        }

        static void Go()
        {
            lock (_locker)
            {
                if (!_done)
                {
                    Console.WriteLine("Done");
                    _done = true;
                }
            }
        }
    }
}
