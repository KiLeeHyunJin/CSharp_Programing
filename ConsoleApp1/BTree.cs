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
        void SetData(BTNode<T> node, T data)            {    node.data = (data);            }
        public BTNode<T> Search(T target)               { return Search(root, target); }

        public void Insert(T data)
        {
            if (root == null)
                root = MakeNode(data);
            else
                root = BSTInsert(root, data);
            root = Rebalance(root);
        }
        void RepeatInsert(BTNode<T> cNode, T data)
        {
            int num = cNode.Compare(data);
            if (num == 0)
                return;
            if (num == 1)
            {
                if (GetLeftChild(cNode) == null)
                {
                    MakeLeftChild(cNode,MakeNode(data));
                }
                else
                {
                    RepeatInsert(GetLeftChild(cNode), data);
                    MakeLeftChild(cNode,Rebalance(GetLeftChild(cNode)));
                }
            }
            else
            {
                if (GetRightChild(cNode) == null)
                {
                    MakeRightChild(cNode,MakeNode(data));
                }
                else
                {
                    RepeatInsert(GetRightChild(cNode), data);
                    MakeRightChild(cNode,Rebalance(GetRightChild(cNode)));
                }
            }
            //cNode = Rebalance(cNode);
        }

        BTNode<T> BSTInsert(BTNode<T> root,T data)
        {
            root = Rebalance(root);
            if (root.Compare(data) > 0)
            {
                if (GetLeftChild(root) == null)
                    MakeLeftChild(root, MakeNode(data));
                else
                    BSTInsert(GetLeftChild(root), data);
                MakeLeftChild(root,Rebalance(GetLeftChild(root)));
            }
            else if(root.Compare(data) < 0)
            {
                if (GetRightChild(root) == null)
                    MakeRightChild(root, MakeNode(data));
                else
                    BSTInsert(GetRightChild(root), data);
                MakeRightChild(root,Rebalance(GetRightChild(root)));
            }
            return root;
        }
        public void Remove(T data)
        {
            BTNode<T> dNode = null;
            BTNode<T> cNode = root;
            BTNode<T> pNode = root;
            BTNode<T> vRoot = MakeNode(data);
            MakeRightChild(vRoot,root);
            if (cNode.Compare(data) == 0)
                dNode = cNode;
            else
            {
                while ( cNode != null && cNode.Compare(data) != 0)
                {
                    pNode = cNode;
                    if (cNode.Compare(data) > 0)
                        cNode = GetLeftChild(cNode);
                    else if (cNode.Compare(data) < 0)
                        cNode = GetRightChild(cNode);
                }
            }
            dNode = cNode;

            if (dNode == null)
                return;

            if (GetLeftChild(dNode) == null && GetRightChild(dNode) == null)
            {
                if(GetLeftChild(pNode) == dNode)
                    MakeLeftChild(pNode,dNode.right);
                else
                   MakeRightChild(pNode,dNode.left);
            }
            else if (GetLeftChild(dNode) == null || GetRightChild(dNode) == null)
            {
                BTNode<T> mNode = null;
                if (GetLeftChild(dNode) == null)
                    mNode = GetRightChild(dNode);
                else
                    mNode = GetLeftChild(dNode);

                if (GetLeftChild(pNode) == dNode)
                    MakeLeftChild(pNode,mNode);
                else
                    MakeRightChild(pNode,mNode);
            }
            else
            {
                BTNode<T> mpNode = dNode;
                BTNode<T> mNode = GetRightChild(dNode);
                while (GetLeftChild(mNode) != null)
                {
                    mpNode = mNode;
                    mNode = GetLeftChild(mNode);
                }

                dNode.data = (mNode.data);

                if (GetLeftChild(mpNode) == mNode)
                    MakeLeftChild(mpNode,GetRightChild(mNode));
                else
                    MakeRightChild(mpNode,GetRightChild(mNode));
            }
            vRoot = Rebalance(vRoot);
            if (GetRightChild(vRoot) != root)
                root = null;
        }
        int GetHeightDiff(BTNode<T> root)
        {
            var (lsh, rsh) = (0, 0);
            if (root == null)
                return 0;
            lsh = GetHeight(GetLeftChild(root));
            rsh = GetHeight(GetRightChild(root));
            return lsh - rsh;
        }
        int GetHeight(BTNode<T> root)
        {
            if (root == null)
                return 0;
            var (leftH, rightH) = (0, 0);
            leftH = GetHeight(GetLeftChild(root));
            rightH = GetHeight(GetRightChild(root));
            if (leftH > rightH)
                return leftH + 1;
            else
                return rightH + 1;
        }

        BTNode<T> Rebalance(BTNode<T> root)
        {
            int hDiff = GetHeightDiff(root);
            if(hDiff > 1)
            {
                if (GetHeightDiff(GetLeftChild(root)) > 0)
                    root = RotateLL(root);
                else
                    root = RotateLR(root);
            }
            if(hDiff < -1)
            {
                if(GetHeightDiff(GetRightChild(root)) < 0)
                    root = RotateRR(root);
                else
                    root = RotateRL(root);
            }
            return root;
        }

        BTNode<T> RotateRR(BTNode<T> pNode)
        {
            BTNode<T> cNode = GetRightChild(pNode);
            MakeRightChild(pNode,GetLeftChild(cNode));
            MakeLeftChild(cNode,pNode);
            return cNode;
        }

        BTNode<T> RotateLL(BTNode<T> pNode)
        {
            BTNode<T> cNode = GetLeftChild(pNode);
            MakeLeftChild(pNode,GetRightChild(cNode));
            MakeRightChild(cNode,pNode);
            return cNode;
        }
        BTNode<T> RotateRL(BTNode<T> pNode)
        {
            BTNode<T> cNode = GetRightChild(pNode);
            MakeRightChild(pNode,RotateLL(cNode));
            return RotateRR(pNode);
        }
        BTNode<T> RotateLR(BTNode<T> pNode)
        {
            MakeLeftChild(pNode,RotateRR(GetLeftChild(pNode)));
            return RotateLL(pNode);
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
                    if (GetLeftChild(cNode) != null)
                        node = Search(GetLeftChild(cNode), target);
                }
                else
                {
                    if (GetLeftChild(cNode) != null)
                        node = Search(GetLeftChild(cNode), target);
                }
            }
            return node;
        }

        BTNode<T> GetLeftChild(BTNode<T> node)
        {
            return node.left;
        }
        BTNode<T> GetRightChild(BTNode<T> node)
        {
            return node.right;
        }
        BTNode<T> MakeLeftChild(BTNode<T> node, BTNode<T> cNode)
        {
            return node.left = cNode;
        }
        BTNode<T> MakeRightChild(BTNode<T> node, BTNode<T> cNode)
        {
            return node.right = cNode;
        }


    }
    public class BTNode<T> where T : IComparable
    {
        internal T data;
        internal BTNode<T> right;
        internal BTNode<T> left;
        public int Compare(T data) { int num = this.data.CompareTo(data); return num; }
        public BTNode (T data)
        {
            this.data = data;
        }
    }
}
