using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Programmers
{
    public class Running
    {
        public string[] solution(string[] players, string[] callings)
        {
            string[] answer = new string[players.Length];

            Dictionary<string, int> pairs = new Dictionary<string, int>();//명단표
            for (int i = 0; i < players.Length; i++)
            {
                pairs.Add(players[i], i); //
                answer[i] = (players[i]);
            }
            for (int i = 0; i < callings.Length; i++)
                ChangeNum(pairs, answer, ref callings[i]);
            return answer;
        }
        public void ChangeNum(Dictionary<string, int> pairs, string[] rank, ref string name)
        {
            int idx;
            pairs.TryGetValue(name, out idx);
            if (idx == 0)
                return;
            string chaser = rank[idx];
            rank[idx] = rank[idx - 1];
            rank[idx - 1] = chaser;
            pairs[chaser] = idx - 1;
            pairs[rank[idx]] = idx;
        }
    }
}
