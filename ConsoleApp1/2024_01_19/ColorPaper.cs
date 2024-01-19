using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1._2024_01_19
{
        public class ColorPaper
        {
            int blue = 0;
            int white = 0;
            bool[,] board;

            public void Run()
            {
                string str = Console.ReadLine();
                int count = int.Parse(str);
                string[] strs = new string[count];
                board = new bool[count, count];

                for (int y = 0; y < count; y++)
                {
                    strs[y] = Console.ReadLine();
                    string[] numbers = strs[y].Split(' ');
                    for (int x = 0; x < numbers.Length; x++)
                    {
                        board[y, x] = numbers[x] == "1" ? true : false;
                    }
                }

                Devide(0, 0, count, count);

                Console.WriteLine(blue);
                Console.WriteLine(white);
            }

            public void Devide(int startX, int startY, int sizeX, int sizeY)
            {
                if (IsAllColorMatch(startX, startY, sizeX, sizeY))
                {
                    bool check = board[startX, startY];
                    if (check)
                        white++;
                    else
                        blue++;
                    return;
                }
                // 1 / 4 씩 분할
                Devide(startX, startY, sizeX / 2, sizeY / 2); // 좌상단
                Devide(startX, startY + sizeY / 2, sizeX / 2, sizeY / 2); // 우상단
                Devide(startX + sizeX / 2, startY, sizeX / 2, sizeY / 2); // 좌하단
                Devide(startX + sizeX / 2, startY + sizeY / 2, sizeX / 2, sizeY / 2); // 우하단
            }

            public bool IsAllColorMatch(int startX, int startY, int sizeX, int sizeY)
            {
                bool check = board[startX, startY];//시작점의 체크값

                for (int x = startX; x < startX + sizeX; x++)
                {
                    for (int y = startY; y < startY + sizeY; y++)
                    {
                        if (board[x, y] != check) //체크값이 다르면 실패
                        {
                            return false;
                        }
                    }
                }
                return true;
            }
        }

}
