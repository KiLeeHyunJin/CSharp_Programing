using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Programmers
{
    internal class Factorial
    {
        public int solution(int n)
        {
            int answer = 0;
            int checkNum = 1;
            int count = 1;
            while( true)
            {
                checkNum *= count++;
                if (n == checkNum)
                    break;
                else if (n < checkNum)
                    return count;
            }
            return count + 1;
        }
    }
}
