using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ConsoleApp1._2024_01_12
{
    public class DataLinkedList<T>
    {
        DataLinkedListNode<T> head;
        DataLinkedListNode<T> tail;
        int count;
        public int Count { get { return count; } }
        public DataLinkedList()
        {
            Clear();
        }
        public void Clear()
        {
            this.head = null;
            this.tail = null;
            this.count = 0;
        }
        public DataLinkedListNode<T> AddFirst(T data)
        {
            DataLinkedListNode<T> newNode = new DataLinkedListNode<T>(data);

            if(Count == 0)
                AddIsFirstInsert(newNode);
            else
                InsertAfter(head, newNode);
            return newNode;
        }
        void AddIsFirstInsert(DataLinkedListNode<T> newNode)
        {
            head = newNode;
            tail = newNode;
            count = 1;
        }
        public DataLinkedListNode<T> AddLast(T data)
        {
            DataLinkedListNode<T> newNode = new DataLinkedListNode<T>(data);

            if (Count == 0)
            {
                AddIsFirstInsert(newNode);
            }
            else
            {
                InsertBefore(tail, newNode);
            }
            return newNode;
        }
        public DataLinkedListNode<T> AddBefore(DataLinkedListNode<T> node ,T data)
        {
            DataLinkedListNode<T> newNode = new DataLinkedListNode<T>(data);
            InsertBefore(node, newNode);
            return newNode;
        }
        public DataLinkedListNode<T> AddAfter(DataLinkedListNode<T> node,T data)
        {
            DataLinkedListNode<T> newNode = new DataLinkedListNode<T>(data);
            InsertAfter(node, newNode);
            return newNode;
        }
        public void InsertBefore(DataLinkedListNode<T> node, DataLinkedListNode<T> newNode)
        {
            DataLinkedListNode<T> prevNode = node.prev;
            node.prev = newNode;
            newNode.next = node;

            if(node != head)
                prevNode.next = newNode;
            else
                head = newNode;

            newNode.prev = prevNode;

            count ++;
        }
        public void InsertAfter(DataLinkedListNode<T> node, DataLinkedListNode<T> newNode)
        {
            DataLinkedListNode<T> nextNode = node.next;
            node.next = newNode;
            newNode.prev = node;

            if (node != tail)
                nextNode.prev = newNode;
            else
                tail = newNode;

            newNode.next = nextNode;
            count++;
        }

        public DataLinkedListNode<T> Find(T data)
        {
            DataLinkedListNode<T> iter = head;
            while(iter != null)
            {
                if(iter.Value.Equals(data))
                    return iter;
                iter = iter.next;
            }
            return null;
        }
        public bool Remove(T data)
        {
            return Remove(Find(data));
        }
        public bool Remove(DataLinkedListNode<T> node)
        {
            if(node == null)
                return false;

            if(node == head)
            {
                head = node.next;
            }
            if(node == tail)
            {
                tail = node.prev;
            }
            if(node.prev != null)
            {
                node.prev.next = node.next;
                node.next.prev = node.prev;
            }
            if(node.next != null)
            {
                node.next.prev = node.prev;
                node.prev.next = node.next;
            }
            count--;
            return true;
        }

    }
    public class DataLinkedListNode<T>
    {
        T data;
        internal DataLinkedListNode<T> prev;
        internal DataLinkedListNode<T> next;
        public T Value { get { return data; } }
        public DataLinkedListNode(T data)
        {
            this.data = data;
            prev = null;
            next = null;
        }
    }
}
