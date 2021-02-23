using System;
using System.Threading;
using System.Threading.Tasks;

namespace ServerCore
{
    class Program
    {
        // 1. 근성(스핀 락)
        // 2. 양보(일드, 쉬다오는 것)
        // 3. 갑질(직원을 한명 두는것)

        // 상호 배제가 기본적으로 명시된다.
        // 내부적으로 Monitor를 사용한다.
        static object _lock = new object();
        static SpinLock _lock2 = new SpinLock();
        // 느리지만 단점만 있는것은 아니다. 같은 프로그램이 아니더라도 순서를 맞추는 동기화 작업을 맞추는데 사용한다. 
        // static Mutex _lock3 = new Mutex();
        // 직접 만든다.        

        // RWLock ReaderWriteLock
        static ReaderWriterLockSlim _lock3 = new ReaderWriterLockSlim();

        // [ ] [ ] [ ]

        class Reward
        {

        }

        // 99.999999, 0.0000001%
        static Reward GetRewardById(int id)
        {
            _lock3.EnterReadLock();
            _lock3.ExitReadLock();

            lock (_lock)
            {

            }
            return null;
        }

        static void AddReward(Reward reward)
        {
            _lock3.EnterWriteLock();
            _lock3.ExitWriteLock();

            lock (_lock)
            {

            }            
        }

        static void Main(string[] args)
        {
            lock (_lock)
            {

            }

            //bool lockTaken = false;
            //try
            //{
            //    _lock2.Enter(ref lockTaken);
            //}
            //finally
            //{
            //    if (lockTaken)
            //        _lock2.Exit();
            //}
        }
    }
}