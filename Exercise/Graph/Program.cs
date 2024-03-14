﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise.Grape
{
    class Graph
    {
        int[,] adj = new int[6, 6]
        {
            { 0, 1, 0, 1, 0, 0 },
            { 1, 0, 1, 1, 0, 0 },
            { 0, 1, 0, 0, 0, 0 },
            { 1, 1, 0, 0, 1, 0 },
            { 0, 0, 0, 1, 0, 1 },
            { 0, 0, 0, 0, 1, 0 },
        };

        List<int>[] adj2 = new List<int>[]
        {
            new List<int>() { 1,3},
            new List<int>() { 0,2,3},
            new List<int>() { 1},
            new List<int>() { 0,1,4},
            new List<int>() { 3,5},
            new List<int>() { 4},
        };

        #region BFS

        public void BFS(int start)
        {
            bool[] found = new bool[6];
            int[] parent = new int[6];
            int[] distance = new int[6];
         
            // 선입선출
            Queue<int> q = new Queue<int>();
            q.Enqueue(start);
            found[start] = true;
            parent[start] = start;
            distance[start] = 0;

            while(q.Count > 0)
            {
                int now = q.Dequeue();
                Console.WriteLine(now);

                for(int next = 0; next < 6; next++)
                {
                    if (adj[now, next] == 0) // 인접하지 않았으면 스킵
                        continue;
                    if (found[next]) // 이미 발견한 애라면 스킵
                        continue;
                    q.Enqueue(next);
                    found[next] = true;
                    parent[next] = now;
                    distance[next] = distance[now] + 1;
                }
            }
        }




        #endregion


        #region DFS
        // 1) 우선 now부터 방문하고 
        // 2) now와 연결된 정점들을 하나씩 확인해서, 아직 미발견(미방문)상태라면 방문한다
        public void DFS(int now, bool[] visited)
        {
            Console.WriteLine(now);
            visited[now] = true;
            
            for(int next = 0; next < 6; next++)
            {
                if (adj[now, next] == 0)    // 연결되어 있지 않으면 스킵
                    continue;
                if (visited[next])      // 이미 방문했으면 스킵
                    continue;
                DFS(next, visited);
            }
        }

        public void DFS2(int now, bool[] visited)
        {
            Console.WriteLine(now);
            visited[now] = true;

            foreach(int next in adj2[now])
            {
                if (visited[next])
                    continue;
                DFS2(next, visited);
            }
        }
        public void SearchAll()
        {
            bool[] visited = new bool[6];
            visited = new bool[6];
            for(int now = 0; now <6; now++)
                if (visited[now] ==false)
                    DFS(now, visited); 
        }
        #endregion
    }



    class Program2
    {
        static void Main(string[] args)
        {
            // DFS(Depth First Search 깊이 우선 탐색)
            // BFS(Breah First Search 너비 우선 탐색)
            Graph graph = new Graph();
            // graph.SearchAll();
            graph.BFS(0);
        }
    }

}
