using System;
using System.Collections.Generic;
using System.Text;

namespace CSharp
{
    class Part1_Section6_4
    {
        static void Main(string[] args)
        {
            int[] arr = new int[10];
            arr[0] = 1;
            // arr[20]; > 충돌
            // 이 배열은 이미 할당되어 있어 수정이 불가능하다.
            // 그러면 어떻게 할까?

            // int[] arr2 = new int[1000];
            // 이는 메모리 낭비로 이어진다.

            // List < 동적배열
            List<int> list = new List<int>(); // [ 1 2 3 ] 이였을 시
            for (int i = 0; i < 5; i++)
            {
                list.Add(i); // [ 1 2 3 4 ]가 된다.
            }

            for (int i = 0; i < list.Count; i++)
            {
                Console.WriteLine(list[i]) ;
            }

            foreach (int num in list)
            {
                Console.WriteLine(num);
            }

            // 배열에서는 사용할 수 있지만 리스트에서는 사용할 수 없는 기능
            // 삽입, 삭제
            // [0, 1, 2, 999, 3, 4]로 만들고 싶을 시
            list.Insert(2, 999);

            // 삭제
            bool success = list.Remove(3); // 중복된 3의 값들이 여러개 있을 시 맨 앞에 있는 3만 제거 한다.
            list.RemoveAt(0); // 특정 위치에 있는 애들을 삭제할 떄 i번째
            list.Clear(); // 리스트 전체삭제
        }
    }
}
