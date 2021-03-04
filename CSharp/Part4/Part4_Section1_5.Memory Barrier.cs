﻿using System;
using System.Threading;
using System.Threading.Tasks;

namespace ServerCore
{
    // 메모리 배리어
    // A) 코드 재배치 억제
    // B) 가시성

    // 1) Full Memory Barrier (ASM MFENCE, C# Thread.MemoryBarrier) : Store/Load 둘 다 막는다.
    // 2) Store Memory Barrier (ASM SFENCE) : Store만 막는다
    // 3) Load Memory Barrier (ASM LFENCE) : Load만 막는다

    class Part4_Section1_5
    {
        // 예 1
        static int x = 0;
        static int y = 0;
        static int r1 = 0;
        static int r2 = 0;

        static void Thread_1()
        {
            y = 1;      // Store y
            Thread.MemoryBarrier();
            r1 = x;     // Load x
        }

        static void Thread_2()
        {
            x = 1;      // Store x
            Thread.MemoryBarrier();
            r2 = y;     // Load y
        }

        /* 위와는 다른 예제 */
        // 예 2
        int _answer;
        bool _complete;

        void A()
        {
            _answer = 123;
            Thread.MemoryBarrier(); // Barrier 1

            _complete = true;
            Thread.MemoryBarrier(); // Barrier 2
        }

        void B()
        {
            Thread.MemoryBarrier(); // Barrier 3

            if (_complete)
            {
                Thread.MemoryBarrier(); // Barrier 4
                Console.WriteLine(_answer);
            }
        }

        static void Main(string[] args)
        {
            // 예 1에 대한 내용
            int count = 0;

            while (true)
            {
                count++;
                x = y = r1 = r2 = 0;

                Task t1 = new Task(Thread_1);
                Task t2 = new Task(Thread_2);

                t1.Start();
                t2.Start();

                Task.WaitAll(t1, t2);

                if (r1 == 0 && r2 == 0)
                {
                    break;
                }
            }
            Console.WriteLine($"{count}번 만에 빠져나왔습니다.");
        }
    }
}