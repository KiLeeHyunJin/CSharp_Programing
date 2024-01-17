using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Programmers
{
    internal class NearNumber
    {
        public int solution(int[] array, int n)
        {
            int answer = array[0];
            int save = Math.Abs(array[0] - n);
            int check = 0;
            for (int i = 1; i < array.Length; i++)
            {
                check = Math.Abs(n - array[i]);
                if (check < save)
                {
                    answer = array[i];
                    save = Math.Abs(array[i] - n);
                }
                else if(check == save)
                {
                    if(answer > array[i])
                        answer = array[i];
                }
            }
            return answer;
        }
    }
}
