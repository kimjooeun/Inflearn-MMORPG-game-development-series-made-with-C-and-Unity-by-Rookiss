using System;
using System.Threading;
using System.Threading.Tasks;

namespace ServerCore
{
    class Program
    {
        static ThreadLocal<string> ThreadName = new ThreadLocal<string>(() => { return $"My Name Is {Thread.CurrentThread.ManagedThreadId}"; });
        // static string ThreadName;

        static void WhoAmI()
        {
            bool repeat = ThreadName.IsValueCreated;            
            if (repeat)
            {
                Console.WriteLine(ThreadName.Value + "(repeat)");
            }
            else
            {
                Console.WriteLine(ThreadName.Value);
            }
            //ThreadName.Value = $"My Name Is {Thread.CurrentThread.ManagedThreadId}";
        }

        static void Main(string[] args)
        {

            ThreadPool.SetMinThreads(1, 1);
            ThreadPool.SetMaxThreads(3, 3);
            Parallel.Invoke(WhoAmI, WhoAmI, WhoAmI, WhoAmI, WhoAmI, WhoAmI, WhoAmI, WhoAmI);
            // 삭제
            ThreadName.Dispose();
        }
    }
}