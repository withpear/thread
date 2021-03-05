using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ThreadSample
{
    public static class TaskExceptionTest
    {
        public static void MainTest()
        {
            Task task = Task.Run(() => { throw null; });
            try
            {
                task.Wait();
            }
            catch (AggregateException aex)
            {
                if(aex.InnerException is NullReferenceException)
                {
                    Console.WriteLine("Null");
                }
                else
                {
                    throw;
                }
            }
        }
    }
}
