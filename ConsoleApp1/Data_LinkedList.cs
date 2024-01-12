using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class Data_LinkedList<T>
    {
        Data_LinkedListNode<T> head;
        Data_LinkedListNode<T> tail;
        int count;

        public int Count{ get { return count; } }
        public Data_LinkedList()
        {
            head = tail = null;
            count = 0;
        }

        public Data_LinkedListNode<T> AddFirst(T value)
        {
            Data_LinkedListNode<T> newNode = new Data_LinkedListNode<T>(value);
            if(count == 0)
                InsertNodeToEmptyList(newNode);
            else
                InsertNodeBefore(head, newNode);
            return newNode;
        }
        public Data_LinkedListNode<T> First { get { return head; } }
        public Data_LinkedListNode<T> Last { get { return tail; } }
        void InsertNodeToEmptyList(Data_LinkedListNode<T> newNode)
        {
            head = newNode;
            tail = newNode;
            count = 1;
        }
        public Data_LinkedListNode<T> AddBefore(Data_LinkedListNode<T> node,T value)
        {
            Data_LinkedListNode<T> newNode = new Data_LinkedListNode<T>(value);
            InsertNodeBefore(node, newNode);
            return newNode;
        }
        void InsertNodeBefore(Data_LinkedListNode<T> node, Data_LinkedListNode<T> newNode)
        {
            Data_LinkedListNode<T> prevNode = node.prev;
            newNode.prev = prevNode;
            newNode.next = node;

            if(node == head)
                head = newNode;
            else
                prevNode .next = newNode;

            node.prev = prevNode;
            count++;
        }
        public Data_LinkedListNode<T> AddLast(T data)
        {
            Data_LinkedListNode<T> newNode = new Data_LinkedListNode<T>(data);
            if (count == 0)
                InsertNodeToEmptyList(newNode);
            else
                InsertNodeAfter(tail, newNode);
            return newNode;
        }
        public Data_LinkedListNode<T> AddNext(Data_LinkedListNode<T> node, T data)
        {
            Data_LinkedListNode<T> newNode = new Data_LinkedListNode<T>(data);
            InsertNodeAfter(node, newNode);
            return newNode;
        }
        void InsertNodeAfter(Data_LinkedListNode<T> node, Data_LinkedListNode<T> newNode)
        {
            Data_LinkedListNode<T> nextNode = node.next;
            node.next = newNode;
            newNode.prev = node;

            if (node == tail)
                tail = newNode;
            else
                nextNode.prev = newNode;

            newNode.next = nextNode;
            count++;
        }
        public bool Remove(T data)
        {
            Data_LinkedListNode<T> removeNode = Find(data);
            return Remove(removeNode);
        }
        public void RemoveFirst()
        {
            Remove(head);
        }
        public void RemoveLast()
        {
            Remove(tail);
        }
        public bool Remove(Data_LinkedListNode<T> removeNode)
        {
            if (removeNode == null)
                return false;
            
            if(removeNode == head)
                head = removeNode.next;
            if (removeNode == tail)
                tail = removeNode.prev;
            
            if (removeNode.prev != null)
                removeNode.prev.next = removeNode.next;
            if (removeNode.next != null)
                removeNode.next.prev = removeNode.prev;
            
            count--;
            return true;
        }
        public Data_LinkedListNode<T> Find(T data)
        {
            Data_LinkedListNode<T> iter = head;

            while(iter != null)
            {
                if(iter.Value.Equals(data))
                    return iter;

                iter = iter.Next;
            }
            return null;
        }
    }
    public class Data_LinkedListNode<T>
    {
        T value;
        public Data_LinkedListNode<T> next;
        public Data_LinkedListNode<T> prev;

        public Data_LinkedListNode(T value) {this.value = value;}
        public Data_LinkedListNode()    {   }
        public void SetLink(Data_LinkedListNode<T> next, Data_LinkedListNode<T> prev)
        {
            this.next = next;
            this.prev = prev;
        }
        
        public Data_LinkedListNode<T> Prev { get { return prev; } }
        public Data_LinkedListNode<T> Next { get { return next; } }
        public T Value { get { return value; } set { this.value = value; } }
    }

}
