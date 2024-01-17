using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Programmers
{
    internal class RemoveSameAlphabet
    {
        public string solution(string my_string)
        {
            string answer = "";
            StringBuilder sb = new StringBuilder();
            HashSet<char> check = new HashSet<char>();
            for (int i = 0; i < my_string.Length; i++)
            {
                if (check.Contains(my_string[i]) == false)
                {
                    sb.Append(my_string[i]);
                    check.Add(my_string[i]);
                }
            }
            return sb.ToString();
        }
    }
}
