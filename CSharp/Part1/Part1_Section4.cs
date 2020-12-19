using System;
using System.Collections.Generic;
using System.Text;

namespace CSharp
{
    // 객체지향의 시작 (OOP, Object Oriented Prograaming)
    // 객체는 속성과 기능으로 구분할 수 있다.

    // Knight

    // 속성 : hp , attack, pos, 
    // 기능 : Move, Ataack, Die

    
    // OOP(은닉성/상속성/다형성)
    // 상속성

    // 은닉성
    // 자동차
    // 핸들 페달 차문을 열고
        // 전기장치 엔진 기름 <-> 외부 노출

    //class Knight
    //{
    //    // 접근 한정자
    //    // public protected private//    int hp;

    //    //private void SecretFunctin()
    //    //{
    //    //    hp = 20;
    //    //}

    //    //public void SetHp(int hp)
    //    //{
    //    //    this.hp = hp;
    //    //}
    //}

    //class SuperKnight : Knight
    //{
    //    void Test()
    //    {
    //        hp = 10;
    //    }
    //}

    // 데이터 형식 변환 
    //class Player
    //{
    //    protected int hp;
    //    protected int attack;

    //    public virtual void Move()
    //    {
    //        Console.WriteLine("Player 이동!");
    //    }
    //}
    
    //// 오버로딩(함수 이름의 재사용), 오버라이딩(다형성)
    //class Knight : Player
    //{
    //    public sealed override void Move()
    //    {
    //        base.Move();

    //        Console.WriteLine("Knight 이동!");
    //    }

    //class SuperKnight : Knight
    //{
    //     public override void Move()
    //    {
    //        Console.WriteLine("SuperKnight 이동!");

    //    }
    //}

    //class Mage : Player
    //{
    //    public int mp;

    //    public override void Move()
    //    {
    //        Console.WriteLine("Mage 이동!");
    //    }
    //}

    //class Player // 부모 / 기반
    //{
    //    // 필드
    //    // 속성
    //    static public int count = 1; // 오로지 1개만 존재한다.
    //    public int id;
    //    public int hp;
    //    public int attack;

    //    //public Player()
    //    //{
    //    //    Console.WriteLine("Player 생성자 호출!");
    //    //}
    //    //public Player(int hp)
    //    //{
    //    //    this.hp = hp;
    //    //    Console.WriteLine("Player hp 생성자 호출!");
    //    //}

    //    public void Move()
    //    {
    //        Console.WriteLine("Player Move");
    //    }

    //    public void Attack()
    //    {
    //        Console.WriteLine("Player Attack");
    //    }
    //}

    //class Mage : Player
    //{

    //}

    //class Archer : Player
    //{

    //}

    // Ref, 참조
    // 붕어빵 틀
    // class Knight : Player // 자식 / 파생
    //{
        //int c;

        //public Knight() //: base(100)
        //{
        //    //this.c = 10;    // 나의.hp
        //    //base.hp = 100; // 부모님의.hp
        //    Console.WriteLine("Knight 생성자 호출!");
        //}

        //static public void Test()
        //{
        //    count++;
        //}

        //static public Knight CreatKnight()
        //{
        //    Knight knight = new Knight();
        //    knight.hp = 100;
        //    knight.attack = 1;
        //    return knight;
        //}

        // 생성자
        //public Knight()
        //{
        //    id = count;
        //    count++; 

        //    hp = 100;
        //    attack = 10;
        //    Console.WriteLine("생성자 호출!");
        //}

        //public Knight(int hp) : this()
        //{
        //    this.hp = hp;
        //    Console.WriteLine("int 생성자 호출!");

        //}

        //public Knight(int hp, int attack)
        //{
        //    this.hp = hp;
        //    this.attack = attack;
        //    Console.WriteLine("int, int 생성자 호출!");
        //}

        //public Knight Clone()
        //{
        //    Knight knight = new Knight();
        //    knight.hp = hp;
        //    knight.attack = attack;
        //    return knight;
        //}

        // 기능
        //public void Move()
        //{
        //    Console.WriteLine("Knight Move");
        //}

        //public void Attack()
        //{
        //    Console.WriteLine("Knight Attack");
        //}
    //}

    // 복사(값)와 참조
    // Class와 struct의 차이는 무엇인지?
    // Struct는 복사, Class는 참조.

    // 복사
    //struct Mage
    //{
    //    // 속성
    //    public int hp;
    //    public int attack;

    //

    class Part1_Section4
    {
        //static void KillMage(Mage mage)
        //{
        //    mage.hp = 0;
        //}

        //static void KillKnight(Knight knight)
        //{
        //    knight.hp = 0;
        //}

        // 데이터 형식 변환
        //static void EnterGame(Player player)
        //{
        //    player.Move();

        //    // NULL = '없음'
        //    Mage mage = (player as Mage);
        //    if (mage != null)
        //    {
        //        mage.mp = 10;
        //        mage.Move();
        //    }

        //    //Knight knight = (player as Knight);
        //    //if (knight != null)
        //    //{                
        //    //    knight.Move();
        //    //}
        //}

        //static Player FindPlayerByid(int id)
        //{
        //    // id에 해당하는 플레이어를 탐색


        //    // 못찾았으면
        //    return null;
        //}

        static void Main(string[] args)
        {
            // 복사(값)와 참조
            //Mage mage;
            //mage.hp = 50;
            //mage.attack = 50;

            //Mage mage2 = mage;
            //mage2.hp = 0;

            // 객체지향의 시작
            //Knight knight = new Knight();
            //Knight knight2 = new Knight();
            //knight2.hp = 80;
            //Knight knight3 = new Knight();
            //knight3.hp = 200;
            //knight.hp = 100;
            //knight.attack = 10;

            //Knight knight2 = knight.Clone();
            //knight2.hp = 0;

            // 스택과 힙
            // 영상 PPT 내용이 전부

            // static의 정체
            // 붕어빵 틀에 종속이 되는 것.
            // Knight knight = new Knight(); //static
            //knight.Move(); // 일반

            //Console.WriteLine();

            //Random rand = new Random();
            //rand.Next(0, 2);

            // 상속성
            //Knight.Move();

            // 은닉성
            //Knight knight = new Knight();
            //knight.SetHp(100);

            // 데이터 형식 변환
            //Knight knight = new Knight();
            //Mage mage = new Mage(); 

            ////// Mage 타입 -> Player 타입 -> 가능
            ////// Player 타입 -> Mage 타입 -> 불가능
            ////Player magePlayer = mage;
            ////Mage mage2 = (Mage)magePlayer;

            ////EnterGame(mage);
            ////EnterGame(mage);

            //Knight knight2 = null;

            //// 다형성
            ////knight.Move();
            ////mage.Move();

            //knight.Move();

            // 문자열 둘러보기
            string name = "Harry Potter";

            // 1. 찾기
            bool found = name.Contains("Harry");
            int index = name.IndexOf('P');
            int index2 = name.IndexOf('z');

            // 2. 변형
            name = name + " Junior"; // 문자 더하기
            
            string lowerCaseName = name.ToLower(); // 소문자 변환
            string upperCaseName = name.ToUpper(); // 대문자 변환
            string newName = name.Replace('r', 'l'); // 문자 변환

            // 3. 분할
            string[] names = name.Split(new char[] { ' ' }); // 띄어쓰기로 구분
            string substring = name.Substring(5); // 특정 인덱스부터 문자를 새로 쓴다.


        }
    }
}
