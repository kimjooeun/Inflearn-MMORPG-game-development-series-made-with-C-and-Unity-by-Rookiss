using System;
using System.Collections.Generic;
using System.Text;

namespace CSharp
{
    class Part1_Section7_3_Property_
    {
        // 객체지향 -> 은닉성(불필요한 정보를 외부로 노출하지 않겠다)
        // 2. Kngiht로 드는 예시
        class Kngiht
        {
            // public int hp;
            // 그래서 객체지향에서는 은닉성을 이용해 외부에서 차단을 한다.
            protected int hp;

            // 6. C#에서는 아래에 기능이 많아지는 것들을 편리하게 하기 위해 Property가 있다.
            public int Hp // Get과 Set을 동시에 이용하는 Property 
            {
                get { return hp; }
                set { hp = value; }
            }

            // 4. 아래 함수는 Getter Get함수라 하며
            //public int GetHp() { return hp; }

            // 5. 아래 함수는 Setter Set 함수라고 한다.
            //public void SetHp(int hp) { if(무적체크) this.hp = hp; }
            // 4. 이어서)위와 같이 설정을 하여 이용하게끔 한다.
            // 이 기능을 확장한다고 하면?
            // 특정 조건을 붙인다. 예) 무적이 아닐때만 HP를 수정할 수 있게
        }

        static void Main (string[] args)
        {
            // 1. 프로퍼티.
            Kngiht kngiht = new Kngiht();
            kngiht.hp = 100;
            kngiht.hp = 40;
            // 2. 이어서) 코드가 많아 질 시 hp가 변경 될 시 찾기가 어려워진다.
            // 3. 이로 인해 사용법이 바뀌어지는데 이는 아래와 같이 접근하면 된다.
            kngiht.SetHp(100);

            // 7. Property의 활용
            kngiht.Hp = 100; // 이는 Value로 해당되며
            int hp = kngiht.Hp; // 이는 Return으로 해당된다.
            // set은 값을 넣어줄때 사용하며
            // get은 값을 꺼내올때 사용한다.
            // 또한 Get과 Set중 둘중 하나가 없어도 사용 가능하다.

            // 8. 자동 구현 Property
            //    class Knight
            //{
            //    public int HP
            //    {
            //        get; set;
            //    }
            //}
            // 이를 풀어쓰면 
            // private int _hp;
            // public int getHp() { return hp; }
            // public void SetHp(int value) { _hp = value; }
            // 가 된다.

            // 자동 구현 Property를 사용하면 아주 많은 필드를 한줄짜리로 구현할 수 있는 장점이 있다.
            // 예) pulbic int Hp { get; set; } = 100;
            // 
        }
    }
}
