using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Programmers
{
    internal class Measure
    {
        public int solution(int n)
        {
            int answer = 0;
            for (int j = 4; j < n; j++)
            {
                for (int i = 4; i < j; i++)
                {
                    if (j % i == 0)
                        answer++;
                }
            }
            //answer++;
            return answer;
        }
    }
}
