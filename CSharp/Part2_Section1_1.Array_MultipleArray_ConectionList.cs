using System;
using System.Collections.Generic;
using System.Text;

namespace CSharp
{
    class Part2_Section1_1
    {
        static void Main(string[] args)
        {
            Part2_Section2MakeMap board = new Part2_Section2MakeMap();
            Part2_Section2_Player player = new Part2_Section2_Player();
            board.Initialize(25, player);
            player.Intiallize(1, 1, board);
            
            Console.CursorVisible = false;
            // 커서 가리기

            const int WAIT_TICK = 1000 / 30;

            int lastTick = 0;
            while (true)
            {
                #region 프레임 관리
                // fps 프레임 (60프레임 ok, 30 프레임 이하는 끊긴다.)
                int currenttick = System.Environment.TickCount;
                // 마지막시간과 끝시간을 알기 위해
                // int elaspedtick = currenttick - lasttick;
                // 경과한 시간이 1/30초보다 작다면?
                if (currenttick - lastTick < WAIT_TICK)
                    continue;
                int daltaTick = currenttick - lastTick;
                lastTick = currenttick;
                #endregion

                // 입력
                // 사용자가 키보드나 마우스를 입력했을 때 감지하는 단계
                // 입력에 따라 로직이 실행된다.

                // 로직
                // 특정키를 눌렀을 때 반응 혹은 몬스터 들의 인공지능 등
                player.Update(daltaTick);

                // 렌더링
                // 연산된 게임 세상을 이쁘게 그려주는 것.
                // direX, Open gl
                Console.SetCursorPosition(0, 0);
                board.Render();

                // 커서 포지션
                //Console.WriteLine("Hello, World!");


            }
        }
    }
}
