using ConsoleApp1.Programmers;

namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //int input = 0;
            //do
            //{
            //    Console.Write("1 에서 9 사이의 수를 입력하세요 : ");
            //    string text = Console.ReadLine();
            //    int.TryParse(text, out input);
            //} while (input < 1 || 9 < input);
            int[] arr = { 1, 2, 3, 4, 5, 6 };
            //oreach (var item in solution(arr, 2))
            {
                //CheckTriangle reversString = new CheckTriangle();
                //int[] arr2 = { 2,2 };
                //Console.WriteLine(reversString.solution(arr2));

            }
            //DataStruct dataStruct = new DataStruct();
            //dataStruct.Test();
            //AnotherSpaceLanguage another = new AnotherSpaceLanguage();
            //string[] str = { "p", "o", "s" };
            //string[] atr = { "sod", "eocd", "qixm", "adio", "soo" };

            //Console.Write(another.solution(str, atr ));
            //Console.WriteLine(TestCode());
            HideNumberSum running = new HideNumberSum();
            string[] str = { "mumu", "soe", "poe", "kai", "mine" };
            string[] call = { "kai", "kai", "mine", "mine" };
            running.solution("1a2b3c4d123Z");
            PriorityQueue<string, int> priorityQueue = new PriorityQueue<string, int>();

        }
        static void TestCode()
        {
            int n;
            n = int.Parse(Console.ReadLine());
            int[] data = new int[n];
            for (int i = 0; i < n; i++)
            {
                data[i] = int.Parse(Console.ReadLine());
            }
            int[] list = new int[n];
            int idx = 0;
            for (int i = 0; i < n; i++)
            {
                if(idx == 0 || data[i] > list[idx - 1])
                {
                    list[idx++] = data[i];
                }
                else
                {
                    int left = 0;
                    int right = idx;
                    int pos = 0;
                    while(left <= right)
                    {
                        int mid = (left + right) / 2;
                        if (list[mid] >= data[i])
                        {
                            right = mid - 1;
                            pos = mid;
                        }
                        else
                        {
                            left = mid + 1;
                        }
                    }
                    list[pos] = data[i];
                }
            }
            foreach (var item in list)
            {
                Console.WriteLine(item);
            }
        }
        
        static long AverageLevel()
        {
            int dataSize = 1000000;
            int n, k;
            int.TryParse(Console.ReadLine(),out n);
            int.TryParse(Console.ReadLine(),out k);
            int[] arr = new int[n];

            for (int i = 0; i < n; i++)
            {
                arr[i] = int.Parse(Console.ReadLine());
            }
            Array.Sort(arr);
            int findNum;
            long answer = 0;

            int left = arr[0];
            int right = arr[0] + k;
            while (left <= right) 
            {
                int mid = (left + right) / 2;
                long added = 0;
                for (int i = 0; i < n; i++)
                {
                    if(mid > arr[i])
                    {
                        added += mid - arr[i];
                    }
                }
                if(added <= k)
                {
                    left = mid + 1;
                    answer = mid > answer ? mid : answer;
                }
                else
                {
                    right = mid - 1;
                }
            }
            return + answer;
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
                re:
                if(i+1 < list.Count)
                {
                    if (list[i] == list[i + 1])
                    {
                        list.RemoveAt(i + 1);
                        goto re;
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
