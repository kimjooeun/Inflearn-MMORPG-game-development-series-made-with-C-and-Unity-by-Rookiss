using System;
using System.Collections.Generic;
using System.Text;

namespace CSharp
{
    class Part1_Section6_3
    {
        class Map
        {
            int[,] tiles = {
                { 1, 1, 1, 1, 1},
                { 1, 0, 0, 0, 1},
                { 1, 0, 0, 0, 1},
                { 1, 0, 0, 0, 1},
                { 1, 1, 1, 1, 1}
            };

            public void Render()
            {
                var defaultColor = Console.ForegroundColor;

                for (int y = 0; y < tiles.GetLength(1); y++)
                {
                    for (int x = 0; x < tiles.GetLength(0); x++)
                    {
                        if(tiles[y,x] == 1)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Green;
                        }
                        Console.Write('\u25cf');
                    }
                    Console.WriteLine();
                }
                Console.ForegroundColor = defaultColor;
            }
        }
        static void Main (string[] args)
        {
            // 배열
            int[] scores = new int[5] { 10, 20, 30, 40, 50 };

            // 아파트 단지를 1차원 배열로 구현하기 어려우므로 2차원 배열로 구현한다.
            // 3층 [ . . . . . . . . . ]
            // 2층 [ . . . . . . . . . ]
            // 1층 [ . . . . . . . . . ]

            // 2차원 배열
            int[,] arr = new int[2, 3] { { 1, 2, 3 }, { 1, 2, 3 } };
            // 2F [ . . . ]
            // 1F [ . . . ]

            // 접근
            //arr[0, 0] = 1;
            //arr[1, 0] = 1;

            Map map = new Map();
            map.Render();
            // 맵 생성

            // 3F [ . . . ]
            // 2F [ . . . . . . ]
            // 1F [ . . . ]
            int[][] a = new int[2][];
            a[0] = new int[3];
            a[1] = new int[6];
            a[2] = new int[2];

            a[0][0] = 1;

        }
    }
}
