using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Programmers
{
    internal class ChangeAlphabet
    {
        public string solution(string my_string)
        {
            char[] chars = my_string.ToLower().ToCharArray();
            Array.Sort(chars);
            return new string(chars);
        }
    }
}
