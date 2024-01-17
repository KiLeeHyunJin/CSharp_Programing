using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Programmers
{
    internal class OnlyOneAlphabet
    {
        public string solution(string s)
        {
            Dictionary<char,int> pairs = new Dictionary<char,int>();
            for (int i = 0; i < s.Length; i++)
            {
                if (pairs.ContainsKey(s[i]) == false)
                {
                    pairs.Add(s[i], 1);
                }
                else
                {
                    pairs[s[i]] += 1;
                }
            }
            StringBuilder sb = new StringBuilder();
            foreach (var item in pairs)
            {
                if(item.Value == 1)
                    sb.Append(item.Key);
            }
            char[] arr = sb.ToString().ToCharArray();
            Array.Sort(arr);
            return new string(arr);
        }
    }
}
