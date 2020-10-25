using System;
using System.Collections.Generic;
using System.Text;

namespace CSharp
{
    class Part1_Section7_9
    {
        class Monster
        {
            public int Id { get; set; }
        }

        static Monster FindMonster(int id)
        {
            // for ()
            // return monster;
            return null;
        }

        static int Find()
        {
            return 0;
        }

        static void Main (string[] args)
        {
            // Nullable > null + able
            // Monster monster = FindMonster(101);
            if (monster != null)
            {

            }
            int? number = 5;

            //number = 3;
            if (number != null)
            {
                int a = number.Value;
                Console.WriteLine(a);
            }

            if (number.HasValue)
            {
                int a = number.Value;
                Console.WriteLine(a);
            }

            int b = number ?? 0;
            Console.WriteLine(b);
            // number가 널이 아니라고 한다면 널 안에다가 number.Value; 뽑아와서 b에 넣어주고 그게 아니라 널이면 초기값으로 입력한 0이 대입된다.

            Monster monster = null;
            if (monster != null)
            {
                int monsterId = monster.Id;
            }

            // 
            int? id = monster?.Id;
            // 몬스터라는 변수가 널이 아닌지 체크해 널이 아니라고 할 시 ID의 값을 가져와서 id에 넣엉주고
            // 만약 널이라고 하면 그냥 널을 넣어주세요.
            //if (monster == null)
            //{
            //    id = null;
            //}
            //else
            //{
            //    id = monster.Id;
            //}
            // 위 예제는 int? id = monster?.Id;와 같다.

        }
    }
}
