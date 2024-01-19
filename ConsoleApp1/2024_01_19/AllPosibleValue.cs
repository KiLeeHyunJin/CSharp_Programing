using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1._2024_01_19
{
    internal class AllPosibleValue
    {
        public void Main() // 분석 필요
        {
            int[] value = { 10, -4 , 3, 1, 5, 6, -35, 12, 21,-1};
            int max = int.MinValue;
            int[,] result = new int[value.Length, value.Length];
            List<int> list = new List<int>();
            for (int i = 0; i < value.Length; i++)
            {
                result[i, i] = value[i];
            }
            for (int start = 0; start < value.Length - 1; start++)
            {
                for (int end = start + 1; end < value.Length; end++)
                {
                    result[start, end] = result[start, end - 1] + value[end];
                    Console.WriteLine($"current sum value : {result[start, end]} = {result[start, end - 1]} + {value[end]} ");
                    if(max < result[start, end])
                    {
                        max = result[start, end];
                        list.Add(max);
                    }
                }
            }
            foreach (var ele in list)
                Console.WriteLine($"stack value : {ele}");
        }
    }
}
