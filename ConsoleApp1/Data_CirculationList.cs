using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace ConsoleApp1
{
    public class Data_CirculationList
    {
        public Data_CirculationListNode tail;
        public Data_CirculationListNode cur;
        public Data_CirculationListNode before;
        public int count;
        public void Init()
        {
            tail = null;
            cur = null;
            before = null;
            count = 0;
        }
        public void InsertLast(int data)
        {
            Data_CirculationListNode node= new Data_CirculationListNode();
            node.data = data;
            if (tail == null)
            {
                tail = node;
                node.next = node;
                node.prev = node;
                cur = node;
            }
            else
            {
                node.next = tail.next;
                node.prev = tail;
                tail.next = node;
                tail = node;
            }
            count++;
        }
        public void InsertFront(int data)
        {
            Data_CirculationListNode node = new Data_CirculationListNode();
            node.data = data;
            if (tail == null)
            {
                tail = node;
                node.next = node;
                node.prev = node;
                cur = node;

            }
            else
            {
                node.next = tail.next;
                node.prev = tail;
                tail.next = node;
            }
            count++;
        }
        public void Insert(int data)
        {
            Data_CirculationListNode node = new Data_CirculationListNode();
            node.data = data;
            if (tail == null)
            {
                tail = node;
                node.next = node;
                node.prev = node;
                cur = node;
            }
            else
            {
                node.prev = cur.prev;
                node.next = cur;
                node.prev.next = node;
                cur.prev = node;
            }
            count++;
        }
        public int First()
        {
            if (tail == null)
                return 0;
            before = tail;
            cur = tail.next;

            return cur.data;
        }
        public int Next(int data)
        {
            if (tail == null)
                return 0;
            before = cur;
            cur = cur.next;
            return cur.data;
        }
        public int Remove()
        {
            Data_CirculationListNode rnode = cur;
            int rData = cur.data;
            if(rnode == tail)
            {
                if (tail == tail.next)
                    tail = null;
                else
                    tail = tail.prev;
            }
            cur.prev.next = cur.next;
            cur.next.prev = cur.prev;
            cur = cur.next;
            count--;
            return rData;
        }
    }
    public class Data_CirculationListNode
    {
        public int data;
        public Data_CirculationListNode next;
        public Data_CirculationListNode prev;
    }

}
