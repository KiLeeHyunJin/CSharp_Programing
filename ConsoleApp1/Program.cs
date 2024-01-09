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
            for (int i = 11; i > 0 ; i--)
            {
                BST.Insert(i);
            }

            Console.Write(BST.root);
        }
        public struct ReadKey
        {
            public char KeyChar;
         }
    }
}
