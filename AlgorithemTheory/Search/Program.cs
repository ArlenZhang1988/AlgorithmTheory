using System;
using System.Collections.Generic;

namespace Search
{
    class Program
    {
        static void Main(string[] args)
        {
            BinarySearchTree<int, string> bst = new BinarySearchTree<int, string>();

            bst.Put(25, "LOl");
            bst.Put(2, "LOl");
            bst.Put(4, "XD");

            Console.WriteLine(bst.Ceiling(5)); 
        }
    }
}
