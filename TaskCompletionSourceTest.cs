using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ThreadSample
{
    public static class TaskCompletionSourceTest
    {
        public static void Main()
        {
            //var tcs = new TaskCompletionSource<int>();
            //new Thread(() => {
            //    Thread.Sleep(5000);
            //    tcs.SetResult(42);
            //}) 
            //{ 
            //    IsBackground = true
            //}.Start();

            //Task<int> task = tcs.Task;
            //Console.WriteLine(task.Result);


            //Task<int> task = Run(() => {
            //    Thread.Sleep(5000);
            //    return 5;
            //});
            //Console.WriteLine(task.Result);

            //5秒后，Continuation开始时才占用线程
            Delay(5000).GetAwaiter().OnCompleted(() => {
                Console.WriteLine(5);
            });

            //相当于
            Task.Delay(5000).GetAwaiter().OnCompleted(() => Console.WriteLine(5));
            Task.Delay(5000).ContinueWith(ant => Console.WriteLine(5));
            //Task.Delay相当于异步版本的Thread.Sleep
            Console.ReadKey();
        }

        //相当于调用Task.Factory.StartNew
        //并使用TaskCreationOptions.LongRunning选项来创建非线程池的线程
        static Task<TResult> Run<TResult>(Func<TResult> function)
        {
            var tcs = new TaskCompletionSource<TResult>();
            new Thread(() => {
                try
                {
                    tcs.SetResult(function());
                }
                catch (Exception ex)
                {
                    tcs.SetException(ex);
                }
            }).Start();
            return tcs.Task;
        }

        static Task Delay(int milliseconds)
        {
            var tcs = new TaskCompletionSource<object>();
            var timer = new System.Timers.Timer(milliseconds) { AutoReset = false };
            timer.Elapsed += delegate { timer.Dispose(); tcs.SetResult(null); };
            timer.Start();
            return tcs.Task;
        }
    }
}
