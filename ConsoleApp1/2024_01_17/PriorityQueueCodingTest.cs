using ConsoleApp1._2024_01_11;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Formats.Asn1.AsnWriter;

namespace ConsoleApp1._2024_01_17
{
    internal class PriorityQueueCodingTest
    {
        public void solution()
        {

            string str = Console.ReadLine();

            string[] strArr = new string[2];
            int count = int.Parse(str);
            int[,] dayScore = new int[count, 2];
            PriorityQueue<int, int> total = new PriorityQueue<int, int>();
            PriorityQueue<int, int> sortQueue = new PriorityQueue<int, int>();
            int lastDay = 0;

            for (int i = 0; i < count; i++)
            {
                str = (Console.ReadLine());
                strArr = str.Split(' ');
                dayScore[i, 0] = int.Parse(strArr[0]);
                dayScore[i, 1] = int.Parse(strArr[1]);
                total.Enqueue(dayScore[i, 1] * -1, dayScore[i, 0] * - 1);
                if(lastDay < dayScore[i, 0])
                    lastDay = dayScore[i, 0];
            }

            int totalScore = 0;
            for (int i = lastDay; i > 0; i--)
            {
                re:
                total.TryPeek(out int score, out int day);
                day *= -1;
                while (day >= i && total.Count > 0)
                {
                    total.Dequeue();
                    sortQueue.Enqueue(day,score);
                    goto re;
                }
                if (sortQueue.Count > 0)
                {
                    sortQueue.TryDequeue(out int temp, out int num);
                    num = ~num + 1;
                    totalScore += num;
                    Console.WriteLine($"day : {i} score : {num}");

                    while (0 < sortQueue.Count)
                    {
                        sortQueue.TryDequeue(out int moveDay, out int moveScore);
                        total.Enqueue(moveScore, moveDay * -1);
                    }
                }
                else
                    Console.WriteLine($"day : {i} score : 없음!");
            }
            Console.WriteLine(totalScore);

            //List<List<int>> lists = new List<List<int>>();
            //for (int i = 0; i < value.GetLength(0); i++)
            //{
            //    ints.Enqueue(value[i, 1], value[i, 0] * -1);
            //}
            //count = 0;
            //var (checkScore, tomorrowDay, checkDay) = (0, 0, 0);
            //for (int i = 0; ints.Count != 0; i++)
            //{
            //    lists.Add(new List<int>());

            //    if (ints.TryDequeue(out checkScore, out checkDay))
            //    {
            //        lists[count].Add(checkScore);
            //        do
            //        {
            //            ints.TryPeek(out checkScore, out tomorrowDay);
            //            if (checkDay == tomorrowDay)
            //            {
            //                ints.Dequeue();
            //                lists[count].Add(checkScore);
            //            }
            //        }
            //        while (checkDay == tomorrowDay);
            //        count++;
            //    }
            //}
            //int[] answerd = new int[lists.Count];
            //int highScore = 0;
            //int jR = 0;
            //int kR = 0;
            //for (int i = 0; i < answerd.Length; i++)
            //{
            //    for (int j = 0; j <= i; j++)
            //    {
            //        for (int k = 0; k < lists[j].Count; k++)
            //        {
            //            if (highScore < lists[j][k])
            //            {
            //                highScore = lists[j][k];
            //                jR = j;
            //                kR = k;
            //            }
            //        }
            //    }
            //    lists[jR].RemoveAt(kR);
            //    answerd[i] = highScore;
            //    highScore = 0;
            //}
            //int lastScore = 0;
            //Array.Reverse(answerd);
            //for (int i = 0; i < answerd.Length; i++)
            //{
            //    lastScore += answerd[i]; //Console.WriteLine(answerd[i]);
            //}
            //Console.WriteLine(lastScore);
        }
    }
}
