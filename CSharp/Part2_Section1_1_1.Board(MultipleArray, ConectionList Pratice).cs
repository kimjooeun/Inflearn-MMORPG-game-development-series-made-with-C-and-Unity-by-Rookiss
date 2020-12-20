using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace CSharp
{
    /* class MyList<T> //리스트는 제네릭형식이므로<T>를 넣어준다
    {
        const int DEFAULTSize = 1;
        T[] _data = new T[DEFAULTSize]; // 배열 선언

        public int Count = 0; // 실제로 사용중인 데이터 개수
        public int Capacity { get { return _data.Length; } } // 예약된 데이터 개수

        // 시간 복잡도 : 0(1) 예외 케이스 : 이사 비용은 무시한다.
        public void Add(T item) // 데이터 추가
        {
            // 1. 공간이 충분히 남아 있는지 확인한다.
            if (Count >= Capacity)
            {
                // 공간을 늘려서 다시 확보한다
                T[] newArray = new T[Count * 2];
                for (int i = 0; i < Count; i++) //이사를 시켜준다
                {
                    newArray[i] = _data[i];
                }
                _data = newArray;
            }
            // 2. (공간이 확보되었다고 가정시) 공간에다가 데이터를 넣어준다.
            _data[Count] = item;
            Count++;
        }

        // 시간 복잡도 : 0(1)
        public T this[int index] // 인덱서를 구현하는 부분
        {
            get { return _data[index]; }
            set { _data[index] = value; }
        }

        // 시간 복잡도 : 0(N)
        public void ReoteAt(int index)
        {
            // 101 102 103 104 105번 방이 있을 시
            // 103 번방을 지울때 (*103이 없어질 떄*) 104 /105를 앞으로 가져온다
            for (int i = index; i < Count - 1; i++)
                _data[i] = _data[Count + 1];
            _data[Count - 1] = default(T);
            Count--;
        }
    }
    */

    //class MyLinkedListNode<T>
    //{
    //    public T Data;
    //    public MyLinkedListNode<T> Next; // 다음 방
    //    public MyLinkedListNode<T> Prev; // 이전방
    //}

    /*
    class MyLinkedList<T>
    {
        public MyLinkedListNode<T> Head = null; // 첫번째
        public MyLinkedListNode<T> Tail = null; // 마지막
        public int Count = 0;

        // 시간 복잡도는 0(1)
        public MyLinkedListNode<T> AddLast(T data) // 새로운 방을 달라고 요구할 때에
        {
            MyLinkedListNode<T> newRoom = new MyLinkedListNode<T>(); // 새로 만든 방
            newRoom.Data = data; // 데이터를 넣어준다.

            // 만약에 아직 방이 아예 없었다면, 새로 추가한 방이 곧 Head이다.
            if (Head == null)
            { 
                Head = newRoom;
            }

            // 101, 102, 103, 만 있다가 104가 추가되면 104가 끝이다.
            // 기존의 [마지막 방]과 [새로 추가 되는 방]을 연결해준다.
            if (Tail != null)
            {
                Tail.Next = newRoom;
                newRoom.Prev = Tail;
            }

            // [새로 추가되는 방]을 [마지막 방]으로 인정한다.
            Tail = newRoom;
            Count++;
            return newRoom;
        }

        // 시간 복잡도는 0(1)
        // 101 102 103 104 105
        public void Remove(MyLinkedListNode<T> room)
        {
            // [기존의 첫번째 방의 다음 방]을 [첫번째 방으로] 인정한다.
            if (Head == room)
                Head = Head.Next;

            // [기존의 마지막 방의 이전 방]을 [마지막 방으로] 인정한다.
            if (Tail == room)
                Tail = Tail.Prev;

            // 이전의 방이 있다면 이전 방의 다음 방을 연결한다
            // 103번을 삭제할때 102번과 104번을 연결한다
            if (room.Prev != null)
                room.Prev.Next = room.Next;

            if (room.Next != null)
                room.Next.Prev = room.Prev;

            Count--;
        }
    }
    */

    class Part2_Section1_1_1_Board
    {
        //    public int[] _data = new int[25]; // 배열
        // 이로인해 맵은 배열을 사롱하는게 가장 적합하다

        //    public List<int> _data2 = new List<int>(); // 동적 배열
        // 맵 사이즈가 유동적으로 변하지 않기 떄문에 필요하지 않다

        //    public MyLinkedList<int> _data3 = new MyLinkedList<int>(); // 연결 리스트
        // 맵 안에 점이 사라졌다가 생기지 않음. 맵 자체가 변하지는 않는다.


        //public void Initialize()
        //{
        //     동적 배열 
        //    _data2.Add(101);
        //    _data2.Add(102);
        //    _data2.Add(103);
        //    _data2.Add(104);
        //    _data2.Add(105);

        //    int temp = _data2[2];
        //     데이터 추가
        //     인덱서를 이용해서 데이터를 추출한다
        //     103이 추출된다.

        //    _data2.RemoveAt(2);
        //     데이터 삭제
        //     몇번째 데이터를 삭제한다.

        //        // 연결 리스트
        //        _data3.AddLast(101);
        //        _data3.AddLast(102);
        //        LinkedListNode<int> node = _data3.AddLast(103);
        //        _data3.AddLast(104);
        //        _data3.AddLast(105);

        //        _data3.Remove(node);
        //    }
        //}

        const char CIRCLE = '\u25cf';
        public TileType[,] Tile; // 배열
        public int Size;
        
        // 맵 상에서 갈 수 있는 공간과 벽을 구분하기 위한 것
        public enum TileType
        {
            Empty,
            Wall,
        }

        public void Initialize(int size)
        {
            Tile = new TileType[size, size];
            Size = size;

            for (int y = 0; y < Size; y++)
            {
                for (int x = 0; x < Size; x++)
                {
                    if (x == 0 || x == Size - 1 || y == 0 || y == size - 1) // 외곽부분
                    {
                        Tile[y, x] = TileType.Wall;
                    }
                    else // 갈 수 있는 공간
                    {
                        Tile[y, x] = TileType.Empty;
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
                    Console.ForegroundColor = GetTileColor(Tile[y, x]);
                    Console.Write(CIRCLE);
                }
                Console.WriteLine();
            }
            Console.ForegroundColor = prevColor;
        }
        
        ConsoleColor GetTileColor(TileType type) // 콘솔 컬러를 설정하는 부분
        { 
            switch (type)
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