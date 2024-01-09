using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class BTree<T> where T : IComparable
    {
        public BTNode<T> root;

        BTNode<T> MakeNode(T data = default(T))         {   return new BTNode<T>(data);     }
        void SetData(BTNode<T> node, T data)            {    node.SetData(data);            }
        public BTNode<T> Search(T target)               { return Search(root, target); }

        public void Insert(T data)
        {
            if (root == null)
                root = MakeNode(data);
            else
                RepeatInsert(root, data);
        }
        void RepeatInsert(BTNode<T> cNode, T data)
        {
            int num = cNode.Compare(data);
            if (num == 0)
                return;
            if (num == 1)
            {
                if(cNode.GetLeftNode() == null)
                    cNode.MakeLeftNode(MakeNode(data));
                else
                    RepeatInsert(cNode.GetLeftNode(), data);
            }
            else
            {
                if(cNode.GetRightNode() == null)
                    cNode.MakeRightNode(MakeNode(data));
                else
                    RepeatInsert(cNode.GetRightNode(), data);
            }
        }
        public void Remove(T data)
        {
            BTNode<T> dNode = null;
            BTNode<T> cNode = root;
            BTNode<T> pNode = root;
            if (cNode.Compare(data) == 0)
                dNode = cNode;
            while (dNode == null && cNode != null)
            {
                pNode = cNode;
                if (cNode.Compare(data) > 0)
                    cNode = cNode.GetLeftNode();
                else if (cNode.Compare(data) < 0)
                    cNode = cNode.GetRightNode();
                if(cNode.GetData().Equals(data))
                    dNode = cNode;
            }
            if (dNode == null)
                return;

            if (dNode.GetLeftNode() == null && dNode.GetRightNode() == null)
            {
                pNode.MakeLeftNode();
                pNode.MakeRightNode();
            }
            else if (dNode.GetLeftNode() == null || dNode.GetRightNode() == null)
            {
                BTNode<T> mNode = null;
                if (dNode.GetLeftNode() == null)
                {
                    mNode = dNode.GetRightNode();
                }
                else
                {
                    mNode = dNode.GetLeftNode();
                }
                if (pNode.GetLeftNode() == dNode)
                {
                    pNode.MakeLeftNode(mNode);
                }
                else
                {
                    pNode.MakeRightNode(mNode);
                }
            }
            else
            {



            }
        }
        BTNode<T> Search(BTNode<T> cNode, T target)
        {
            if(cNode == null)
                return null;
            int num = cNode.Compare(target);
            BTNode<T> node = null;
            if (num == 0)
                return cNode;
            else
            {
                if (num == -1)
                {
                    if (cNode.GetRightNode() != null)
                        node = Search(cNode.GetRightNode(), target);
                }
                else
                {
                    if (cNode.GetLeftNode() != null)
                        node = Search(cNode.GetLeftNode(), target);
                }
            }
            return node;
        }



    }
    public  class BTNode<T> where T: IComparable
    {
        T data;
        BTNode<T> right;
        BTNode<T> left;
        internal BTNode(T data = default(T))                            {   this.data = data;   }
        internal void SetData(T data)                                   {   this.data = data;   }
        internal void MakeLeftNode(BTNode<T> leftNode = null)           {   left = leftNode;    }
        internal void MakeRightNode(BTNode<T> rightNode = null)         {   right = rightNode;  }
        internal BTNode<T> GetRightNode()                               { return right; }
        internal BTNode<T> GetLeftNode()                                { return left; }
        internal int Compare(T data)                                    { return this.data.CompareTo(data); }
        internal T GetData()                                            { return this.data; }
    }
}
