using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Programmers
{
    internal class SevenCount
    {
        public int solution(int[] array)
        {
            int answer = 0;
            for (int i = 0; i < array.Length; i++)
            {
                string toString = array[i].ToString();

                for (int j = 0; j < toString.Length; j++)
                {
                    if (toString[j] == '7')
                        answer++;
                }
            }
            return answer;
        }

    }
}
