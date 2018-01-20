using System;
using System.Linq;

public class PlayWithTrees
{
    public static void Main()
    {

        Tree<int> tree =
            new Tree<int>(7,
               new Tree<int>(19,
                   new Tree<int>(1),
                   new Tree<int>(12),
                   new Tree<int>(31)),
               new Tree<int>(21),
               new Tree<int>(14,
                   new Tree<int>(23),
                   new Tree<int>(6)));

        var result = tree.OrderBFS();
        Console.WriteLine(string.Join(" ", result));


        BinaryTree<int> bt = 
            new BinaryTree<int>(5, 
                leftChild: new BinaryTree<int>(2), 
                rightChild: new BinaryTree<int>(7));

        bt.EachInOrder(x => Console.WriteLine(x));

        bt.EachPostOrder(x => Console.WriteLine(x));
    }
}
