using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1._2024_01_15
{
    internal class DataQueue
    {
        const int DefaultCapacity = 4;

        int[] array;
        int count;
        int head;
        int tail;

        public DataQueue()
        {
            this.array = new int[DefaultCapacity];
            this.count = 0;
            this.head = 0;
            this.tail = 0;
        }

        public void Enqueue(int data)
        {
            if (IsFull())
            {
                Grow();
                Console.WriteLine("데이터가 꽉 찼습니다.");
                return;
            }

            array[tail] = data;
            tail = (tail + 1) % array.Length;
            count++;
        }
        public bool IsFull()
        {
            System.Index last = ^1;
            if( head > tail)
            {
                return head == tail + 1;
            }
            else
            {
                return head == 0 && tail == array.Length - 1;
            }
        }
        void Grow()
        {
            int[] newArray = new int[array.Length << 1];
            if(head < tail)
            {
                Array.Copy(array,head, newArray,0, tail);
            }
            else
            {
                Array.Copy(array, head, newArray,0, array.Length - head);
                Array.Copy(array, 0, newArray, array.Length - head, tail);
            }
            //Buffer.BlockCopy();
            //Buffer.MemoryCopy();
            //Array.Copy();
            array = newArray;
            tail = count; //마지막 위치
            head = 0;//맨 앞
        }
        public int Dequeue()
        {
            if(count == 0)
            {
                Console.WriteLine("데이터가 없습니다.");
                return 0;
            }
            int rData = array[head];
            head = (head + 1) % array.Length;
            return rData;
        }
    }
}
