using System;
using System.Threading;
using System.Threading.Tasks;

namespace ServerCore
{
    class Part4_Section1_7
    {
        static int number = 0;
        static object _obj = new object();

        static void Thread_1()
        {
            for (int i = 0; i < 100000; i++)
            {
                // Interlocked는 정수만 사용해야하는 단점이 있다.
                // int afterValue = Interlocked.Increment(ref number); // 1

                //// 상호배제, Mutual Exclusive
                //Monitor.Enter(_obj); // 문을 잠구는 행위
                //{
                //    number++;
                //    if (number == 100000)
                //    {
                //        Monitor.Exit(_obj); // 잠금을 풀어준다.
                //        return;
                //    }
                //} // 안에서 리턴을 때리게 되면 '데드락 DeadLock'이라는 상황이 온다.
                //Monitor.Exit(_obj); // 잠금을 풀어준다.
                //try
                //{
                //    Monitor.Exit(_obj); // 잠금을 풀어준다.
                //    number++;
                //    return;
                //}
                //finally
                //{
                //    Monitor.Exit(_obj); // 잠금을 풀어준다.
                //}
                // try, finally를 이용하면 데드락의 상황이 와도 finally에서 풀리게 된다

                lock (_obj)
                {
                    number++;
                }
            }
        }

        static void Thread_2()
        {
            for (int i = 0; i < 100000; i++)
            {
                lock (_obj)
                {
                    number--;
                }
            }
        }

        static void Main(string[] args)
        {
            Task t1 = new Task(Thread_1);
            Task t2 = new Task(Thread_2);

            t1.Start();
            t2.Start();

            Task.WaitAll(t1, t2);

            Console.WriteLine(number);
        }
    }
}