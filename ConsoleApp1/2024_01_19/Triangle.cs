using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1._2024_01_19
{
        public class Triangle
        {
            int[,] stage;
            int result = 0;

            public void Run()
            {
                string str = "5";//Console.ReadLine(); //정삼각형의 길이
                int count = int.Parse(str);
                stage = new int[count, count];
                string[] temp = new string[5];
            temp[0] = "7";
            temp[1] = "3 8";
            temp[2] = "8 1 0";
            temp[3] = "2 7 4 4 ";
            temp[4] = "4 5 2 6 5";
                for (int y = 0; y < count; y++)
                {
                    string numberStr = Console.ReadLine();
                    string[] numbers = numberStr.Split(' ');
                    for (int x = 0; x < numbers.Length; x++)
                    {
                        stage[y, x] = int.Parse(numbers[x]);
                    }
                }

                Solve();

                for (int x = 0; x < count; x++) //높이 만큼 반복
                {
                    result = stage[count - 1, x] > result ? stage[count - 1, x] : result; //결과 = 
                }
                Console.WriteLine(result);





                for (int i = 0; i < stage.GetLength(0); i++)
                {
                    for (int j = 0; j < stage.GetLength(1); j++)
                    {
                        Console.Write($"  {stage[i,j]}  ");
                    }
                    Console.WriteLine();
                }


            }

            public void Solve()
            {
                for (int y = 1; y < stage.GetLength(0); y++) //가로 만큼 반복
                {
                    stage[y, 0] += stage[y - 1, 0]; //아래층 0번 합산
                    for (int x = 1; x < stage.GetLength(1); x++) //높이 만큼 반복
                    {
                        if (stage[y - 1, x - 1] > stage[y - 1, x])//아래층 한칸 옆과 현재 위치 비교 
                        {
                            stage[y, x] += stage[y - 1, x - 1]; //좌측과 합산 
                        }
                        else
                        {
                            stage[y, x] += stage[y - 1, x]; //우측과 합산
                        }
                    }
                }
            }
        }

}
