using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1._2024_01_24
{
    public class Dijkstra
    {
        const int INF = 99999;


        public void ShortestPath(int[,] graph, int start, out bool[] visited, out int[] distance, out int[] parent)
        {
            Console.WriteLine();
            int size = graph.GetLength(0);
            visited = new bool[size];
            distance = new int[size];
            parent = new int[size];

            for (int i = 0; i < size; i++)
            {
                visited[i] = false;
                distance[i] = INF;
                parent[i] = i;
            }
            distance[start] = 0; //시작 길이 초기화

            for (int i = 0; i < size; i++)//첫번째 정점부터 순회
            {

                int next = -1;
                int minDistance = INF;

                for (int j = 0; j < size; j++)//모든 기록물 순회
                {
                    if (!visited[j] &&              //해당 정점이 방문된적이 없고
                        distance[j] < minDistance) //방문한적 없고 거리가 짧으면
                    {
                        next = j; //순회 정점으로 저장
                        minDistance = distance[j]; //최소 거리로 기록
                    }
                }
                if (next < 0) //방문할 수 있는 정점이 없으면 
                    break;
                Console.WriteLine($"next : {next}  MinDistance {minDistance}");

                for (int j = 0; j < size; j++) //모든 기록물 순회
                {
                    if (distance[j] > distance[next] + graph[next,j])//기록거리와 해동 정점에서 접근 거리 비교
                    {                                                //(정점에서 접근이 불가할경우 최대거리로 대체됨)
                        distance[j] = distance[next] + graph[next, j]; //해당 정점은 우회 거리로 기록
                        parent[j] = next;                           //부모 정점 설정
                    }
                }
                visited[next] = true;
            }
                Console.WriteLine($"{"Vertex",10}{"Visited",10}{"Distance",10}{"Parent",10}");
            for (int i = 0; i < size; i++)
                Console.WriteLine($"{i,10}{visited[i],10}{distance[i],10}{parent[i],10}");

        }




    }
}