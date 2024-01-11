using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace ConsoleApp1._2024_01_11
{
    public class DataList<T>
    {
        T[] arr;
        int count = 0;
        const int DefaultCapacity = 4;
        public DataList()               { arr = new T[DefaultCapacity]; }
        public DataList(int capacity)   { arr = new T[capacity]; }
        public DataList(T[] _arr)       { arr = _arr; }
        public bool IsFull{ get { return count == Capacity; } }
        public T this[int idx] 
        { 
            get { return arr[idx]; }
            set { arr[idx] = value; } 
        }
        public int Count { get { return count; } }
        public int Capacity { get { return arr.Length; } }
        public void Add(T data)
        {
            if(IsFull)
            {
                Grow();
            }
            arr[count] = data;
            Console.WriteLine($"{data}를 추가합니다.");
            count++;
        }
        void Grow()
        {
            T[] newArr = new T[Capacity << 1];
            Array.Copy(arr, newArr, Capacity);
            arr = newArr;
        }
        public void Insert(int idx, T data)
        {
            if(idx < 0 || idx >= count)
                throw new ArgumentOutOfRangeException();
            Array.Copy(arr, idx , arr,idx + 1, count - idx);
            arr[idx] = data;
            count++;
        }
        public void RemoveAt(int idx)
        {
            if (idx < 0 || idx >= count)
                throw new ArgumentOutOfRangeException();
            Console.WriteLine($"{arr[idx]}를 제거합니다.");
            count--;
            Array.Copy(arr, idx + 1, arr, idx, count - (idx));
        }
        public bool ContainsCheck(T data)
        {
            if (IndexOf(data) >= 0)
                return true;
            return false;
        }
        public void InsertRemove(T data)
        {
            if (IndexOf(data) == -1)
                Add(data);
            else
                Remove(data);
        }
        public void Remove(T data)
        {
            var (i, idx) = (0, 0);
            do
            {
                idx =  IndexOf(data);
                if(idx != -1)
                    RemoveAt(idx);
            } while (idx != -1);
        }
        public int IndexOf(T data)
        {
            for (int i = 0; i < count; i++)
            {
                if (arr[i] == null)
                    continue;
                if (arr[i].Equals(data))
                {
                    return i;
                }
            }
            return -1;
        }


    }
}
