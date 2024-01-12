using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class DataStruct
    {

        public void Test()
        {
            int[] arr = { 1, 2, 3, 4, 5, 6 };
            LinkedList<int> linkedlist = new LinkedList<int>();
            LinkedListNode<int> node0 = new LinkedListNode<int>(0);
            LinkedListNode<int> node1 = new LinkedListNode<int>(1);
            LinkedListNode<int> node2 = new LinkedListNode<int>(2);
            LinkedListNode<int> node3 = new LinkedListNode<int>(3);
            LinkedListNode<int> node4 = new LinkedListNode<int>(4);

            linkedlist.AddFirst(node0);
            linkedlist.AddFirst(node1);
            linkedlist.AddFirst(node2);
            linkedlist.AddFirst(node3);
            linkedlist.AddFirst(node4);
            linkedlist.CopyTo(arr, arr.Length - 2);
            List<int> list = new List<int>();
            foreach (var item in linkedlist)
                Console.WriteLine(item);
        }
    }
}
