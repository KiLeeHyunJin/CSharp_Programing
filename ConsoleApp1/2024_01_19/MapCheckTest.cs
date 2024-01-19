using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1._2024_01_19
{
    internal class MapCheckTest
    {
        public class Data
        {

        }
        public int length;
        public int[,] map;
        public int trueCount;
        public int falseCount;
        public void Run()
        {
            Data mapData = new Data();
            string strLength = "8";//Console.ReadLine();
            int length = int.Parse(strLength);
           length = length;
           map = new int[length,length];


            string[] strArray = new string[8];
            strArray[0] = "1 1 0 0 0 0 1 1";
            strArray[1] = "1 1 0 0 0 0 1 1";
            strArray[2] = "0 0 0 0 1 1 0 0";
            strArray[3] = "0 0 0 0 1 1 0 0";
            strArray[4] = "1 0 0 0 1 1 1 1";
            strArray[5] = "0 1 0 0 1 1 1 1";
            strArray[6] = "0 0 1 1 1 1 1 1";
            strArray[7] = "0 0 1 1 1 1 1 1";
            for (int y = 0; y < length; y++)
            {
                string readData = strArray[y];//Console.ReadLine();
                string[] lineData = readData.Split(" ");

                for (int x = 0; x <length; x++)
                {
                    map[y,x] = int.Parse(lineData[x]);
                }
            }

            SearchToMap( 0, 0, length, length);
            Console.WriteLine(trueCount);
            Console.WriteLine(falseCount);
        }


        public void SearchToMap(int startX, int startY, int sizeX, int sizeY)
        {
            if (AllSameCheck(startX, startY, sizeX, sizeY))
            {
                if (map[startX, startY] == 1)
                    trueCount++;
                else
                    falseCount++;
                return;
            }


            SearchToMap(startX, startY, sizeX / 2, sizeY / 2); // 좌상단
            SearchToMap(startX, startY + sizeY / 2, sizeX / 2, sizeY / 2); // 우상단
            SearchToMap(startX + sizeX / 2, startY, sizeX / 2, sizeY / 2); // 좌하단
            SearchToMap(startX + sizeX / 2, startY + sizeY / 2, sizeX / 2, sizeY / 2); // 우하단
        }
        public void Devide(int startX, int startY, int sizeX, int sizeY)
        {
            if (IsAllColorMatch(startX, startY, sizeX, sizeY))
            {
                if (map[startX, startY] == 1)
                    trueCount++;
                else
                    falseCount++;
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
            int check = map[startX, startY];//시작점의 체크값

            for (int x = startX; x < startX + sizeX; x++)
            {
                for (int y = startY; y < startY + sizeY; y++)
                {
                    if (map[x, y] != check) //체크값이 다르면 실패
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        public bool AllSameCheck(int xPos, int yPos, int xSize, int ySize)
        {
            int isCheck = map[xPos, yPos];

            for (int y = yPos; y < yPos + ySize; y++)
            {
                for (int x = xPos; x < xPos + xSize; x++)
                {
                    if (map[x, y] != isCheck)
                        return false;
                }
            }
            return true;
        }






    }
}
