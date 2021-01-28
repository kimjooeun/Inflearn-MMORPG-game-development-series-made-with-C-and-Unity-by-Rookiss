using System;
using System.Collections.Generic;
using System.Text;

namespace CSharp
{
    class Part2_Section5
    {
        class PrioityQueue
        {
            public void Push(int data)
            {

            }

            public int Pop()
            {
                return 0;

            }

            public int Count()
            {
                return 0;
            }
        }

        static void Main(string[] args)
        {
            PrioityQueue q = new PrioityQueue();
            q.Push(20);
            q.Push(10);
            q.Push(30);
            q.Push(90);
            q.Push(40);

            while (q.Count() > 0)
            {
                Console.WriteLine(q.Pop());
            }
        }

    }
}
