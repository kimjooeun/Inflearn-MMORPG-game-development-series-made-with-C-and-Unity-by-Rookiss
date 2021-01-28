using System;
using System.Collections.Generic;
using System.Text;

namespace CSharp
{
    // 섹션 3 - 스택과 큐
    // 1. 
    // [1] [2] [3] [4]
    // 스택과 큐는 선형 자료구조 자료들이 일렬로 나열된 구조

    // 2.
    // 비선형 자료구조
    // 1 : 多의 관계 (윈도우 탐색기와 같다)

    // 3. 
    // 스택 : LIFO (후입선출 Last in First out)
    // 큐 : FIFO (선입선출 First in first out)

    // 4. 
    // 주차장
    // [1] [2] [3] [4] -> [주차장 입구]
    // 나란히 들어온다 [큐 - 선입선출]

    // 5. 
    // 스택
    // [1] [2] [3] [4] -> [주차장 입구 (사고)]
    // <- [1] [2] [3] [4] -> [1]번부터 나가게 된다
    // 1번부터 나간다 [스택 - 후입선출]

    class Part2_Section3
    {
        static void Main(string[] args)
        {
            // 사용방법
            // 6.
            Stack<int> stack = new Stack<int>();
            Queue<int> queue = new Queue<int>();

            // 7.
            // 어떠한 인터페이스를 제공하는가?

            // 8. 주로 Push, Pop, Peek이 사용된다.
            // 3개 위주로 사용됨

            // 9. 
            //stack.Push(101);
            //stack.Push(102);
            //stack.Push(103);
            //stack.Push(104);
            //stack.Push(105);

            // 10.
            //int data = stack.Pop();
            // 11. 데이터를 엿볼 때
            //int data2 = stack.Peek();

            // 12. 비어있는 상태에서는 Pop과 Peek을 사용하면 크러쉬가 난다.
            // 13. 스택이 비어있는지 확인을 하는 조건문을 만들어준다

            // 14. 어떠한 인터페이스를 제공하는가?
            // 15. 별로 추천하는 창이 뜸
            // 16. Enqueue = 삽입
            //queue.Enqueue(101);
            //queue.Enqueue(102);
            //queue.Enqueue(103);
            //queue.Enqueue(104);
            //queue.Enqueue(105);

            // 17. 데이터 추출
            //int data3 = queue.Dequeue();
            // 18. 데이터를 엿볼 때에
            //int data4 = queue.Peek();

            // 19. 
            //LinkedList<int> list = new LinkedList<int>();
            //List<int> list2 = new List<int>();

            // 20. 밀어서 데이터 삽입이 가능하다
            //list.AddLast(101);
            //list.AddLast(102);
            //list.AddLast(103);


            // 21. 추출
            //// FIFO
            //int value1 = list.First.Value;
            //list.RemoveFirst();

            // 22. 삭제
            //// LIFO
            //int value2 = list.Last.Value;
            //list.RemoveLast();

            // 23. 그럼 왜 링크드리스트를 안쓰고 스택과 큐를 만들었나?
            // 스택 혹은 큐 방식으로 만들거예요 라는 의사소통이 가능함
            // 연결리스트와 동적배열의 축소판이다 (스택과 큐는)

            // 24. 스택과 큐는 게임에 중요한가?
            // 굉장히 중요하다
            // 게임을 클리어 시 팝업이 뜰 때 구매 버튼을 누르면 팝업이 또 뜨는데
            // 이럴 때에 맨 마지막으로 뜬 팝업끄는데 스택(후입선출)을 사용하고
            // 큐같은 경우는
            // 온라인 게임을 만들 때에 네트워크 패킷을 보내는데
            // 어떤 이용자가 옆에 있는 몬스터를 때리고 싶다고 하면
            // 동시에 실행하기 어려우므로 큐를 이용해 순차적으로 들어오는 요청에 따라 진행된다.
            // 이로인해 스택과 큐는 정말 중요한 부분.

        }
    }
}
