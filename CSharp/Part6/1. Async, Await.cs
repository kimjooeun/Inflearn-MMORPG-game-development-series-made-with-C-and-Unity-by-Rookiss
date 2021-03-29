using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Study_CSharp
{
    // async/await
    // async 이름만 봐도.. 비동기 프로그래밍!
    // 게임서버) 비동기 = 멀티쓰레드? > 꼭 그렇지많은 않는다./
    // 유니티) Coroutine = 일종의 비동기 but 싱글쓰레드

    class Program
    {
        static Task Test()
        {
            Console.WriteLine("Start Test");
            Task t = Task.Delay(3000);
            return t;
        }

        // 아이스 아메리카노를 제조중 (1분)
        // 주문 대기
        static async Task<int> TestAsync()
        {
            Console.WriteLine("Start TestAsync");
            await Task.Delay(3000); // 복잡한 작업 (ex. DB나 파일 작업)
            Console.WriteLine("End TestAsync");
            return 1;
        }

        static async Task Main(string[] args)
        {
            Task<int> t = TestAsync();

            // 다른 일을 할 수도 있는
            Console.WriteLine("While Start");

            int ret = await t;
            Console.WriteLine(ret);

            while (true)
            {

            }
        }
    }
}
