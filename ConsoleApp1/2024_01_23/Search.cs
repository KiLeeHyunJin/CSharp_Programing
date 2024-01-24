using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1._2024_01_23
{
    internal class Search
    {
        public void DepthFirstSearch(bool[,] graph,int start,out bool[] visited, out int[] parents  )
        {
            visited = new bool[graph.GetLength(0)];
            parents = new int[graph.GetLength(0)];
            for (int i = 0; i < graph.GetLength(0); i++)
            {
                visited[i] = false;
                parents[i] = -1;
            }

            SearchNode(graph, start, visited, parents);

        }
        public void SearchNode(bool[,] graph, int start, bool[] visited , int[] parent)
        {
            visited[start] = true;
            for (int i = 0; i < graph.GetLength(0); i++)
            {
                if (graph[start,i] && !visited[i])
                {
                    parent[i] = start;
                    SearchNode(graph, i, visited, parent);
                }
            }

        }


        public void BreadthFirstSearch(bool[,] graph, int start, out bool[] visited, out int[] parents)
        {
            visited = new bool[graph.GetLength(0)];
            parents = new int[graph.GetLength(0)];

            for (int i = 0; i < graph.GetLength(0); i++)
            {
                visited[i] = false;
                parents[i] = -1;
            }

            Queue<int> queue = new Queue<int>();
            queue.Enqueue(start);
            visited[start] = true;
            while(queue.Count > 0)
            {
                int next = queue.Dequeue();
                Console.WriteLine(next);

                for (int i = 0; i < graph.GetLength(0); i++)
                {
                    if (graph[next, i] && !visited[i])
                    {
                        parents[i] = next;
                        visited[i] = true;
                        queue.Enqueue(i);//(graph, i, visited, parents);
                    }
                }
            }
        }

    }
}
