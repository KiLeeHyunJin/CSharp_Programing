using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1._2024_01_18
{
    public class FindPW
    {

        
        public void Main()
        {
            Dictionary<string, string> bookMark = new Dictionary<string, string>();
            string[] count = Console.ReadLine().Split(' ');
            int repeatNum = int.Parse(count[0]);
            for (int i = 0; i < repeatNum; i++)
            {
                string[] str = Console.ReadLine().Split(' ');
                bookMark.Add(str[0], str[1]);
            }
            int findCount = int.Parse(count[1]);
            string[] wantSite = new string[findCount];
            for (int i = 0; i < findCount; i++)
            {
                wantSite[i] = Console.ReadLine();
            }

            for (int i = 0; i < wantSite.Length; i++)
            {
                Console.WriteLine(bookMark[wantSite[i]]);
            }
        }
    }
}
