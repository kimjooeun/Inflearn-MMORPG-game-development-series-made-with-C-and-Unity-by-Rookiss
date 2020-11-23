using System;
using System.Collections.Generic;
using System.Text;

namespace CSharp
{
    // [1] [2] [3] [4]
    // 스택과 큐는 선형 자료구조 자료들이 일렬로 나열된 구조

    // 비선형 자료구조
    // 1 : 다의 관계

    // 스택 : LIFO(후입선출 Last in First out)
    // 큐 : FIFO(선입선출 First in first out)

    // 주차장
    // [1] [2] [3] [4] -> [주차장 입구]
    // 나란히 들어온다 [큐]

    // 스택
    // [1] [2] [3] [4] -> [사고]
    // <- [1] [2] [3] [4] 
    class Part2_Section3
    {
        static void Main(string[] args)
        {
            Stack<int> stack = new Stack<int>();
            Queue<int> queue = new Queue<int>();

            //stack.Push(101);
            //stack.Push(102);
            //stack.Push(103);
            //stack.Push(104);
            //stack.Push(105);

            //int data = stack.Pop();
            //int data2 = stack.Peek();

            //queue.Enqueue(101);
            //queue.Enqueue(102);
            //queue.Enqueue(103);
            //queue.Enqueue(104);
            //queue.Enqueue(105);

            //int data3 = queue.Dequeue();
            //int data4 = queue.Peek();

            //LinkedList<int> list = new LinkedList<int>();
            //List<int> list2 = new List<int>();

            //list.AddLast(101);
            //list.AddLast(102);
            //list.AddLast(103);

            //// FIFO
            //int value1 = list.First.Value;
            //list.RemoveFirst();

            //// LIFO
            //int value2 = list.Last.Value;
            //list.RemoveLast();
        }
    }
}
