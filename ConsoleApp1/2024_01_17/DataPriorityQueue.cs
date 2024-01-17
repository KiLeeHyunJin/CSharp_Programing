using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1._2024_01_17
{
    internal class DataPriorityQueue<TElement,TPriority> where TPriority : IComparable<TPriority>
    {
        struct Node
        {
            public TElement element;
            public TPriority priority;

            public Node(TElement element, TPriority priority)
            {
                this.element = element;
                this.priority = priority;
            }
        }
        List<Node> nodes;
        public DataPriorityQueue()
        {
            nodes = new List<Node>();
        }
        public DataPriorityQueue(int capacity)
        {
            nodes = new List<Node>(capacity);
        }
        public void Enqueue(TElement element, TPriority priority)
        {
            Node newNode = new Node(element, priority);
            nodes.Add(newNode);
            int idx = nodes.Count - 1;
            while( idx > 0)
            {
                int parentIdx = (idx - 1) >> 1;
                if (nodes[parentIdx].priority.CompareTo(nodes[idx].priority) < 0)
                {
                    nodes[idx] = nodes[parentIdx];
                    idx = parentIdx;
                }
                else
                {
                    break;
                }
            }
            nodes[idx] = newNode;
        }
        public TElement Dequeue() 
        {
            Node rNode = nodes[0];
            Node lastNode = nodes[nodes.Count - 1];
            nodes[0] = lastNode;
            nodes.RemoveAt(nodes.Count - 1);

            int idx = 0;
            while(idx <= nodes.Count)
            {
                int leftIndex = 2 * idx + 1;
                int rightIndex = 2 * idx + 2;
                if(rightIndex < nodes.Count)
                {
                    int lessIdx;
                    if (nodes[leftIndex].priority.CompareTo(nodes[rightIndex].priority) < 0)
                    {
                        lessIdx = leftIndex;
                    }
                    else
                    {
                        lessIdx = rightIndex;
                    }
                    if (nodes[idx].priority.CompareTo(nodes[lessIdx].priority) > 0)
                    {
                        nodes[idx] = nodes[lessIdx];
                        nodes[lessIdx] = lastNode;
                        idx = lessIdx;
                    }
                    else
                    {
                        break;
                    }
                }
                else if(leftIndex < nodes.Count)
                {
                    if (nodes[idx].priority.CompareTo(nodes[leftIndex].priority) > 0)
                    {
                        nodes[idx] = nodes[leftIndex];
                        nodes[leftIndex] = lastNode;
                        idx = leftIndex;
                    }
                    else
                    {
                        break;
                    }
                }
                else
                {
                    break;
                }
            }
            nodes[idx] = lastNode;


            return nodes.Count > 0? rNode.element : default(TElement);
        }
        int ReturnIdx(int idx)
        {
            if(idx == nodes.Count - 1)
            {
                return idx;
            }
            else if (nodes[(idx << 1) + 1].priority.CompareTo(nodes[(idx << 1) + 2].priority) < 0)
            {
                if(nodes[(idx << 1) + 2].priority.CompareTo(nodes[idx].priority) < 0)
                {
                    return 0;
                }
            }
            else
            {
                if (nodes[(idx << 1) + 2].priority.CompareTo(nodes[idx].priority) < 0)
                {
                    return 0;
                }
            }
            return 0;
        }

    }
}
