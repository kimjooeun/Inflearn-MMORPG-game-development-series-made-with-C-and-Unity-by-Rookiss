using System;
using System.Collections.Generic;
using System.Text;

namespace CSharp
{
    class Graph
    {
        // 행렬 버전
        int[,] adj = new int[6, 6]
        {
            // 0, 1, 2, 3, 4, 5
            { -1, 15, -1, 35, -1, -1 }, // 0
            { 15, -1, 05, 10, -1, -1 }, // 1
            { -1, 05, -1, -1, -1, -1 }, // 2
            { 35, 10, -1, -1, 05, -1 }, // 3
            { -1, -1, -1, 05, -1, 05 }, // 4
            { -1, -1, -1, -1, 05, -1 }, // 5
            // 대각선을 기준으로 대칭이다.
        };

        // 리스트 버전
        List<int>[] adj2 = new List<int>[]
        {
            new List<int>() { 1, 3 },
            new List<int>() { 0, 2, 3 },
            new List<int>() { 1 },
            new List<int>() { 0, 1, 4 },
            new List<int>() { 3, 5 },
            new List<int>() { 4 },
        };

        public void Dijikstra(int start)
        {
            bool[] visited = new bool[6];
            int[] distance = new int[6];
            int[] parent = new int[6];
            Array.Fill(distance, Int32.MaxValue);

            distance[start] = 0;
            parent[start] = start;

            while (true)
            {
                // 제일 좋은 후보를 찾는다. (가장 가까이에 있는)

                // 가장 유력한 후보의 거리와 번호를 저장한다
                int closset = Int32.MaxValue;
                int now = -1;
                for (int i = 0; i < 6; i++)
                {
                    // 이미 방문한 정점은 스킵
                    if (visited[i])
                    {
                        continue;
                    }
                    // 아직 발견(예약)된 적이 없거나, 기존 후보보다 멀리 있으면 스킵
                    if (distance[i] == Int32.MaxValue || distance[i] >= closset)
                    {
                        continue;
                    }
                    // 여태껏 발견한 가장 좋은 후보라는 의미. 정보를 갱신
                    closset = distance[i];
                    now = i;
                }

                // 다음 후보가 하나도 없다 > 종료
                if (now == -1)
                {
                    break;
                }

                // 제일 좋은 후보를 찾았으니까 방문한다.
                visited[now] = true;

                // 방문한 정점과 인접한 정점들을 조사해서, 상황에따라 발견한 최단거리를 갱신한다.
                for (int next = 0; next < 6; next++)
                {
                    // 연결되지 않은 정점 스킵
                    if (adj[now, next] == -1)
                    {
                        continue;
                    }
                    // 이미 방문한 정점은 스킵
                    if (visited[next])
                    {
                        continue;
                    }

                    //새로 조사된 정점의 최단거리를 계산한다
                    int nextDist = distance[now] + adj[now, next];

                    // 만약에 기존에 발견한 최단거리가 새로 조사된 최단거리보다 크면 정보를 갱신한다.
                    if (nextDist < distance[next])
                    {
                        distance[next] = nextDist;
                        parent[next] = now;
                    }
                }
            }
        }

        bool[] visited = new bool[6];
        // 1) 우선 Now부터 방문하고 클리어 표시를 한 다음에
        // 2) Now와 연결된 정점들을 하나씩 확인해서, [ 아직 미발견한(미방문 상태라면) ] 방문한다.
        public void DFS(int now) // 행렬을 이용한 버전
        {
            Console.WriteLine(now);
            visited[now] = true; // 1) 우선 Now부터 방문하고 클리어 표시를 한 다음에

            for (int next = 0; next < 6; next++)
            {
                if (adj[now, next] == 0) // 연결 되어 있지 않으면 스킵,
                {
                    continue;
                }
                if (visited[next]) // 이미 방문했으면 스킵,
                {
                    continue;
                }
                DFS(next);
            }
        }

        public void DFS2(int now)
        {
            Console.WriteLine(now);
            visited[now] = true; // 1) 우선 Now부터 방문하고 클리어 표시를 한 다음에

            foreach (int next in adj2[now]) // 연결 되어 있지 않으면 스킵,
            {
                if (visited[next]) // 이미 방문했으면 스킵,
                {
                    continue;
                }
                DFS2(next);
            }
        }

        public void SearchAll()
        {
            visited = new bool[6];
            for (int now = 0; now < 6; now++)
            {
                if (visited[now] == false)
                {
                    DFS(now);
                }
            }
        }

        public void BFS(int start) // 큐와 행렬을 이용한 BFS
        {
            bool[] found = new bool[6];
            int[] parent = new int[6]; // 부모에 대한 정보
            int[] distance = new int[6]; // 거리에 대한 정보

            Queue<int> q = new Queue<int>(); // 예약목록 (대기열)을 관리하기 위해 만듬.
            q.Enqueue(start);
            found[start] = true;
            parent[start] = start;
            distance[start] = 0;

            while (q.Count > 0) // 대기열에 예약이 하나라도 있을 때까지 반복
            {
                int now = q.Dequeue(); // 대기열에서 제일 오래 기다린 것을 가져온다
                Console.WriteLine(now); // 디버깅 용도

                for (int next = 0; next < 6; next++) // 행렬이용
                {
                    if (adj[now, next] == 0) // 나랑 쟤랑 인접한 아이인가? (인접하지 않았으면 스킵)
                    {
                        continue;
                    }
                    if (found[next]) //인접하더라도 발견한 아이인가? (이미 발견한 애라면 스킵)
                    {
                        continue;
                    }
                    q.Enqueue(next);
                    found[next] = true;
                    parent[start] = now;
                    distance[next] = distance[now] + 1;
                }
            }
        }
    }

    class Part2_Section4
    {
        static void Main(string[] args)
        {
            //List<int> list = new List<int>() { 1, 2, 3, 4 };

            //for (int i = 0; i < list.Count; i++)
            //{
            //    Console.WriteLine(list[i]);
            //}

            //foreach (int val in list)
            //{
            //    Console.WriteLine(val);
            //}

            //DFS (Depth First Search 깊이 우선 탐색) -- 용감한 영웅과 비슷하다. -- 다양한 예시로 사용된다
            //BFS (Breadth First Search 너비 우선 탐색) -- 예약시스템과 비슷하다 -- 최단거리 추출용으만 사용된다.
            Graph graph = new Graph();
            // graph.DFS(0);
            // graph.DFS2(0);
            // graph.SearchAll();
            // graph.BFS(0);
            graph.Dijikstra(0);
        }
    }
}