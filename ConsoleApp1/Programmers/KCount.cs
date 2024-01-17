using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Programmers
{
    internal class KCount
    {
        public int solution(int i, int j, int k)
        {
            StringBuilder sb = new StringBuilder();
            int answer = 0;
            for (; i < j; i++)
            {
                sb.Clear();
                
                sb.Append(i.ToString());
                for (int m = 0; m < sb.Length; m++)
                {
                    if (int.Parse(sb[m].ToString()) == k)
                        answer++;
                }
            }
            return answer;
        }
    }
}
