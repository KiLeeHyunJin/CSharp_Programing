using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Programmers
{
    internal class HideNumberSum
    {
        public int solution(string my_string)
        {
            int answer = 0;
            int number = 0;
            int length = 0;
            //StringBuilder sb = new StringBuilder();
            for (int i = 0; i < my_string.Length; i++)
            {
                length = i;

                if (int.TryParse(my_string[i].ToString(),out number))
                {
                re:
                    if (my_string.Length > length + 1)
                    {
                        if (int.TryParse(my_string[length + 1].ToString(), out number))
                        {
                            length++;
                            goto re;
                        }
                    }
                    if(length - i >= 1)
                    {
                        char[] chars = new char[length - (i - 1)];
                        Array.Copy(my_string.ToCharArray(), i, chars, 0, length - (i - 1));
                        answer += int.Parse(new string(chars));
                        i = length;
                    }
                    else
                    {
                        answer += int.Parse(my_string[length].ToString());
                    }
                }
            }
            return answer;
        }
    }
}
