using System;
using System.Collections.Generic;
using System.Text;

namespace CSharp
{
    class Part2_Section0_1
    {
        static void Main (string[] args)
        {
            Console.CursorVisible = false;
            // 커서 가리기

            const int WAIT_TICK = 1000 / 30;
            const char CIRCLE = '\u25cf';

            int lastTick = 0;
            while (true)
            {
                // 입력
                // 사용자가 키보드나 마우스를 입력했을 때 감지하는 단계
                // 입력에 따라 로직이 실행된다.

                // 로직
                // 특정키를 눌렀을 때 반응 혹은 몬스터 들의 인공지능 등

                // 렌더링
                // 연산된 게임 세상을 이쁘게 그려주는 것.
                // direX, Open gl

                Console.SetCursorPosition(0, 0);
                // 커서 포지션
                Console.WriteLine("Hello, World!");

                #region 프레임 관리
                // FPS 프레임 (60프레임 Ok, 30 프레임 이하는 끊긴다.)
                int currentTick = System.Environment.TickCount;
                // 마지막시간과 끝시간을 알기 위해
                // int elaspedTick = currentTick - lastTick;
                // 경과한 시간이 1/30초보다 작다면?
                if (currentTick - lastTick < WAIT_TICK)
                    continue;
                lastTick = currentTick;
                #endregion

                for (int i = 0; i < 25; i++)
                {
                    for (int j= 0; j<25; j++)
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.Write(CIRCLE);
                    }
                    Console.WriteLine();
                }
            }
        }
    }
}
