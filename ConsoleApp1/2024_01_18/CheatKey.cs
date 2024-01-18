using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Collections.Specialized.BitVector32;

namespace ConsoleApp1._2024_01_18
{
    public class CheatKey
    {
        Dictionary<string, Action> cheatDic;

        public CheatKey()
        {
            Init();
        }
        void Init()
        {
            cheatDic = new Dictionary<string, Action>();
            cheatDic.Add("ThereIsNoCowLevel", new Action(ThereIsNoCowLevel));
            cheatDic.Add("ShowMeTheMoney", new Action(ShowMeTheMoney));
        }

        public void Run(string cheatKey)
        {
            cheatDic.TryGetValue(cheatKey, out Action action);
            action?.Invoke();
        }
        public void ShowMeTheMoney()
        {
            Console.WriteLine("골드를 늘려주는 치트키 발동!");
        }
        public void ThereIsNoCowLevel()
        {
            Console.WriteLine("바로 승리합니다. 치트키 발동!");
        }

    }
}
