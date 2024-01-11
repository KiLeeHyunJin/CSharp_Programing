using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class Data_List<T>
    {
        T[] items;
        int count;
        const int DefaultCapacity = 4;
        public int Capacity { get { return items.Length; } }
        public int Count { get { return count; } }  
        public bool IsFull { get { return Capacity == Count; } }
        public T this[int idx]
        {
            get 
            { 
                return items[idx]; 
            }
            set
            {
                items[idx] = value; 
            }
        }
        public Data_List()
        {
            this.items = new T[DefaultCapacity];
            count = 0;
        }
        public Data_List(int capacity)
        {
            this.items = new T[capacity];
            count = 0;
        }
        public void Clear() { items = new T[Capacity]; }

        public void Add(T item) 
        {
            if(IsFull)
                Grow();
            items[count] = item;
            count++;
        }
        void Grow()
        {
            T[] newList = new T[Capacity << 1];
            Array.Copy(items, newList, items.Length);
        }
        public void Insert(int idx, T item)
        {
            if (idx < 0 || idx > count)
                throw new ArgumentOutOfRangeException("index");

            if (IsFull)
                Grow();

            Array.Copy(items, idx, items, idx + 1, count - idx);
            items[idx] = item;
            count++;
        }
        public void RemoveAt(int idx) 
        {
            if (idx < 0 || idx >= count)
                throw new ArgumentOutOfRangeException("index");
            count--;
            Array.Copy(items, idx + 1, items, idx, count - idx);
        }

        public bool Remove(T item) 
        {
            int idx = IndexOf(item);
            if(idx > 0)
            {
                RemoveAt(idx);
                return true;
            }
            return false;
        }

        public int IndexOf(T? item)
        {
            int i = 0;
            if (item == null)
                return -1;
            for (i = 0; i < items.Length; i++)
            {
                if (items[i].Equals(item))
                    return i;
            }
            return -1;
        }
    }
}
