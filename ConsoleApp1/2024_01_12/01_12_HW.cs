using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1._2024_01_12
{
    public class _01_12_HW
    {
        public void Test()
        {
            Console.WriteLine("How Want Size ? :");
            var (input, size) = (0, 0);
            
            bool isCheck = false;
            do
            {
                isCheck = int.TryParse(Console.ReadLine(), out size);
                if (isCheck == false)
                    Console.WriteLine("Re Input Please");
            } while (isCheck == false);
            LinkedList<int> list = new LinkedList<int>();
            do
            {
                isCheck = int.TryParse(Console.ReadLine(), out input);
                if(isCheck == false)
                {
                    Console.WriteLine("Re Input Please");
                }
                else
                {
                    if(input > 0)
                    {
                        list.AddLast(input);
                    }
                    else
                    {
                        list.AddFirst(input);
                    }
                }
            } while (list.Count < size);

            foreach (var item in list)
            {
                Console.WriteLine(item);
            }

        }
        public void OsefusArray(int size,int jump)
        {
            LinkedList<int> list = new LinkedList<int>();
            for (int i = 1; i <= size; i++)
                list.AddLast(i);
            LinkedListNode<int> iter;
            LinkedListNode<int> remove;
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Capacity = size;
            iter = list.First;
            for (int i = 0; i < jump - 1; i++)
            {
                if (iter.Next != null)
                {
                    iter = iter.Next;
                }
                else
                {
                    iter = list.First;
                }
            }
            stringBuilder.Append(iter.Value.ToString());
            remove = iter;

            iter = iter.Next;
            list.Remove(remove);

            while (list.Count != 1)
            {
                for (int i = 0; i < jump-1; i++)
                {
                    if(iter.Next != null)
                    {
                        iter = iter.Next;
                    }
                    else
                    {
                        iter = list.First;
                    }
                }
                stringBuilder.Append(iter.Value.ToString());
                remove = iter;
                if (iter.Next != null)
                {
                    iter = iter.Next;
                }
                else
                {
                    iter = list.First;
                }
                list.Remove(remove);
            }
            iter = list.First;
            stringBuilder.Append(iter.Value.ToString());

            Console.WriteLine(stringBuilder.ToString());
        }
    }
}
