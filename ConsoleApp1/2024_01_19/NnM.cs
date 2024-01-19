using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1._2024_01_19
{
    internal class NnM
    {
        public void Main()
        {
            string[] input =Console.ReadLine().Split(' ');
            int lenght = int.Parse(input[0]);
            int count = int.Parse(input[1]);
            int[] save = new int[count];

            for (int i = 0; i < save.Length; i++)
            {
                save[i] = 1;
            }

            Console.Write(save[0]);
            for (int j = 1; j < count; j++)
                Console.Write($" {save[j]}");
            Console.WriteLine();

            CountUp(save, 0, lenght, count);

        }
        public void CountUp(int[] ints, int idx, int length, int count)
        {
            if (idx != count - 1)
            {
                CountUp(ints, idx + 1, length, count);
            }
            for (int i = 1; i < length; i++)
            {
                ints[idx]++;

                Console.Write(ints[0]);
                for (int j = 1; j < count; j++)
                    Console.Write($" {ints[j]}");
                Console.WriteLine();

                if (idx < count - 1)
                {
                    CountUp(ints, idx + 1, length, count);
                }

            }
            ints[idx] = 1;
            return;
        }
    }



    public class Solution1
    {
        private StringBuilder sb; 
        private int number;
        private int count;
        private int[] numbers;

        public void Run()
        {
            sb = new StringBuilder();
            number = 0;
            count = 0;

            string text = Console.ReadLine();
            string[] texts = text.Split(' ');

            number = int.Parse(texts[0]);
            count = int.Parse(texts[1]);
            numbers = new int[count];

            BackTracking(0); //큰자리부터 시작

            Console.WriteLine(sb.ToString()); //한꺼번에 출력
        }

        private void BackTracking(int index)
        {
            if (index == count) //뒷자리라면 출력을 위해 진입
            {
                sb.AppendLine(string.Join(' ', numbers)); //대입
                return;//복귀
            }

            for (int i = 1; i <= number; i++)
            {
                numbers[index] = i; //대입
                BackTracking(index + 1);//뒷자리 대입을 위해 진입
            }
        }
    }


}
