using ConsoleApp1._2024_01_12;
using ConsoleApp1._2024_01_16;
using ConsoleApp1._2024_01_17;
using ConsoleApp1._2024_01_18;
using ConsoleApp1._2024_01_19;
using System.Drawing;

namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //ConsoleApp1._2024_01_11.DataList<int> list = new _2024_01_11.DataList<int>();
            //int input = int.Parse(Console.ReadLine());
            //for (int i = 0; i <= input; i++)
            //    list.Add(i);
            //list.Add(0);

            //list.Remove(5);
            //for (int i = 0; i < list.Count; i++)
            //{
            //    Console.WriteLine(list[i]);
            //}

            //list.Add(1);
            //list.Add(6);
            //list.Add(7);
            //list.Add(8);
            //list.Add(3);
            //list.Add(2);
            //list.InsertRemove(7);


            //ConsoleApp1._2024_01_11.Inventory inventory = new _2024_01_11.Inventory();
            //ConsoleApp1._2024_01_11.Item item = new _2024_01_11.Item();
            //inventory.AddItem(item); 
            //inventory.RemoveItem(item); 

            //_01_12_HW _01_12_HW = new _01_12_HW();
            //_01_12_HW.OsefusArray(7,3);\

            //PriorityQueueCodingTest dataTree = new PriorityQueueCodingTest();
            //int[,] ints = { { 4, 60 }, { 4, 40 }, { 1, 20 }, { 2, 50 }, { 3, 30 }, { 4, 10 }, { 6, 60 } };
            ////dataTree.solution();
            //LabSchedule labSchedule1 = new LabSchedule();
            //labSchedule1.Solution();
            //CheatKey cheatKey = new CheatKey();
            //cheatKey.Run("ThereIsNoCowLevel");
            //cheatKey.Run("ShowMeTheMoney");
            //cheatKey.Run("ShowMeThe12");
            MapCheckTest cardCount = new MapCheckTest();
            cardCount.Run();
        }

        static int[] solution(int n)
        {
            int value = n;
            int[] answer = new int[] { };
            List<int> list = new List<int>();
            for (int i = 2; i <= value; i++)
            {
                re:
                if (n % i == 0)
                {
                    n /= i;
                    list.Add(i);
                    goto re;
                }
            }
            for (int i = 0; i < list.Count-1; i++)
            {
                if(i+1 < list.Count)
                {
                    if (list[i] == list[i + 1])
                    {
                        list.RemoveAt(i + 1);
                        i--;
                    }
                }

            }
            return list.ToArray();
        }

        static string solution(string bin1, string bin2)
        {
            string answer = "";
            int temp = int.Parse(bin1);
            int sour = int.Parse(bin2);
            int up = 0;
            int save = 0;
            int count = 1;
            answer = (temp + sour).ToString();

            char[] charArr = answer.ToArray<char>();
            Array.Reverse(charArr);
            answer = new string(charArr);
            //answer = new string(answer.Reverse<char>().ToArray());
            for (int i = 0; i < answer.Length; i++)
            {
                if (answer[i] == '0')
                {
                    if (up == 1)
                    {
                        save += count;
                        up = 0;
                    }
                }
                if (answer[i] == '1')
                {
                    if(up == 0)
                        save +=  count;
                    else
                        up = 1;
                }
                else if (answer[i] == '2')
                {

                    if(up == 1)
                    {
                        save += count;
                        up = 1;
                    }
                    else
                        up = 1;
                }
                count *= 10;
            }
            if (up == 1)
                save += count;
            return save.ToString();
        }
        int Multi(int left, int right) { return left * right; }
        float Multi(float left, float right) { return left * right; }
        double Multi(double left, double right) { return left * right; }

    }
}
