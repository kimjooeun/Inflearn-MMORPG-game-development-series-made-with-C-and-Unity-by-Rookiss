using System;
using System.Collections.Generic;
using System.Text;

namespace CSharp
{
    // 아래와 같은 방식은 Observer Pattern 이라고 불린다.
    class Part1_Section7_5_Evene_InputManager
    {
        // 콜백
        public delegate void OnInputKey();
        public event OnInputKey InputKey;

        public void Update()
        {
            if (Console.KeyAvailable == false)
                return;

            ConsoleKeyInfo info = Console.ReadKey();
            if (info.Key == ConsoleKey.A) // 만약 유저가 입력한 키가 A라면
            {
                // 모두한테 A를 입력했다는 사실을 알려준다.
                InputKey();
                // 키가 궁금하면 구독하면 된다.
                // 구독이란 용어가 유튜브가 생각되는데 이는 진짜 유튜브 구독이랑 비슷하다
                // 관심있는 유튜버를 구독하면 유튜버의 새 동영상을 올리면 나한테도 새 영상이 뜨는데
                // 이와 마찬가지로 작동된다.
                // Update에서 A키를 입력하면 구독신청 한 사람들에게만 메시지가 간다.
            }
        }
    }
}
