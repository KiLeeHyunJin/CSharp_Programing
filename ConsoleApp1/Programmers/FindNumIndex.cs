using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Programmers
{
    internal class FindNumIndex
    {
        public int solution(int num, int k)
        {
            string numStr = num.ToString();
            string checkChar = k.ToString();
            for (int i = 0; i < numStr.Length; i++)
            {
                if (numStr[i].Equals(checkChar[0]))
                    return i + 1;
            }
            return -1;
        }
    }
}
