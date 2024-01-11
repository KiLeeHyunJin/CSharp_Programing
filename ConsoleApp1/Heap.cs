using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class Heap
    {
        HeapNode[] array;
        int count = 0;

        public Heap(int maxSize)
        {
            array = new HeapNode[maxSize];
        }

        public void Insert(int data)
        {
            int idx = count + 1;
            HeapNode nelem = new HeapNode(data);
            while(idx != 1)
            {
                if (data < array[GetParent(idx)].data)
                {
                    array[idx] = array[GetParent(idx)];
                    idx = GetParent(idx);
                }
                else
                    break;
            }
            array[idx] = nelem;
            count += 1;

            //if(array.Length > 0)
            //{
            //    array[count] = new HeapNode(data);
            //}
        }

        public int Pop()
        {
            return Remove();
        }
        int ComparePrIdx(int idx , int data)
        {
            if (GetLeftChild(idx) > count)
                return 0;
            else if (GetLeftChild(idx) == count)
                return GetLeftChild(idx);
            else
            {
                if (array[GetLeftChild(idx)].data.CompareTo(array[GetRightChild(idx)].data) < 0)
                    return GetLeftChild(idx);
                else
                    return GetRightChild(idx);
            }
        }

        int Remove()
        {
            if (count > 0)
            {
                var (data, parentIdx, childIdx) = (array[1].data, 1, 0);
                HeapNode lastElem = array[count];

                while (0 != (childIdx = ComparePrIdx(parentIdx, data)))
                {
                    if (lastElem.data <= array[childIdx].data)
                        break;
                    array[parentIdx] = array[childIdx];
                    parentIdx = childIdx;
                }
                array[parentIdx] = lastElem;
                count -= 1;
                return data;
            }
            return -1;
        }

        int GetLeftChild(int idx){ return idx << 1; }
        int GetRightChild(int idx) {  return ( idx << 1 ) + 1; }
        int GetParent(int idx) { return idx >> 1; }
    }
    internal class HeapNode
    {
        internal int data;
        internal HeapNode(int data)
        {
            this.data = data;
        }
    }

}
