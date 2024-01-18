using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1._2024_01_18
{
    public class CardCount
    {
        public void Main()
        {
            int totalSize = int.Parse(Console.ReadLine());
            int useCardLength = int.Parse(Console.ReadLine());
            int[] currenUsingIdx = new int[useCardLength];
            HashSet<string> set = new HashSet<string>();
           PriorityQueue<string,int> check = new PriorityQueue<string,int>();
            int[] nums = new int[totalSize];
            for (int i = 0; i < totalSize; i++)
                nums[i] = int.Parse(Console.ReadLine());

            for (int i = 0; i < useCardLength; i++)
                currenUsingIdx[i] = i;
            string[] strings = new string[currenUsingIdx.Length];

            //check.Enqueue(sb.ToString(), 0);
            for (int iCurrentIdx = useCardLength - 1; 0 <= iCurrentIdx;)
            {

                for (int i = 0; i < totalSize; i++)
                {
                    currenUsingIdx[iCurrentIdx] = i;
                    strings = new string[currenUsingIdx.Length];
                    //sb.Clear();
                    bool isCheck = true;
                    for (int j = 1; j < useCardLength; j++)
                    {
                        for (int m = 0; m < useCardLength; m++)
                        {
                            if (j != m && currenUsingIdx[j] == currenUsingIdx[m])
                            {
                                isCheck = false;
                                break;
                            }
                        }
                    }
                    if(isCheck)
                    {
                        string temp = "";
                        StringBuilder sb = new StringBuilder();
                        for (int p = 0; p < useCardLength; p++)
                        {
                            sb.Append(nums[currenUsingIdx[p]].ToString());
                            temp += "idx : "  + currenUsingIdx[p] + " ,";
                        }
                        set.Add(sb.ToString());
                        check.Enqueue(temp, currenUsingIdx[0]);
                    }

                }
                for (int i = useCardLength-1; i > 0; i--)
                {
                    if (currenUsingIdx[i] == totalSize -1 && currenUsingIdx[i] != useCardLength - 1)
                    {
                        if(currenUsingIdx[i - 1] != totalSize - 1)
                        {
                            currenUsingIdx[i - 1]++;
                            currenUsingIdx[i] = 0;
                            break;
                        }
                    }
                }
                bool allPass = true;
                for (int i = 0; i < useCardLength; i++)
                {
                    if (currenUsingIdx[i] != totalSize - 1)
                        allPass = false;
                }
                if (allPass)
                    break;
            }
            #region
            //for (int iCurrentIdx = 0; iCurrentIdx < useCardLength; iCurrentIdx++) //요소 반복
            //{
            //    int saveStartIdx = currenUsingIdx[iCurrentIdx];
            //    for (int iCheckNextIdx = 0; iCheckNextIdx < totalSize; iCheckNextIdx++) //범위 전부 탐색
            //    {

            //            currenUsingIdx[iCurrentIdx] = iCheckNextIdx;
            //            strings = new string[currenUsingIdx.Length];
            //            sb.Clear();
            //            for (int p = 0; p < currenUsingIdx.Length; p++)
            //            {
            //                sb.Append(nums[currenUsingIdx[p]].ToString());
            //            }
            //            set.Add(sb.ToString());




            //            sb.Clear();
            //            for (int p = 0; p < currenUsingIdx.Length; p++)
            //            {
            //                sb.Append(" idx : " + currenUsingIdx[p].ToString() + ", ");
            //            }

            //            check.Enqueue(sb.ToString(), currenUsingIdx[0]);



            //    }
            //    if (saveStartIdx < (totalSize - (1)))
            //    {
            //        currenUsingIdx[iCurrentIdx] = ++saveStartIdx;
            //    }
            //}

            #endregion

            for (int i = 0; check.Count > 0; i++)
                Console.WriteLine(check.Dequeue());

            Console.WriteLine(set.Count);
        }

        public class Card
        {
            int getNum;
            int total;
            string[] nums;

            public Card(int total, int getNum, string[] nums) 
            {
                this.getNum = getNum;
                this.total = total;
                this.nums = nums;
            }

            public void SumCards()
            {
                int firstElement = 0;
                int cheak = 0;

                string num = nums[firstElement];

                while (cheak < total)
                {
                    while (num.Length < getNum) 
                    {
                        for (int i = 0; i < nums.Length; i++)
                        {
                            if (i != firstElement)
                            {
                                num = $"{num}{nums[i]}";
                            }
                        }
                    }
                }
            }

        }
    }
}
