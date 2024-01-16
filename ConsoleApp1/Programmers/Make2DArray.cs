using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Programmers
{
    internal class Make2DArray
    {
        public int[,] solution(int[] num_list, int n)
        {
            int[,] answer = new int[num_list.Length/n, n];
            for (int i = 0; i < num_list.Length; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    answer[i, j] = num_list[(i * n) + j];
                }
            }
            return answer;
        }
    }
}
