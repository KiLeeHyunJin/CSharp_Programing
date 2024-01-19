using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1._2024_01_19
{
    internal class ATMCodingTest
    {
        public void Main()
        {
            int length = int.Parse(Console.ReadLine());
            string[] str = Console.ReadLine().Split(" ");
            int[] elemens = new int[length];
            for (int i = 0; i < length; i++)
                elemens[i] = int.Parse(str[i]);

            Array.Sort(elemens); //정렬

            for (int i = 0; i < length - 1; i++)//앞자리 수를 뒷자리에 합산
                    elemens[i + 1] += elemens[i];

            int answer = 0;
            for (int i = 0; i < length; i++)//모든 수를 합산
                answer += elemens[i];

            Console.WriteLine(answer);
        }
    }





    public class Solution2
    {
        public void Run()
        {
            PriorityQueue<int, int> pq = new PriorityQueue<int, int>();
            string text;

            text = Console.ReadLine();
            int count = int.Parse(text);

            text = Console.ReadLine();
            string[] texts = text.Split(' ');
            int[] person = new int[count];
            for (int i = 0; i < count; i++)
            {
                person[i] = int.Parse(texts[i]);
                pq.Enqueue(person[i], person[i]);
            }

            int time = 0;
            int sum = 0;

            while (pq.Count > 0)
            {
                int value = pq.Dequeue();
                time += value;
                sum += time;
            }

            Console.WriteLine(sum);
        }
    }

}
