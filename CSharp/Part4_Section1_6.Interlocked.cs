using System;
using System.Threading;
using System.Threading.Tasks;

namespace ServerCore
{
    class Part4_Section1_6
    {
        static int number = 0;

        static void Thread_1()
        {
            // atomic = 원자성

            // 예 1)
            // 검을 산다고 하면?
            // 골드 -= 100;
            // 서버 다운 -> 골드는 없어지고 인벤에는 안들어간다
            // 인벤 += 검;

            // 예 2)
            // 집행검 User1
            // 집행검 User2 인벤에 넣어라 - Ok
            // 집행검 User1 인벤에서 없애라 - Fail

            for (int i = 0; i < 100000; i++)
            {
                // Interlocked 계얼을 사용할 떄에는 내부에다가 메모리 베리어를 간접적으로 사용해 가시성 문제가 일어나지 않는다.
                // All or Nothing - 원자성으로 인해 둘 중 하나만 먼저 실행하게 된다.
                // number 인자를 넣어주는게 아니라 레퍼런스(ref)로 넣어줬으므로 주소값을 참조해준다. 
                // 이렇게 된 이유는
                // ref를 제외한 number는 인트만 넣어준것인데 이 값을 복사해 Increment 로 넣어준다는 것인데
                // 그 사이 다른 친구들이 복사하여 값을 변경 할 수 있다.

                int afterValue = Interlocked.Increment(ref number);

                // 리턴 값이 있으므로 afterValue의 값이 진짜 값이다.
                /* 이 단계가 3단계에서 이뤄지는게 아니라 한 단계에서 이뤄져야 하는데 그게 아니라 문제가 발생한다. */
                //int temp = number; // 0
                //temp += 1; // 1
                //number = temp; // number = 1;
            }
        }

        static void Thread_2()
        {
            for (int i = 0; i < 100000; i++)
            {
                Interlocked.Decrement(ref number);
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