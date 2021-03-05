using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ThreadSample
{
    public static class TaskTest
    {
        public static async Task TaskAwaitTest()
        {
            Console.WriteLine("主线程： "+Thread.CurrentThread.ManagedThreadId);
            Console.WriteLine("主线程： "+Thread.CurrentThread.IsThreadPoolThread);

            await Task.Run(() => { 
                Console.WriteLine("呵呵： "+Thread.CurrentThread.ManagedThreadId);
                Console.WriteLine("呵呵： "+Thread.CurrentThread.IsThreadPoolThread);
            });

            Console.WriteLine("嘻嘻： "+Thread.CurrentThread.ManagedThreadId);
            Console.WriteLine("嘻嘻： "+Thread.CurrentThread.IsThreadPoolThread);
        
            await Task.Run(() => {
                Console.WriteLine("哈哈： "+Thread.CurrentThread.ManagedThreadId);
                Console.WriteLine("哈哈： "+Thread.CurrentThread.IsThreadPoolThread);
            }).ConfigureAwait(false);

           // await Task.Delay(1000);
            Console.WriteLine("嘿嘿： " + Thread.CurrentThread.ManagedThreadId);
            Console.WriteLine("嘿嘿： " + Thread.CurrentThread.IsThreadPoolThread);
        }

        public static void TaskRunTest()
        {
            var task = Task.Run(() => {
                Thread.Sleep(2000);
                Console.WriteLine("Foo: " + Thread.CurrentThread.ManagedThreadId);
            });
            Console.WriteLine(task.IsCompleted);
            task.Wait();
            Console.WriteLine(task.IsCompleted);

            Console.WriteLine("Main Thread: " + Thread.CurrentThread.ManagedThreadId);

            Task.Run(() => {
                Console.WriteLine("Bar: " + Thread.CurrentThread.ManagedThreadId);
            });
        }

        public static void TaskResultTest()
        {
            var task = Task.Run(() => {
                Console.WriteLine("Foo");
                return 3;
            });
            int result = task.Result;
            Console.WriteLine(result);
        }
    }
}
