using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1._2024_01_23
{
    internal class SelfMaking
    {
        public void DFS(bool[,] graph, int start, out bool[] visit, out int[] parent)
        {
            visit = new bool[graph.GetLength(0)];
            parent = new int[graph.GetLength(0)];
            for (int i = 0; i < graph.GetLength(0); i++)
            {
                visit[i] = false;
                parent[i] = -1;
            }
            DFSSearch(graph, start, visit, parent);
        }

        void DFSSearch(bool[,] graph, int start,bool[] visit, int[] parent)
        {
            visit[start] = true;
            Console.WriteLine(start);
            for (int i = 0; i < graph.GetLength(0); i++)
            {
                if (graph[start,i] && !visit[i])
                {
                    parent[i] = start;
                    DFSSearch(graph, i, visit, parent);
                }
            }
        }
        public void BFS(bool[,] graph, int start, out bool[] visit, out int[] parent)
        {
            visit = new bool[graph.GetLength(0)];
            parent = new int[graph.GetLength(0)];
            for (int i = 0; i < graph.GetLength(0); i++)
            {
                visit[i] = false;
                parent[i] = -1;
            }

            Queue<int> queue = new Queue<int>();
            queue.Enqueue(start);
            visit[start] = true;
            while(queue.Count > 0)
            {
                int next = queue.Dequeue();
                Console.WriteLine(next);

                for (int i = 0; i < graph.GetLength(0); i++)
                {
                    if (graph[next,i] && !visit[i])
                    {
                        parent[i] = next;
                        visit[i] = true;
                        queue.Enqueue(i);

                    }
                }
            }
        }
    }
}
