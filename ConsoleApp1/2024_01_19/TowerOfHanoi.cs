using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1._2024_01_19
{
        public class TowerOfHanoi
        {
            private Stack<int>[] towers;

            public TowerOfHanoi()
            {
                towers = new Stack<int>[3];
                towers[0] = new Stack<int>();
                towers[1] = new Stack<int>();
                towers[2] = new Stack<int>();
            }

            public void Run(int pinCount)
            {
                for (int i = pinCount; i > 0; i--)
                {
                    towers[0].Push(i);
                }

                Move(pinCount, 0, 2);
            }

            private void Move(int count, int start, int end)
            {
                int middle = 3 - (start + end);

                if (count == 1)
                {
                    int value = towers[start].Pop();
                    towers[end].Push(value);

                    Console.WriteLine($"{value}번판을 {start + 1}타워에서 {end + 1}타워로 옮깁니다.");

                    return;
                }

                Move(count - 1, start, middle);
                Move(1, start, end);
                Move(count - 1, middle, end);
            }
        }


}
