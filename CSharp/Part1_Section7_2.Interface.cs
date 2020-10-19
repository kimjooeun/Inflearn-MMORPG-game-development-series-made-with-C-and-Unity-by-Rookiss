using System;
using System.Collections.Generic;
using System.Text;

namespace CSharp
{
    class Part1_Section7_2_Interface_
    {
        abstract class Monster // 5. abstract 기능을 사용해 추상클래스로 적용
        {
            public abstract void Shout(); // 3. 모든 몬스터는 반드시 샤우팅을 한다는 기능을 추가한다고 할 시, abstract 기능을 사용.
            // 7. 아울러 추상적으로 만든 함수안에서는 함수들도 추상적으로 만들 수 있다.
            // 개념적으로 존재할 뿐 선언(정의) 할 수 없다.
            // 그럼 개념적으로 존재하는데 어떤 의미가 있나?
            // 이제 조금 다르게 Monster를 상속 받는 애들은 반드시 override를 사용해야 한다.
            // Monster를 상속 받는 애들한테 Shout를 사용해라를 강요함.
            // 어떠한 기능을 반드시 추가하고 싶다는 것은 시그니처므로 인터페이스가 된다.            
        }

        // 8. 그럼 강요를 여러개 하고 싶을 때에는?
        abstract class Flyable
        {
            public abstract void Fly();
            // 8. Flyable을 상속받는 애들이 날라다니는 기능을 강요할 시
        }

        // 11. interface를 사용한 flyable
        interface iFlayable
        {
            void Fly();
            // 11. 인터페이스를 선언했을 시 접근제어 형상자를 사용할 필요가 없다.
            // 이 함수는 iFlayable의 기능을 가지고 있는 애라면 Fly함수를 이용해야 한다.
            // 그러나 딱히 Fly의 어떻게 구현되었는지 물려주지 않는다. 
            // 이로 인해 FlyableOrc 다시금 구현한다면?
        }

        class Orc : Monster
        {
            public override void Shout() // 4. 오버라이드를 이용하여 사용했다.
            {
                Console.WriteLine("독타르 오가르!");
            }
        }

        // 9. 날아다는 오크를 생성한다고 가정 할 시
        // Orc와 Flyable을 동시에 상속받아야 한다.
        // 그러나 C#에서는 다중 상속이 불가능 함.
        class FlyableOrc : Orc, Flyable
        {
            // 다중상속이 비추천 되는 이유 : 죽음의 다이아몬드라는 문제가 있다.
            // Orc와 Skeleton 만드면서 Shout를 오버라이딩하여 각자 목소리를 사용한다.
            // 그럼 SkeletonOrc가 생성될 경우에는?
        }

        // 12. 다시 만드는 FlyableOkc
        class FlyableOrc : Orc, iFlayable
            // 이렇게 구현하게 되면 날아다는 오크를 생성 할 수 있다.
        {
            public void Fly()
            {

            }
        }

        class Skeleton : Monster
        {
            public override void Shout() // 4. 오버라이드를 이용하여 사용했다.
            {
                Console.WriteLine("꾸에에엑!");
            }
        }
        // 2. 몬스터를 상속받은 오크와 스켈레톤 생성

        // 10. SkeletonOrc
        class SkeletonOrc : Orc, Skeleton
        {
            // 그럼 이 상황에서 Orc와 Skeleton의 Shout에서 어떤 부분의 Shout이 출력되어야 할까?
            // 이로 인해 C#에서는 문법적으로 다중상속을 허락하지 않는다.
            // 그렇다면 다중상속이 어떤 부분에서 문제가 되는 걸까?
            // 같은 시그니처 즉 Shout로 구성된 함수가 각기 다른 구현부를 물려받았기 때문에 문제가 된다.
            // 그렇다는 것은 인터페이스는 물려주고, 구현부는 물려주지 않고 함수 내에서 알아서 하게끔 만들면? 
            // 상속의 문제를 해결 할 수있다.
            // 이를 해결하기 위해서는 C#에서 제공하는 interface를 사용하면 된다.
        }

        static void Main(string[] args)
        {
            // 1. 추상클래스와 인터페이스
            // 6. 추상클래스는 인스턴스를 만들 수 없음. 즉 몬스터는 추상적으로 사용해야 하므로 강제로 사용하는 것은 사용 불가
            // Monster monster = new Monster();
        }

        // 13. 결론
        // 추상클래스, 인터페이스를 사용하는 이유는 특정 클래스가 내가 원하는 인터페이스(시그니처)에 기능을 제공하기를 원해서 사용
        // 이럴때 사용할 수 있는 기능이 추상화(abstract)를 사용한다.
        // 그러나 abstract의 단점은 여러개의 부모를 동시에 가질 수 없으므로 사용할 수 있는 범위가 한정적이다.
        // 이로 인해 Interface를 사용하여 구현은 하지 않고 기능(모양)만 들고 있을 시
        // 이 Interface를 사용하는 함수는 반드시 해당 기능을 구현해야 한다.
        // Interface의 장점은 여러개의 Interface를 동시에 가져도 아무런 문제가 없다.
        // abstract는 다중상속이 불가능하여 사용범위가 제한적이다.
    }
}
