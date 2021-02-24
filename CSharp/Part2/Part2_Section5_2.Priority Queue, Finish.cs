using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace CSharp
{
    // 추가 조건을 넣어서 사용하는 예)
    class PrioityQueue<T> where T : IComparable<T>
    {
        List<T> _heap = new List<T>();

        // 빅오표기법을 이용해 Push와 Pop의 처리속도는 몇일까?
        // 추가시에는 도장꺠기를 이용해 값을 위로 올렸다
        // 삭제시에는 최상위값을 없앤 다음 아래로 도장깨기를 이용하였다
        // 푸쉬와 팝의 시간복잡도는 트리의 높이가 굉장히 중요하다.
        // 값이 2배씩 증가하는 것을 알 수 있다, N의 값이 얼마나 크든 트리는 2배씩 증가한다

        // O(log(n))
        public void Push(T data)
        {
            // 힙의 맨 끝에 새로운 데이터를 삽입한다.
            _heap.Add(data);

            int now = _heap.Count - 1;
            // 도장깨기를 시작
            while (now > 0)
            {
                // 도장깨기를 시도
                int next = (now - 1) / 2;

                if (_heap[now].CompareTo(_heap[next]) < 0)
                {
                    break; // 실패
                }

                // 두 값을 교체한다
                T temp = _heap[now];
                _heap[now] = _heap[next];
                _heap[next] = temp;
                // 값을 교체할때 대각선의 법칙을 기억하면 편하다.

                // 검사 위치를 이동한다
                now = next;
            }
        }

        // O(log(n))
        // 가장 큰값을 토해내는 함수
        public T Pop()
        {
            //반환할 데이터를 따로 저장
            T ret = _heap[0];

            // 마지막 데이터를 루트로 이동시킨다.
            int lastIndex = _heap.Count - 1;    // 마지막 데이터를 lastindex에 저장
            _heap[0] = _heap[lastIndex];        // lastindex를 맨 위로 이동
            _heap.RemoveAt(lastIndex);          // removeat으로 데이ㅏ터 삭제
            lastIndex--;                        // 데이터의 크기를 줄여준다.

            // 올린 값을 역으로 도장깨기를 한다
            // 좌우로 비교할 때 큰값이 있는 곳으로 내려간다
            int now = 0;
            while (true)
            {
                int left = 2 * now + 1;
                int right = 2 * now + 2;
                // 주의! left와 right가 값의 범위를 벗어날 수도 있음

                int next = now;
                // 왼족 값이 현재 값보다 크면 왼쪽으로 이동하는 로직
                if (left <= lastIndex && _heap[next].CompareTo(_heap[left]) < 0)
                {
                    next = left;
                }
                // 오른족 값이 현재 값(왼쪽 이동 포함 값)보다 크면 오른쪽으로 이동하는 로직
                if (right <= lastIndex && _heap[next].CompareTo(_heap[right]) < 0)
                {
                    next = right;
                }
                // 왼쪽/오른쪽 모두 현재 값보다 작으면 종료
                if (next == now)
                {
                    break;
                }

                // 두 값을 교체한다.
                T temp = _heap[now];
                _heap[now] = _heap[next];
                _heap[next] = temp;

                // 검사 위치를 이동한다
                now = next;
            }
            return ret;
        }

        public int Count()
        {
            return _heap.Count;
        }
    }

    class Knight : IComparable<Knight>
    {
        public int Id { get; set; }

        // 인터페이스에서 제공해야하는 함수 = CompareTo
        public int CompareTo(Knight other)
        {
            if (Id == other.Id)
            {
                return 0;
            }
            return Id > other.Id ? 1 : -1;
            // return Id < other.Id ? 1 : -1;

        }
    }

    class Part2_Section5
    {
        static void Main(string[] args)
        {
            // 자본주의 큐, 비싼 차들이 먼저 나오게 된다.
            PrioityQueue<Knight> q = new PrioityQueue<Knight>();
            q.Push(new Knight() { Id = 20 });
            q.Push(new Knight() { Id = 30 });
            q.Push(new Knight() { Id = 40 });
            q.Push(new Knight() { Id = 10 });
            q.Push(new Knight() { Id = 05 });

            while (q.Count() > 0)
            {
                Console.WriteLine(q.Pop().Id);
            }
        }

    }
}
