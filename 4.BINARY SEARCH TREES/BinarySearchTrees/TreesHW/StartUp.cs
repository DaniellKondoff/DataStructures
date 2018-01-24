using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TreesHW
{
    class StartUp
    {
        static void Main(string[] args)
        {
            BST<int> bst = new BST<int>();

            bst.Insert(10);
            bst.Insert(5);
            bst.Insert(3);
            bst.Insert(1);
            bst.Insert(4);
            bst.Insert(8);
            bst.Insert(9);
            bst.Insert(37);
            bst.Insert(39);
            bst.Insert(45);

            Console.WriteLine();
        }
    }
}
