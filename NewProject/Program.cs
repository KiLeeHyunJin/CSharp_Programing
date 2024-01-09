namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
            Console.WriteLine("S");
            Console.WriteLine("S");
   
            Console.WriteLine("D");

            BTree<int> BST = new BTree<int>();
            BST.Insert(1);
            BST.Insert(5);
            BST.Insert(3);
            BST.Insert(2);
            BST.Insert(4);
            BST.Insert(7);
            BST.Insert(6);
            BST.Insert(7);
            BST.Insert(9);
            BST.Remove(12);
            BTNode<int> d = BST.Search(1);
            Console.Write(d);
        }
    }
}
