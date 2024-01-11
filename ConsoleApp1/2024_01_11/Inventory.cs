using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1._2024_01_11
{
    internal class Inventory
    {
        DataList<Item> inven = new DataList<Item>();
        public void AddItem(Item item)
        {
            inven.Add(item);
        }
        public void RemoveItem(Item item) 
        {  
            inven.Remove(item); 
        }
    }
    public class Item
    {

    }
}
