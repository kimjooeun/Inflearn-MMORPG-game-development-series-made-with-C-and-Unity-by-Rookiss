using System;
using System.Collections.Generic;
using System.Text;

namespace CSharp
{
    class Part1_Section7_5
    {
        static void OnInputTest()
        {
            Console.WriteLine("Input Received!");
        }

        static void Main (string[] args)
        {
            Part1_Section7_5_Evene_InputManager inputManager = new Part1_Section7_5_Evene_InputManager();

            inputManager.InputKey += OnInputTest;
            // 여기다가 이벤트를 연결하면 된다.
            // 이 부분이 구독신청하는 부분

            while (true)
            {
                inputManager.Update();
            }
              
            //inputManager.InputKey()
            // 강제로 이벤트를 호출할 수 없다
            // 멋대로 호출할 수 없다는 차이가 있음
            // 우리가 유일하게 할 수 있는것은 구독신청과 취소를 하는것임
            // 실질적으로 인풋키를 호출하는 행위는 할 수 없음.
            // 이부분이 이벤트와 델리게이트의 차이.
            // 그냥 콜백 방식임.
        }
    }
}
