using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Programmers
{
    internal class AnotherSpaceLanguage
    {
        public int solution(string[] spell, string[] dic)
        {
            int answer = 0;
            bool[] isCheck = new bool[spell.Length];
            int isCountCheck = 0;
            for (int i = 0; i < dic.Length; i++)
            {
                for (int j = 0; j < spell.Length; j++)
                {
                    for (int k = 0; k < dic[i].Length; k++)
                    {

                        if (dic[i][k].Equals(spell[j][0]))
                        {
                            if (isCheck[j] == false)
                            {
                                isCountCheck++;
                                isCheck[j] = true;
                            }
                        }
                    }
                }
                if (isCountCheck == spell.Length)
                    return 1;
                isCountCheck = 0;
                isCheck = new bool[spell.Length];
            }
            return 2;
        }
    }
}
