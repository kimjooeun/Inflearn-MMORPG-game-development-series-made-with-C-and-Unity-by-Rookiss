using System;
using System.Collections.Generic;
using System.Text;

namespace CSharp
{
    class Part1_Section6_5
    {
        class Monster
        {
            public int id;
            public Monster(int id) { this.id = id; }
            
        }

        static void Main (string[] args)
        {
            List<int> list = new List<int>();

            // 몬스터, 플레이어, 모두 ID를 가지며 식별자를 가진다
            // 나는 10의 데미지를 입히는 103번 ID의 몬스터를 공격하고 싶다
            // 10 103

            // 100만마리 몬스터가 있다면?
            // 103번째 몬스터를 찾으려면?
            // 100만개를 하나하나 찾는방법 밖에 없음
            // 이는 너무 느린방법
            // 해결방법은? Key를 가지고 Value를 찾는 방법이 필요
            // 이는 C#에서 Dictionary라는 문법

            Dictionary<int, Monster> dic = new Dictionary<int, Monster>();
            // 딕셔너리랑 리스트의 차이점은?
            // 앞에 있는 값 키를 알면 뒤에 있는 벨류를 굉장히 빠르게 찾을 수 있다.
            // 반대로는 해당되지 않는다. (몬스터를 안다고해서 키값을 찾을 순 없다.)

            for (int i = 0; i < 10000; i++)
            {
                // 삽입
                dic.Add(i, new Monster(i));
            }

            Monster mon;
            // 특정 몬스터를 찾을 때
            bool found = dic.TryGetValue(7777, out mon);

            // 삭제
            dic.Remove(7777); // 특정위치 삭제
            dic.Clear(); // 전체삭제

            // 딕셔너리가 어떻게 이렇게 빠르게 찾을 수 있는가?
            // Hashtable 이라는 기법을 사용함
            // 아주 큰 박스안에 공들이 있다. 1만개 (공에는 1에서 ~ 1만 번호가 기재되어 있다.)
            // 특정 번호의 공을 찾기 위해서는 하나씩 꺼내보는 방법 밖에 없다.
            // 박스 여러개를 쪼개 놓는다면? 박스를 천개를 사용하면 [1~10] [11~20] ... 많은 박스에 넣어준다
            // 7777번을 찾고 싶으면 10개씩 나눠놓았으므로 777번 상자에 있다는 것을 알 수 있다.
            // 이는 메모리를 손해보지만 [메모리를 내주고, 성능을 취한다!]는 방법이다.
        }
    }
}
