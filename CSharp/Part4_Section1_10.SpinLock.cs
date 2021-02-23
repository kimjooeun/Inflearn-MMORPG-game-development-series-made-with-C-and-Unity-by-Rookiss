using System;
using System.Threading;
using System.Threading.Tasks;

namespace ServerCore
{
    class SpinLock
    { 
        volatile int _locked = 0;

        public void Acquire() // 획득하겠다
        {
            while (true)
            {
                //int original = Interlocked.Exchange(ref _locked, 1);

                //if (original == 0)
                //{
                //    break;
                //}

                // 위 문장은 풀어쓰면 아래문장과 같다. 23번 행과 24번의 행이 15번의 행처럼 한번에 실행된다.
                //{
                //    int original = _locked;
                //    _locked = 1;
                //    if (original == 0)
                //    {
                //        break;
                //    }
                //}

                // CAS Compare-And-Swap
                int expected = 0;
                int desired = 1;

                if (Interlocked.CompareExchange(ref _locked, desired, expected) == expected)
                    break;

                // 위 문장은 풀어쓰면 아래문장과 같다.
                //if (_locked == 0)
                //    _locked = 1;
            }
        }

        public void Release() // 반환하겠다
        {
            _locked = 0;
        }
    }

    class Part4_Section1_10
    {
        static int _num = 0;
        static SpinLock _lock = new SpinLock();

        static void Thread_1()
        {
            for (int i = 0; i < 1000000; i++)
            {
                _lock.Acquire();
                _num++;
                _lock.Release();
            }
        }

        static void Thread_2()
        {
            for (int i = 0; i < 1000000; i++)
            {
                _lock.Acquire();
                _num--;
                _lock.Release();
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