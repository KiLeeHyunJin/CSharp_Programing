using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Programmers
{
    internal class ReverseStringAndCheck
    {
        public int solution(string before, string after)
        {
            bool[] isCheck = new bool[after.Length];
            bool isFind = false;
            for (int i = 0; i < before.Length; i++)
            {
                isFind = false;
                for (int j = 0; j < after.Length; j++)
                {
                    if (before[i] == after[j])
                    {
                        if (isCheck[j] == false)
                        {
                            isCheck[j] = true;
                            isFind = true;
                            break; ;
                        }
                        else
                        {

                        }
                    }
                }
                if (isFind == false)
                    return 0;
            }
            return 1;
        }
    }
}
