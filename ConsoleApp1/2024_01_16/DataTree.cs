using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1._2024_01_16
{
    internal class DataTree
    {
        DataTreeNode root;

        public DataTree()
        {
            root = null;
        }

        public bool Add(int data)
        {
            DataTreeNode node = new DataTreeNode(data);
            if(root == null)
            {
                root = node;
                return true;
            }
            else
            {
                DataTreeNode current = root;
                while(current != null)
                {
                    if(current.data > data)
                    {
                        if (current.left == null)
                        {
                            current.left = node;
                            node.parent = current;
                            return true;
                        }
                        else 
                            current = current.left;
                    }
                    else if(current.data < data)
                    {
                        if (current.right == null)
                        {
                            current.right = node;
                            node.parent = current;
                            return true;
                        }
                        else
                            current = current.right;
                    }
                    else
                        return false;
                }
                return false;
            }
        }
        DataTreeNode FindNode(int data)
        {
            DataTreeNode node = root;
            while (node != null) 
            {
                if (node.data == data)
                    break;
                if(node.data > data)
                    node = node.left;
                else if(node.data < data)
                    node = node.right;
            }
            return node;
        }
        public bool Contains(int data)
        {
            DataTreeNode findNode = FindNode(data);
            if (findNode == null)
                return false;
            return true;
        }

        public bool Remove(int data) 
        {
            if (root == null)
                return false;
            DataTreeNode rNode = FindNode(data);
            if (rNode == null)
                return false;
            EraseNode(rNode);
            return true;
        
        }
        void EraseNode(DataTreeNode rNode)
        {
            if (rNode.HasNoChild)
            {
                if (rNode.IsLeftChild)
                    rNode.parent.left = null;
                else if (rNode.IsRightChild)
                    rNode.parent.right = null;
                else
                    root = null;
            }
            else if (rNode.HasLeftChild || rNode.HasRightChild)
            {
                DataTreeNode parent = rNode.parent;
                DataTreeNode child = rNode.HasLeftChild ? rNode.left : rNode.right;

                if (rNode.HasLeftChild)
                {
                    parent.left = child;
                    child.parent = parent;
                }
                else if (rNode.HasRightChild)
                {
                    parent.right = child;
                    child.parent = parent;
                }
                else
                {
                    root = child;
                    child.parent = null;
                }
            }
            else
            {
                DataTreeNode child = rNode.right;
                while (child.left != null)
                {
                    child = child.left;
                }
                rNode.data = child.data;
                EraseNode(child);
            }
        }
    }
    internal class DataTreeNode
    { 
        internal int data;
        internal DataTreeNode parent;
        internal DataTreeNode left;
        internal DataTreeNode right;
        internal DataTreeNode(int data, DataTreeNode parent, DataTreeNode left, DataTreeNode right)
        {
            this.data = data;
            this.parent = parent;
            this.left = left;
            this.right = right;
        }
        internal DataTreeNode(int data)
        {
            this.data = data;
            this.parent = null;
            this.left = null;
            this.right = null;
        }
        internal bool IsRootNode { get { return parent == null; } }
        internal bool IsLeftChild { get { return parent != null && parent.left == this; } }
        internal bool IsRightChild { get { return parent != null && parent.right == this; } }
        internal bool HasNoChild { get { return left == null && right == null; } }
        internal bool HasLeftChild { get { return left != null && right == null; } }
        internal bool HasRightChild { get { return left == null && right != null; } }
        internal bool HasBothChild { get { return left != null && right != null; } }
    
    }

}
