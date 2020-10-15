using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace CSharp
{
    // 메소드 호출 => Inception과 같다.
    // 현실 -> 1차 꿈 -> 2차 꿈 -> 3차 꿈
    class Part1_Section3
    {
        // 디버깅
        static void Print(int values)
        {
            Console.WriteLine(values);
        }
        static int AddAndPrint (int a, int b)
        {
            int ret = a + b;
            Print(ret);
            return ret;
        }

        // TextRPG 직업 고르기
        enum ClassType
        {
            None = 0,
            Knight = 1,
            Archer = 2,
            Mage = 3
        }

        struct Player
        {
            public int hp;
            public int attack;
        }

        enum MonsterType
        {
            None = 0,
            Slime = 1,
            Orc = 2,
            Skeleton = 3
        }

        struct Monster
        {
            public int hp;
            public int attack;
        }

        // TextRPG 직업 고르기
        static ClassType ChooseClass()
        {
            Console.WriteLine("직업을 선택하세요. : ");
            Console.WriteLine("[1] 기사");
            Console.WriteLine("[2] 궁수");
            Console.WriteLine("[3] 법사");

            ClassType choice = ClassType.None;
            string input = Console.ReadLine();
            switch (input)
            {
                case "1":
                    choice = ClassType.Knight;
                    break;

                case "2":
                    choice = ClassType.Archer;
                    break;

                case "3":
                    choice = ClassType.Mage;
                    break;
            }
            return choice;
        }

        static void CreatePlayer (ClassType choice, out Player player)
        {
            // 기사는(100/10) 궁수(75/12) 법사 (50/15)
            switch (choice)
            {
                case ClassType.Knight:
                    player.hp = 100;
                    player.attack = 10;
                    break;

                case ClassType.Archer:
                    player.hp = 75;
                    player.attack = 12;
                    break;

                case ClassType.Mage:
                    player.hp = 50;
                    player.attack = 15;
                    break;

                default:
                    player.hp = 0;
                    player.attack = 0;
                    break;
            }
        }
        static void CreateRandomMonster(out Monster monster)
        {
            Random rand = new Random();
            int randMonster = rand.Next(1, 4);
            switch(randMonster)
            {
                case (int)MonsterType.Slime:
                    Console.WriteLine("슬라임이 스폰되었습니다!");
                    monster.hp = 20;
                    monster.attack = 2;
                    break;

                case (int)MonsterType.Orc:
                    Console.WriteLine("오크가 스폰되었습니다!");
                    monster.hp = 40;
                    monster.attack = 4;
                    break;

                case (int)MonsterType.Skeleton:
                    Console.WriteLine("스켈레톤이 스폰되었습니다!");
                    monster.hp = 30;
                    monster.attack = 3;
                    break;

                default:
                    monster.hp = 0;
                    monster.attack = 0;
                    break;

            }

            // 랜덤으로 1~3 몬스터 중 하나를 리스폰
        }
        static void Fight(ref Player player, ref Monster monster)
        {
            while (true)
            {
                // 플레이어가 몬스터 공격
                monster.hp -= player.attack;
                if (monster.hp <= 0)
                {
                    Console.WriteLine("승리했습니다.");
                    Console.WriteLine($"남은 체력 : {player.hp}");
                    break;
                }

                // 몬스터 공격
                player.hp -= monster.attack;
                if (player.hp <= 0)
                {
                    Console.WriteLine("패배했습니다.");
                    break;
                }
            }
        }

        // TextRPG 전투
        static void EnterField(ref Player player)
        {
            while(true)
            {
                Console.WriteLine("필드에 접속했습니다!");

                // 몬스터 생성
                // 랜덤으로 1~3 몬스터 중 하나를 리스폰

                Monster monster;
                CreateRandomMonster(out monster);

                // [1] 전투 모드로 돌입
                Console.WriteLine("[1] 전투 모드로 돌입");

                // [2] 일정 확률로 마을로 도망
                Console.WriteLine("[2] 일정 확률로 마을로 도망");

                string input = Console.ReadLine();
                if (input == "1")
                {
                    Fight(ref player, ref monster);
                }

                else if (input == "2")
                {
                    // 33%의 확률로 도망
                    Random rand = new Random();
                    int randValue = rand.Next(0, 101);
                    if (randValue <= 33)
                    {
                        Console.WriteLine("도망치는데 성공했습니다!");
                        break;
                    }

                    else
                    {
                        Fight(ref player, ref monster);
                    }
                }
            }
        }
        static void EnterGame(ref Player player)
        {
            while (true)
            {
                Console.WriteLine("마을에 접속했습니다!");
                Console.WriteLine("[1] 필드로 간다.");
                Console.WriteLine("[2] 로비로 돌아가기.");

                string input = Console.ReadLine();
                if (input == "1")
                {
                    EnterField(ref player);
                }

                else if (input == "2")
                {
                    break;
                }
            }

        }
        static void Main(string[] args)
        {
            // 디버깅
            Part1_Section3.AddAndPrint(5, 15);
            Part1_Section3.AddAndPrint(6, 17);
            Part1_Section3.AddAndPrint(3, 11);
            Part1_Section3.AddAndPrint(12, 31);
            Part1_Section3.AddAndPrint(10, 20);

            // TextRPG 직업 고르기
            while (true)
            {
                ClassType choice = ChooseClass();
                if (choice == ClassType.None)
                {
                    continue;
                }
                    // TextRPG 플레이어 생성
                    // 캐릭터 생성
                    Player player;
                    CreatePlayer(choice, out player);

                    // TextRPG 몬스터 생성
                    // 필드로 가서 몬스터와 전투
                    EnterGame(ref player);
            }
        }
    }
}

