using System;
using System.Collections.Generic;
using System.Text;

namespace CSharp
{
    class Part1_Section7_4
    {
        // 1. 
        // 업체 사장님에게 전화할 때
        // 사장님의 비서에게 연갈된다
        // 우리의 용건과 연락처를 비서에게 전달
        // 사장님이 시간이 될 경우
        // 거꾸로 연락을 달라고 한다.
        // 이는 프로그램에서도 빈번하게 일어난다

        // 2. 
        // 가장 대표적인 작업 예로는 UI 작업이다.
        // 어떤 UI 버튼을 눌렀을 때 행동을 지시하는데
        // 예를 들어 빌드 버튼을 누르면 영역이 뜨는 것처럼

        // 8. 실제 델리게이트 사용 예시
        delegate int Onclicked();
        // 유의해야 할 점
        // 함수가 아니라 형식이다.
        // 분석방법
        // delegate > 형식은 형식이지만
        // 함수자체를 인자로 넘겨주는 그런 형식
        // 반환은 int, 입력은 : void
        // 전체 네임 OnClicked이 delegate 형식의 이름이다.

        static void ButtonPressed(Onclicked clickedFunction/* 함수 자체를 인자로 넘겨준다.*/)
        {
            // 3.
            // 버튼이 눌릴 시 어떤 버튼인지 체크해서
            // 플레이러를 공격하는 버튼을 생성한다

            // 5. 
            // 함수를 호출();

            // 9. 함수를 호출
            clickedFunction();

        }

        static int TestDelegate()
        {
            Console.WriteLine("Hello delegate");
            return 0;
        }

        static void Main(string[] args)
        {
            // delegate (대리자)
            
            // 4.
            // Console.WriteLine("Hello. World");
            // 해당 함수를 사용만 했지 수정할 일은 없다.
            // 마찬가지로 버튼 프로세스도 우리가 수정할 수는 방식으로 배포되어 수정 할 수 없다.

            // 6.
            // ButtonPressed(/* */);
            // 호출되는 부분만 잘 연결시켜주기만 하면 된다.
            // 이렇게 역으로 호출하는 방법을 콜백이라고 한다.

            // 7. 엘리게이터는
            // 요약 > 함수 자체를 인자로 넘겨주는 방식

            // 10. 실 사용
            ButtonPressed(TestDelegate);
        }
    }
}
