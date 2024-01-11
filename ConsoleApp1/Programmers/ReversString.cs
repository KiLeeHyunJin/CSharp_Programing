using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Programmers
{
    internal class ReversString
    {
        public string solution(string my_string)
        {
            char[] chars = my_string.ToCharArray();
            Array.Reverse(chars);
       

            return new string(chars);
        }
        public string solution1(string my_string)
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Capacity = my_string.Length;
            for (int i = 0; i < my_string.Length; i++)
            {
                stringBuilder.Append(my_string[(my_string.Length - 1) - i]);
            }
            return stringBuilder.ToString();
        }
    }
}
