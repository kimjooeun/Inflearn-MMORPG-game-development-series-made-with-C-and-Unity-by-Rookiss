using System;
using System.Threading;
using System.Threading.Tasks;

namespace ServerCore
{
    //class Lock
    //{
    //    // bool <= 커널
    //    // 운영체제를 이용하기 때문에 오래 걸린다.
    //    ManualResetEvent _available = new ManualResetEvent(false);
    //    public void Acquire() // 획득하겠다
    //    {
    //        _available.WaitOne(); // 입장 시도
    //        //_available.Reset(); // bool = false
    //        //_available.Reset(); // 문을 닫는다
    //    }

    //    public void Release() // 반환하겠다
    //    {
    //        _available.Set(); // flag = true;, 문을 열어준다           
    //    }
    //}

    class Part4_Section1_12
    {
        static int _num = 0;

        // bool
        // int Threadid
        // 식당 아래 운영지배인에게까지 고자질하는 상태 (커널)
        static Mutex _lock = new Mutex();

        static void Thread_1()
        {
            for (int i = 0; i < 100000; i++)
            {
                _lock.WaitOne();
                _lock.WaitOne();
                _num++;
                _lock.ReleaseMutex();
                _lock.ReleaseMutex();
            }
        }

        static void Thread_2()
        {
            for (int i = 0; i < 100000; i++)
            {
                _lock.WaitOne();
                _num--;
                _lock.ReleaseMutex();
            }
        }

        static void Main(string[] args)
        {
            Task t1 = new Task(Thread_1);
            Task t2 = new Task(Thread_2);

            t1.Start();
            t2.Start();

            Task.WaitAll(t1, t2);
            Console.WriteLine(_num);            
        }
    }
}