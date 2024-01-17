using ConsoleApp1._2024_01_11;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1._2024_01_17
{
    internal class PriorityQueueCodingTest
    {
        public int solution()
        {

            string str = Console.ReadLine();
            StringBuilder sb = new StringBuilder();
            string[] strArr = new string[2];
            int count = int.Parse(str);
            int[,] value = new int[count, 2];

            for (int i = 0; i < count; i++)
            {
                sb.Clear();
                sb.Append(Console.ReadLine());
                strArr = sb.ToString().Split(' ');
                value[i, 0] = int.Parse(strArr[0]);
                value[i, 1] = int.Parse(strArr[1]);
            }
            PriorityQueue<int, int> ints = new PriorityQueue<int, int>();
            List<List<int>> lists = new List<List<int>>();
            for (int i = 0; i < value.GetLength(0); i++)
            {
                ints.Enqueue(value[i, 1], value[i, 0] * -1);
            }
            count = 0;
            var (checkScore, tomorrowDay, checkDay) = (0, 0, 0);
            for (int i = 0; ints.Count != 0; i++)
            {
                lists.Add(new List<int>());

                if (ints.TryDequeue(out checkScore, out checkDay))
                {
                    lists[count].Add(checkScore);
                    do
                    {
                        ints.TryPeek(out checkScore, out tomorrowDay);
                        if (checkDay == tomorrowDay)
                        {
                            ints.Dequeue();
                            lists[count].Add(checkScore);
                        }
                    }
                    while (checkDay == tomorrowDay);
                    count++;
                }
            }
            int[] answerd = new int[lists.Count];
            int highScore = 0;
            int jR = 0;
            int kR = 0;
            for (int i = 0; i < answerd.Length; i++)
            {
                for (int j = 0; j <= i; j++)
                {
                    for (int k = 0; k < lists[j].Count; k++)
                    {
                        if (highScore < lists[j][k])
                        {
                            highScore = lists[j][k];
                            jR = j;
                            kR = k;
                        }
                    }
                }
                lists[jR].RemoveAt(kR);
                answerd[i] = highScore;
                highScore = 0;
            }
            int lastScore = 0;
            Array.Reverse(answerd);
            for (int i = 0; i < answerd.Length; i++)
            {
                lastScore += answerd[i]; //Console.WriteLine(answerd[i]);
            }
            Console.WriteLine(lastScore);
            return lastScore;
        }
    }
}
