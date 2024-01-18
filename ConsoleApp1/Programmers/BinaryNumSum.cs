using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Programmers
{
    /// <summary>
    /// 오류 유
    /// </summary>
    internal class BinaryNumSum
    {
        public string solution(string bin1, string bin2)
        {
            int sum = int.Parse(bin1) + int.Parse(bin2);
            char[] chr = sum.ToString().ToCharArray();
            Array.Reverse(chr);
            bool up = false;
            int count = 1;
            for (int i = 0; i < chr.Length; i++)
            {
                if (chr[i] == '0')
                {
                    if(up)
                    {
                        chr[i] = '1';
                        up = false;
                    }
                }
                else if (chr[i] == '1')
                {
                    if (up)
                    {
                        chr[i] = '0';
                    }
                    else
                    {
                        chr[i] = '1';
                        up = false;
                    }
                }
                else
                {
                    if (up)
                    {
                        chr[i] = '1';
                    }
                    else
                    {
                        chr[i] = '0';

                    }
                    up = true;
                }
                count *= 10;
            }
            Array.Reverse(chr);
            string temp = new string(chr);
            if (up)
            {
                temp = (int.Parse(chr) + count).ToString();
            }

            foreach (var item in temp)
            {
                Console.Write(item);
            }
            return temp;
        }
    }
}
