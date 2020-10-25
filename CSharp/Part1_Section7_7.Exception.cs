using System;
using System.Collections.Generic;
using System.Text;

namespace CSharp
{
    class Part1_Section7_7
    {
        class TestException : Exception
        {
            // 사용자가 직접 예외처리를 만들 때 
        }

        // 게임에서 Try Catch가 필요 없는 이유는?
        // 아래 예시 같은 문제가 나와도
        // 예외처리로 땜빵할 수 엇ㅂ음
        // 한사람만 에러가 뜬다고 예를들면
        // 다른 유저에게 피해가 안가게 하면 되지 않냐?
        // 놉, 이는 코드가 문제가 되서 다른 사람들도 다 발생함

        static void Main (string[] args)
        {
            try
            {
                // 예외가 발생하면
                // 1. 0으로 나눌 때
                // 2. 잘못된 메모리를 참조 (null 메모리를 가지고 있는 참조를 할 때)
                // 3. 복사를 할 때 오버플로우가 발생할 때

                //int a = 10;
                //int b = 0;
                //int result = a / b;

                int c = 0;
                // 얘는 위에서 이미 0 나누기를 하기 때문에 처리가 되지 않는다.

                throw new TestException();
            }
            catch (DivideByZeroException e)
            {
                // 예외라는 공을 던지면 포수라른 catch가 잡는다.
            }
            catch (Exception e)
            {
                // 받아서 여기서 처리해보겠다.
            }
            finally
            {
                // 반드시 실행해야 되는 부분
                // DB, 파일 정리 등등
            }
        }
    }
}
