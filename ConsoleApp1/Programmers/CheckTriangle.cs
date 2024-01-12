using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Programmers
{
    internal class CheckTriangle
    {
        public int solution(int[] sides)
        {
            int answer = 0;
            int longSide = 0;
            int shortSide = 0;
            if (sides[0] > sides[1])
            {
                longSide = sides[0];
                shortSide = sides[1];
            }
            else
            {
                longSide = sides[1];
                shortSide = sides[0];
            }

            for (int i = 1; i <= longSide; i++)
            {
                if(longSide < i + shortSide && (longSide << 1) >= i + shortSide)
                {
                    answer++;
                }
            }

            answer += (longSide + shortSide) - (longSide+1) ;
            if (answer <= 0)
                answer = 1;
            return answer;
        }
    }
}
