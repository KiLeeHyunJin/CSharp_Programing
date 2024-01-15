using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1._2024_01_15
{
    internal class _01_15_HW
    {

        public void IsOk(string str)
        {
            Stack<char> input = new Stack<char>(str);
            Stack<char> output = new Stack<char>();
            for (; 1 <= input.Count;)
            {
                if (input.Peek() == ')')
                {
                    output.Push(input.Pop());
                }                
                else if (input.Peek() == ']')
                {
                    output.Push(input.Pop());
                }                
                else if (input.Peek() == '}')
                {
                    output.Push(input.Pop());
                }
                else
                {
                    if (input.Peek() == '(' && output.Peek() == ')')
                    {
                        output.Pop();
                        input.Pop();
                    }
                    else if (input.Peek() == '[' && output.Peek() == ']')
                    {
                        input.Pop();
                        output.Pop();
                    }
                    else if (input.Peek() == '{' && output.Peek() == '}')
                    {
                        output.Pop();
                        input.Pop();
                    }
                    else
                    {
                        Console.WriteLine("잘못된 입력입니다.");
                        return;
                    }
                }
            }
            if (input.Count != 0 || output.Count != 0)
            {
                Console.WriteLine("잘못된 입력입니다.");
                return;
            }
            else
                Console.WriteLine("올바른 입력입니다.");

        }
        public int[] ProcessJob(int[] jobList)
        {
            Stack<int> stack = new Stack<int>();
            Queue<int> queue = new Queue<int>(jobList);
            int power = 8;
            int work = 0;
            int days = 1;
            while (queue.Count > 0)
            {
                work = queue.Dequeue(); //
                while (work > 0) //업무 시작
                {
                    if(power == 0)
                    {
                        days++;
                        power = 8;
                    }
                    if (work > power)
                    {
                        work -= power;
                        power = 0;
                    }
                    else
                    {
                        power -= work;
                        work = 0;
                    }
                }
                //업무 종료
                stack.Push(days);
            }
            return stack.ToArray();
        }

    }
}
