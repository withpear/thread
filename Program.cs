using System;
using System.Threading;
using System.Threading.Tasks;

namespace ThreadSample
{
    public delegate int Transfromer(int num);
    class Program
    {
        static int Square(int x)=> x * x;
        static async Task Main(string[] args)
        {
            //ThreadTest.MainThread();
            //JoinTest.MainThread();
            //JoinTest.SleepTest();

            //await TaskTest.TaskAwaitTest();

            //Console.WriteLine("啦啦啦");
            //TaskTest.TaskRunTest();

            // TaskExceptionTest.MainTest();

            // DelegateTest.Demo();
            // EventHandlerTest.Main();
            // Transfromer t = Square;
            // Console.WriteLine(t(5));

            //Func<int, Task<int>> func = async x => {
            //    Console.WriteLine("Starting...x={0}", x);
            //    await Task.Delay(x * 1000);
            //    Console.WriteLine("after await thread...={0}", Thread.CurrentThread.ManagedThreadId);
            //    Console.WriteLine("Finished...x={0}", x);
            //    return x * 2;
            //};


            //Console.WriteLine("Main thread...={0}", Thread.CurrentThread.ManagedThreadId);

            //Task<int> first = func(2);
            //Task<int> second = func(5);
            //Console.WriteLine("First result: {0}", first.Result);
            //Console.WriteLine("Second result: {0}", second.Result);
            //Console.WriteLine("thread id...{0}", Thread.CurrentThread.ManagedThreadId);


            TaskCompletionSourceTest.Main();

            Console.ReadLine();
        }

    }
}
