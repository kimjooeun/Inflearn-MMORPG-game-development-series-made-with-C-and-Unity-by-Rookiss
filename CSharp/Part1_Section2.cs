using System;
using System.Collections.Generic;
using System.Text;

namespace CSharp
{
    class Part1_Section2
    {
        // 상수와 열거형 - 열거형
        enum Choice
        {
            Rock = 1,
            Paper = 2,
            Scissors = 0
        }

        // 함수
        static void HelloWorld()
        {
            Console.WriteLine("Hello, World");
        }

        static int Add(int a, int b)
        {
            Console.WriteLine("Add int 호출");
            int result = a + b;
            return result;
        }

        static void AddOne(ref int number)
        {
            number += 1;
        }

        static int AddOne2(int number)
        {
            return number + 1;
        }

        static void swap(ref int a, ref int b)
        {
            int temp = a;
            a = b;
            b = temp;
        }

        static void Divide(int a, int b, out int result1, out int result2)
        {
            result1 = a / b;
            result2 = a % b;
        }

        static float Add(float a, float b)
        {
            Console.WriteLine("Add float 호출");
            return a + b;
        }

        static int Add(int a, int b, int c)
        {
            Console.WriteLine("Add int 호출");
            return a + b + c;
        }

        static int Factorial(int n)
        {
            int ret = 1;
            for (int num = 1; num <= n; num++)
            {
                ret *= num;
            }
            return ret;
        }

        static int Factorial2(int n)
        {
            if (n <= 1)
                return 1;
            return n * Factorial2(n - 1);
        }

        static void Main(string[] args)
        {
            // 상수와 열거형 - 상수
            //const int ROCK = 1;
            //const int PAPER = 2;
            //const int SCISSORS = 0;

            // if와 else
            int hp = 10;
            bool isDead = (hp <= 0);

            if (isDead)
            {
                Console.WriteLine("You are dead!");
            }
            else
            {
                Console.WriteLine("You are alive!");
            }

            int choice1 = 0; // 0 : 가위, 1 : 바위, 2 : 보, 3 : 치트키

            if (choice1 == 0)
            {
                Console.WriteLine("가위입니다.");
            }

            else if (choice1 == 1)
            {
                Console.WriteLine("바위입니다.");
            }

            else if (choice1 == 2)
            {
                Console.WriteLine("보입니다.");
            }

            else
            {
                Console.WriteLine("치트키입니다.");
            }

            // switch
            switch (choice1)
            {
                case 0:
                    Console.WriteLine("가위입니다.");
                    break;

                case 1:
                    Console.WriteLine("바위입니다.");
                    break;

                case 2:
                    Console.WriteLine("보입니다.");
                    break;

                case 3:
                    Console.WriteLine("치트키입니다.");
                    break;

                default:
                    Console.WriteLine("다 실패했습니다.");
                    break;
            }

            // 삼항연산자

            int number1 = 25;
            bool isPair = ((number1 % 2) == 0 ? true : false);

            // 가위-바위-보 게임
            // 0 : 가위, 1 : 바위, 2 : 보

            Random rand = new Random();
            int AIChoice = rand.Next(0, 3); // 0~2사이의 랜덤 값
            int choice2 = Convert.ToInt32(Console.ReadLine()); // 사람의 입력을 받는 곳

            switch (choice2)
            {
                case (int)Choice.Scissors:
                    Console.WriteLine("당신의 선택은 가위입니다.");
                    break;

                case (int)Choice.Rock:
                    Console.WriteLine("당신의 선택은 바위입니다.");
                    break;

                case (int)Choice.Paper:
                    Console.WriteLine("당신의 선택은 보입니다.");
                    break;
            }

            switch (AIChoice)
            {
                case (int)Choice.Scissors:
                    Console.WriteLine("컴퓨터의 선택은 가위입니다.");
                    break;

                case (int)Choice.Rock:
                    Console.WriteLine("컴퓨터의 선택은 바위입니다.");
                    break;

                case (int)Choice.Paper:
                    Console.WriteLine("컴퓨터의 선택은 보입니다.");
                    break;
            }

            // 승리 무승부 패배
            if (choice2 == 0)
            {
                if (AIChoice == 0)
                {
                    Console.WriteLine("무승부입니다.");

                }
                else if (AIChoice == 1)
                {
                    Console.WriteLine("패배입니다.");
                }
                else
                {
                    Console.WriteLine("승리입니다.");
                }
            }

            else if (choice2 == 1)
            {
                if (AIChoice == 0)
                {
                    Console.WriteLine("승리입니다.");
                }
                else if (AIChoice == 1)
                {
                    Console.WriteLine("무승부입니다.");
                }
                else
                {
                    Console.WriteLine("패배입니다.");
                }
            }

            else // choice2 == 2
            {
                if (AIChoice == 0)
                {
                    Console.WriteLine("패배입니다.");
                }
                else if (AIChoice == 1)
                {
                    Console.WriteLine("승리입니다.");
                }
                else
                {
                    Console.WriteLine("무승부입니다.");
                }
            }

            // While 반복문

            int count = 5;

            while (count > 0)
            {
                Console.WriteLine("Hello World");
                count--;
            }

            // 거울아 거울아~
            string answer;

            do
            {
                Console.WriteLine("강사님은 잘생기셨나요? (y/n) : ");
                answer = Console.ReadLine();

            } while (answer != "y");

            Console.WriteLine("정답입니다.");

            // For문
            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine("Hello World");
            }

            // break, continue 문
            int num1 = 97; // 1과 97로만 나뉘는 숫자
            bool isPrime = true;

            for (int i = 2; i < num1; i++) // 소수 판별 로직
            {
                if ((num1 % i) == 0)
                {
                    isPrime = false;
                    break;
                }
            }

            if (isPrime)
            {
                Console.WriteLine("소수입니다.");
            }
            else
            {
                Console.WriteLine("소수가 아닙니다.");
            }

            // continue문

            for (int i = 1; i <= 100; i++)
            {
                if ((i % 3) == 0)
                {
                    continue;
                }

                Console.WriteLine($"3으로 나뉘는 숫자 발견 : {i}");
            }

            // 함수 = (Method) (위에 있음)
            HelloWorld();
            int result = Add(4, 5);
            Console.WriteLine(result);

            // 복사 (짭퉁), 참조(진퉁)
            // 참조 (진퉁)을 사용시 ref 사용
            // 복사 (짭퉁)을 사용시 그냥 사용
            int a = 0;
            AddOne(ref a);
            Console.WriteLine(a);

            a = AddOne2(a);
            Console.WriteLine(a);

            // ref, out
            // ref를 이용해 값을 swap하는 경우 사용.
            int num2 = 1;
            int num3 = 2;
            swap(ref num2, ref num3);
            Console.WriteLine(num2);
            Console.WriteLine(num3);

            // 여러개의 값을 반환할 때에는 out 키워드를 사용.
            int num4 = 10;
            int num5 = 3;
            int result1, result2;
            Divide(10, 3, out result1, out result2);
            Console.WriteLine(result1);
            Console.WriteLine(result2);

            // 오버로딩 = 이름의 재사용
            int ret = Part1_Section2.Add(2, 3);
            float ret2 = Part1_Section2.Add(2.0f, 3.0f);
            int ret3 = Part1_Section2.Add(2, 3, 4);

            //Console.WriteLine(ret);
            
            // 연습문제
            // 구구단
            for (int i = 2; i <= 9; i++)
            {
                for (int j = 1; j <= 9; j++)
                {
                    Console.WriteLine($"{i} * {j} = {i * j}");
                }
            }

            // 별찍기
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j<=i; j++)
                {
                    Console.Write("*");
                }
                Console.WriteLine();
            }

            // 팩토리얼
            // 5! = 5 * 4 * 3 * 2 * 1
            // n! = n * (n-1) * ... * 1 (n >= 1)
            int ret4 = Factorial(5);
            Console.WriteLine(ret4);

            // 재귀함수 팩토리얼
            int ret5 = Factorial2(5);
            Console.WriteLine(ret5);

        }
    }
}