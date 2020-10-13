using System;

namespace CSharp
{
    class Program
    {
        // 여기에 주석을 달 수 있어요.
        // 주석의 문법으로는 1. /* */ 2. //이 있다.
        static void Main(string[] args)
        {
            // 데이터 + 로직
            // 체력 0
            // 자연수: 1, 2, 3, 4, 5, 10, 100
            // 정수 : -15, 0, 15

            // byte(1바이트 0-255), short(2바이트 -3만 ~ +3만), int(4바이트 -21억 ~ 21억), long(8바이트)
            // sbyte(1바이트 -128 ~ 127), ushort(2바이트 0 ~ +6만), uint(4바이트 0 ~ 43억), ulong(8바이트)

            int hp;
            short level = 100;
            long id1;

            hp = 100;

            byte attack = 0;
            attack--;

            // 10진수
            // 00 01 02 03 04 05 06 07 08 09
            // 10

            // 2진수
            // 0~1
            // 0b00, 0b01, 0b10, 0b11, 0b100
            // 0b10001111 = 0x8F

            // 16진수
            // 0~9 a b c d e f
            // 0x00, 0x01, 0x02 .. 0x0F
            // 0x10

            bool booltest;
            // 참 혹을 거짓을 갖는 값 (True, False), 1바이트
            booltest = true;
            booltest = false;

            // 소수 : 딱 떨어지는 정수가 아닌 소숫점을 가지는 숫자.
            float floattest = 3.14f; // 4바이트
            double doubletest = 3.14; // 8바이트

            // 캐릭터타입 2바이트
            char chartest = '가'; //한자, 한문, 영어 모두 상관없이 저장 가능. 딱 하나의 단어만 저장이 가능하다.
            // 스트링타입 
            string str = "Hello, World \n";
            Console.WriteLine(str);

            // 1. 바구니 크기가 다른 경우!
            int a = 0xFFFFF;
            short b = (short)a;

            // 2. 바구니 크기는 같으나, 부호가 다를 경우
            byte c = 255;
            sbyte sb = (sbyte)c;
            // underflow(언더플로우), overflow(오버플로우)

            // 3. 소수
            float f = 3.1414f;
            double d = f;

            // 비트연산자
            int id2 = 123;
            int key2 = 401;

            int a1 = id2 ^ key2;
            int b1 = a1 ^ key2;

            Console.WriteLine(a1);
            Console.WriteLine(b1);

            // 위에 내용은 ^(Xor)를 이용한 암호화.

            int num = 8;

            // << >> &(and) |(or) ^(xor) ~(not)
            num = num >> 3;
            Console.WriteLine(num);

            Console.WriteLine("Hello Number ! {0}", attack);

            // 할당 연산

            int a3;
            a3 = 100;

            int b3;
            b3 = a3;

            a3 += 1;
            a3 -= 1;
            a3 *= 1;
            a3 /= 1;
            a3 %= 1;
            a3 <<= 1;
            a3 >>= 1;
            a3 &= 1;
            a3 |= 1;
            a3 ^= 1;

            int a4 = (3 + 2) * 3;

            // 우선순위 1. ++ --
            // 2. * / %
            // 3. + -
            // 4. << >>
            // 5. < >
            // 6. == !=
            // 7. &
            // 8. ^
            // 9. |
            // ..

            //  우선순위를 모르기 때문에 괄호를 이용하여 작성할 것.

            var num2 = 3;
            var num3 = "Hello World";

            // var가 알아서 형변환을 해주지만 타인이나 제 3자가 볼 경우 코드의 내용을 알기 위해 int, string 형의 형식적인 표현을 이용하자.
        }
    }
}