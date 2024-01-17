using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1._2024_01_17
{
    public class LabSchedule
    {
        public void Solution()
        {

            string? str = Console.ReadLine();
            if (str == null)
                return;
            int count = int.Parse(str);
            PriorityQueue<int, int> schedule = new PriorityQueue<int, int>();
            for (int i = 0; i < count; i++)
            {
                str = Console.ReadLine();
                if (str == null)
                    continue;
                string[] write = str.Split(' ');
                int enterNum = int.Parse(write[0]);
                int outNum = int.Parse(write[1]);
                schedule.Enqueue(outNum, enterNum);
            }

            PriorityQueue<int, int> lab = new PriorityQueue<int, int>();
            int answer = 0;
            while (schedule.Count > 0)
            {
                schedule.TryDequeue(out int outTime, out int inTime);
                if (lab.Count == 0)
                    lab.Enqueue(inTime, outTime);
                else
                {
                    lab.TryDequeue(out int startTime, out int escapeTime);
                    if (escapeTime <= inTime)
                        lab.Dequeue();
                    lab.Enqueue(inTime, outTime);
                }
                if (answer < lab.Count)
                    answer = lab.Count;
            }
            Console.WriteLine(answer);
        }
    }
}
