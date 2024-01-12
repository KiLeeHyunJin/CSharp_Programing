using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Programmers
{
    /// <summary>
    /// 해결 실패
    /// </summary>
    public class IHateEnglish 
    {
        public long solution(string numbers)
        {
            char[] chars;
            long answer = 0;
            int count = 1;
            int num = 0;
            int idx = 0;
            int checkLength = 0;
            int destLength = 3;
            string check = "";
            string[] str = 
                { 
                "zero", "one", "two", "three", "four", 
                "five", "six", "seven", "eight", "nine" 
                };
            while (idx != numbers.Length) 
            {
                destLength = 3;
                check = numbers.Substring(idx, destLength);
                if ("six" == check)
                {
                    idx += 3;
                    num = 6;
                }
                else if("one"== check)
                {
                    idx += 3;
                    num = 1;

                }
                else if("two" == check)
                {
                    idx += 3;
                    num = 2;
                }
                else
                {
                    destLength++;
                    check = numbers.Substring(idx, destLength);
                    if ("four" == check)
                    {
                        idx += 4;
                        num = 4;
                    }
                    else if ("zero" == check)
                    {
                        idx += 4;
                        num = 0;

                    }
                    else if ("five" == check)
                    {
                        idx += 4;
                        num = 5;

                    }
                    else if ("nine" == check)
                    {
                        idx += 4;
                        num = 9;
                    }
                    else
                    {
                        destLength++;
                        check = numbers.Substring(idx, destLength);
                        if ("seven" == check)
                        {
                            idx += 5;
                            num = 7;
                        }
                        else if ("eight" == check)
                        {
                            idx += 5;
                            num = 8;

                        }
                        else if ("three" == check)
                        {
                            idx += 5;
                            num = 3;
                        }
                    }
                }
                destLength = 0;
                answer += num * count;
                count *= 10;
            }
            string temp = answer.ToString();
            char[] chars1 = temp.ToCharArray();
            Array.Reverse(chars1);
            answer = long.Parse(new string(chars1));
            return answer;
        }

    }
}
