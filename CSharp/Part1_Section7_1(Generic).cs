using System;
using System.Collections.Generic;
using System.Text;

namespace CSharp
{
    class Part1_Section7
    {

        // 2. 일반화 - 나만의 특별한 리스트 생성
        class MyIntList
        {
            int[] arr = new int[10];

        }
        class MyFloatList
        {
            float[] arr = new float[10];

        }

        class MyShortList
        {
            short[] arr = new short[10];

        }

        // 3. 이런식으로 하나씩 늘리는건 비 효율적.
        class MyMonsterList
        {
            Monster [] arr = new Monster[10];
        }

        // 3, 13
        class Monster 
        {

        }

        // 4. 몬스터가 생성될때마다 몬스터 리스트를 생성해야 하므로 비효율적.
        // 다른 옵션으로 모든 타입을 소화할 수 있는 Object 타입을 사용.

        //class MyList
        //{
        //    object[] arr = new object[10];
        //}
        // 10. 모든 것들을 Object로 사용하면 과부화!

        // 22. 인자를 그냥 늘려주면 된다!
        class MyList <T>
        {
            T[] arr = new T[10];
            
            // 15. 클래스내부에서 사용할 때에는?
            // i번째 아이템을 반환하는 함수
            public T GetItem(int i)
            {
                return arr[i];
                // arr이라는 배열 자체가 T라는 형식으로 되어 있으므로 반환할떄도 T 타입으로 반환하면 됨.
            }
        }
        // 11. 일반화 클래스. T타입에 대해 어떤 값을 넣어도 동작이 되게끔 설정.

        // 18. 함수도 일반화를 할 수 있다. (int형, float형, Monster형 즉 어떤 값을 넣어도 그에 맞는 타입에 맞는다고 가정할 시)
        // 위 문법과 똑같이 꺽쇠 안에 타입을 적어주면 된다. 
        static void Test <T> (T input)
        {

        }


        static void Main (string[] ages)
        {
            // 1. 일반화(Generic)
            List<int> list;
            List<float> list2;

            // 5. Object 타입 사용 (어떤 타입이도 다 소화가 가능)
            object obj = 3;
            object obj2 = "Hello world";

            int num = (int)obj;
            string str = (string)obj2;

            // 6. 그럼 Var 타입은?
            var obj3 = 3;
            var obj4 = "Hello world";

            // 7. 그럼 Object와 Var가 똑같은 것 아니냐?
            // 아니다. 완전히 다른개념
            // var는 뒤에 있는 아이를 보고 컴파일러가 때려 맞추는 것.
            // Object는 타입이 Object 그 자체가 되는 것. 이 차이다.

            // 8. 그러면 모든 타입을 Object로 사용하면 안되냐?
            // 결론 = X, 오브젝트에서 데이터를 넣고 빼는 것은 속도가 매우 느림.
            // int number = 3; 스택에 들어가는 정보로 간편하게 사용할 수 복사 타입의 변수
            // But, Object는 참조타입으로 동작을 안함. 참조타입은 힙에 메모리를 할당하므로 복잡한 연산을 할당하고 있음.

            // 12. 그러면 실제 사용 방법은?
            MyList<int> myintList = new MyList<int>();
            MyList<short> myshortList = new MyList<short>();
            MyList<Monster> myMonsterList = new MyList<Monster>();
            // 13. 몬스터도 들어갈 수 있다.

            // 14. T라는 매개변수는 모든 타입에 돌어가는 만능상자!
            // 16. 그럼 15번을 실제 사용할때에는?
            int item = myintList.GetItem(0);
            // 17. 반환하는 타입은 int 타입으로 반환을 하게 된다.

            // 19. 그럼 18번을 테스트 할 때에는?
            Test<int>(3);
            Test<float>(3.0f);
            // 20. 위와 같이 응용할 수 있다.
            // 21. 그러면 인자가 늘어가는 경우에는?
            // 23. 예를들어 딕셔너리를 사용할 경우에는
            // Dictionary<int, Monster> 아래와 같이 사용할 수 있다.
        }
    }
}
