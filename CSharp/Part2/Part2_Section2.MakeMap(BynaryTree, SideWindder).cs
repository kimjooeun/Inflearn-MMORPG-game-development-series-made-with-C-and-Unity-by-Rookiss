using System;
using System.Collections.Generic;
using System.Text;

namespace CSharp
{
    class Part2_Section2MakeMap
    {
        const char CIRCLE = '\u25cf';
        public TileType[,] Tile { get; private set; } // 배열
        public int Size { get; private set; }
        
        public int DestY { get; private set; }
        public int DestX { get; private set; }

        Part2_Section2_Player _player;

        public enum TileType
        {
            Empty,
            Wall,
        }

        public void Initialize(int size, Part2_Section2_Player player)
        {
            if (size % 2 == 0) // 맵 크기가 짝수일 때에 바로 끝난다. (홀수만 가능)
            {
                return;
            }
            _player = player;

            Tile = new TileType[size, size];
            Size = size;

            DestY = Size - 2;
            DestX = Size - 2;

            // Mazes for Programmers
            //GenerateByBinaryTree();
            GenerateBySideWinder();
        }

        void GenerateBySideWinder()
        {
            // 길을 막는 작업
            for (int y = 0; y < Size; y++)
            {
                for (int x = 0; x < Size; x++)
                {
                    if (x % 2 == 0 || y % 2 == 0)
                    {
                        Tile[y, x] = TileType.Wall;
                    }
                    else
                    {
                        Tile[y, x] = TileType.Empty;
                    }
                }
            }

            // 랜덤으로 우측 혹은 아래로 길을 뚫는 작업
            Random rand = new Random();
            for (int y = 0; y < Size; y++)
            {
                int count = 1;
                for (int x = 0; x < Size; x++)
                {
                    if (x % 2 == 0 || y % 2 == 0)
                    {
                        continue;
                    }
                    if (y == Size - 2 && x == Size - 2) 
                    {
                        continue;
                    }
                    if (y == Size - 2) // 제일 외곽에 있는 것은 아래로만 가게 한다
                    {
                        Tile[y, x + 1] = TileType.Empty;
                        continue;
                    }
                    if (x == Size - 2) // 제일 외곽에 있는 것들은 오른쪽으로 가게 한다
                    {
                        Tile[y + 1, x] = TileType.Empty;
                        continue;
                    }
                    if (rand.Next(0, 2) == 0) // 우측에 갈 때에
                    {
                        Tile[y, x + 1] = TileType.Empty;
                        count++;
                    }
                    else // 아래로 길을 뚫을 때에
                    {
                        int randomindex = rand.Next(0, count);
                        Tile[y + 1, x - randomindex * 2] = TileType.Empty;
                        count = 1;
                    }
                }
            }
        }

        void GenerateByBinaryTree()
        {
            // 길을 막는 작업
            for (int y = 0; y < Size; y++)
            {
                for (int x = 0; x < Size; x++)
                {
                    if (x % 2 == 0 || y % 2 == 0)
                    {
                        Tile[y, x] = TileType.Wall;
                    }
                    else
                    {
                        Tile[y, x] = TileType.Empty;
                    }
                }
            }

            // 랜덤으로 우측 혹은 아래로 길을 뚫는 작업
            // Binary Tree Algorizm
            Random rand = new Random();
            for (int y = 0; y < Size; y++)
            {
                for (int x = 0; x < Size; x++)
                {
                    if (x % 2 == 0 || y % 2 == 0)
                    {
                        continue;
                    }
                    if (y == Size - 2 && x == Size - 2)
                    {
                        continue;
                    }
                    if (y == Size - 2) // 제일 외곽에 있는 것은 아래로만 가게 한다
                    {
                        Tile[y, x + 1] = TileType.Empty;
                        continue;
                    }
                    if (x == Size - 2) // 제일 외곽에 있는 것들은 오른쪽으로 가게 한다
                    {
                        Tile[y + 1, x] = TileType.Empty;
                        continue;
                    }
                    if (rand.Next(0, 2) == 0) //우측으로 길을 뚫을 때
                    {
                        Tile[y, x + 1] = TileType.Empty;
                    }
                    else // 아래로 길을 뚫을 때
                    {
                        Tile[y + 1, x] = TileType.Empty;
                    }
                }
            }
        }

        public void Render()
        {
            ConsoleColor prevColor = Console.ForegroundColor;
            for (int y = 0; y < Size; y++)
            {
                for (int x = 0; x < Size; x++)
                {
                    // 플레이어 좌표를 가지고 와서 그 좌표랑 현재 y/x가 일치하면 플레이어 전용 색상으로 표시
                    if (y == _player.PosY && x == _player.PosX)
                    {
                        Console.ForegroundColor = ConsoleColor.Blue;
                    }
                    else if ( y == DestY && x == DestX)
                    {
                        Console.ForegroundColor = ConsoleColor.Yellow;
                    }
                    else
                    {
                        Console.ForegroundColor = GetTileColor(Tile[y, x]);
                    }
                    Console.Write(CIRCLE);
                }
                Console.WriteLine();
            }
            Console.ForegroundColor = prevColor;
        }
        ConsoleColor GetTileColor(TileType type)
        {
            switch(type)
            {
                case TileType.Empty:
                    return ConsoleColor.Green;
                case TileType.Wall:
                    return ConsoleColor.Red;
                default:
                    return ConsoleColor.Green;
            }
        }
    }
}
