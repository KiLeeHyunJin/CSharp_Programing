using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1._2024_01_24
{
    public class Writing
    {
        public void Dijkstar(int[,]graph, int start, out int[] distance, out bool[] visited,out int[] parent)
        {
            visited = new bool[graph.GetLength(0)];
            parent = new int[graph.GetLength(0)];
            distance = new int[graph.GetLength(0)];

            const int INF = 99999;
            int firstFor = 0;
            int secondFor = 0;
            for (int i = 0; i < graph.GetLength(0); i++)
            {
                parent[i] = i;
                distance[i] = INF;
            }
            distance[start] = 0;

            for (int i = 0; i < graph.GetLength(0); i++)
            {

                int minDistance = INF;
                int next = -1;
                
                for (int j = 0; j < graph.GetLength(0); j++)
                {
                    if (visited[j] == false &&
                        distance[j] < minDistance)
                    {
                        firstFor++;

                        next = j;
                        minDistance = distance[j];
                    }
                }
                
                if (next < 0)
                    break;

                for (int j = 0; j < graph.GetLength(0); j++)
                {
                    if (distance[j] > graph[next,j] + distance[next])
                    {
                        //secondFor++;
                        distance[j] = graph[next, j] + distance[next];
                        parent[j] = next;
                        Console.WriteLine($"{"Vertex",10}{j}{"Parent",10}:{parent[j]}{"Distacne",10}:{distance[j],10}");

                    }
                }
                visited[next] = true;
            }


            Console.WriteLine($"{"Vertex",15}{"Visited",15}{"Distance",15}{"Parent",15}");
            for (int i = 0; i < graph.GetLength(0); i++)
                Console.WriteLine($"{i,15}{visited[i],15}{distance[i],15}{parent[i],15}");

            //Console.Write($"First ");
            //Console.WriteLine($"{firstFor,10}");
            //Console.Write($"Second");
            //Console.WriteLine($"{secondFor,10}");

        }

    }
}
