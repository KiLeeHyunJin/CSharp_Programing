using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Programmers
{
    internal class ControllZ
    {
        public int solution(string s)
        {
            int answer = 0;
            int outNum = 0;
            int save = 0;
            string[] str = s.Split(' ');
            for (int i = 0; i < str.Length; i++)
            {
                bool isCheck = int.TryParse(str[i], out outNum);
                if (isCheck)
                    answer += outNum;
                else
                    answer -= save;
                save = outNum;
            }
            Console.WriteLine(answer);
            return answer;
        }

    }
}
