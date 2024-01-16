using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Programmers
{
    internal class ThreeSixNineGame
    {
        public int solution(int order)
        {
            string str = order.ToString();
            int answer = 0;

            for (int i = 0; i < str.Length; i++)
            {
                if (str[i]!= '0' &&int.Parse(str[i].ToString()) % 3 == 0)
                    answer++;
            }
            return answer;
        }
    }
}
