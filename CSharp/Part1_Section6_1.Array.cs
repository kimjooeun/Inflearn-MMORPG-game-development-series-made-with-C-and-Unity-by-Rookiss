using System;
using System.Collections.Generic;
using System.Text;

namespace CSharp
{
    class Player
    {

    }
    
    class Monster
    {

    }

    class Part1_Section6_Array
    {
        Player player;
        Monster monster;

        static void Main (string[] args)
        {
            // 배열
            int a;
            int[] scores0 = new int[] { 10, 20, 30, 40, 50 };
            // 1번 사용법
            int[] scores1 = new int[5] { 10, 20, 30, 40, 50 };
            // 2번 사용법
            int[] scores2 = { 10, 20, 30, 40, 50 };
            // 3번 사용법


            // 0 1 2 3 4
            //scores[0] = 10;
            //scores[1] = 20;
            //scores[2] = 30;
            //scores[3] = 40;
            //scores[4] = 50;

            for (int i = 0; i < scores0.Length; i++)
            {
                Console.WriteLine(scores0[i]);
            }

            foreach (int score in scores0)
            {
                Console.WriteLine(score);
            }
            // 위 코드는 둘다 동일하다.
        }
    }
}
