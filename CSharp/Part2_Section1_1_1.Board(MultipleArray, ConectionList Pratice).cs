using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace CSharp
{
    //class MyList<T>
    //{
    //    const int DEFAULTSize = 1;
    //    T[] _data = new T[DEFAULTSize];

    //    public int Count = 0; // 실제로 사용중인 데이터 개수
    //    public int Capacity { get { return _data.Length; } } // 예약된 데이터 개수

    //    // 0(N)
    //    public void Add (T item)
    //    {
    //        // 1. 공간이 충분히 남아 있는지 확인한다.
    //        if (Count >= Capacity)
    //        {
    //            // 공간을 늘려서 다시 확보한다
    //            T[] newArray = new T[Count * 2];
    //            for (int i = 0; i < Count; i++)
    //                newArray[i] = _data[i];
    //            _data = newArray;
    //        }

    //        // 2. 공간이 확보되었다고 가정시) 공간에다가 데이터를 넣어준다.
    //        _data[Count] = item;
    //        Count++;
    //    }

    //    public T this [int index]
    //    {
    //        get { return _data[index]; }
    //        set { _data[index] = value; }
    //    }

    //    public void ReoteAt(int index)
    //    {
    //        // 101 102 103 104 105번 방이 있을 시
    //        // 2번방을 지울때 103이 없어질 떄 104 /105를 앞으로 가져온다
    //        for (int i = index; i < Count - 1; i++)
    //            _data[i] = _data[Count + 1];
    //        _data[Count - 1] = default(T);
    //        Count--;
    //    }
    //}

    //class MyLinkedListNode<T>
    //{
    //    public T Data;
    //    public MyLinkedListNode<T> Next;
    //    public MyLinkedListNode<T> Prev;
    //}

    //class MyLinkedList<T>
    //{
    //    public MyLinkedListNode<T> Head = null; // 첫번째
    //    public MyLinkedListNode<T> Tail = null; // 마지막
    //    public int Count = 0;

    //    public MyLinkedListNode<T> AddLast(T data)
    //    {
    //        MyLinkedListNode<T> newRoom = new MyLinkedListNode<T>();
    //        newRoom.Data = data;

    //        // 만약에 아직 방이 아예 없었다면, 새로 추가한 방이 곧 Head이다.
    //        if (Head == null)
    //            Head = newRoom;

    //        // 기존의 [마지막 방]과 [새로 추가 되는 방]을 연결해준다.
    //        if (Tail != null)
    //        {
    //            Tail.Next = newRoom;
    //            newRoom.Prev = Tail;
    //        }

    //        // [새로 추가되는 방]을 [마지막 방]으로 인정한다.
    //        Tail = newRoom;
    //        Count++;
    //        return newRoom;
    //    }

    //    // 101 102 103 104 105
    //    public void Remove(MyLinkedListNode<T> room)
    //    {
    //        // [기존의 첫번째 방의 다음 방]을 [첫번째 방으로] 인정한다.
    //        if (Head == room)
    //            Head = Head.Next;

    //        // [기존의 마지막 방의 이전 방]을 [마지막 방으로] 인정한다.
    //        if (Tail == room)
    //            Tail = Tail.Prev;

    //        if (room.Prev != null)
    //            room.Prev.Next = room.Next;

    //        if (room.Next != null)
    //            room.Next.Prev = room.Prev;

    //        Count--;
    //    }
    //}

    class Part2_Section1_1_1_Board
    {
        //    public int[] _data = new int[25]; // 배열
        //    public List<int> _data2 = new List<int>(); // 동적 배열
        //    public MyLinkedList<int> _data3 = new MyLinkedList<int>(); // 연결 리스트

        //    public void Initialize()
        //    {
        //        // 동적 배열
        //        _data2.Add(101);
        //        _data2.Add(102);
        //        _data2.Add(103);
        //        _data2.Add(104);
        //        _data2.Add(105);

        //        int temp = _data2[2];

        //        _data2.RemoveAt(2);

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
                    if (x == 0 || x == Size - 1 || y == 0 || y == size - 1)
                    {
                        Tile[y, x] = TileType.Wall;
                    }
                    else
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
        
        ConsoleColor GetTileColor(TileType type)
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
