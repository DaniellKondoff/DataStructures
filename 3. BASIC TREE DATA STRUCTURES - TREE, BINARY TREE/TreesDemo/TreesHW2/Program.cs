using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public class Program
{
    static Dictionary<int, Tree<int>> nodes = new Dictionary<int, Tree<int>>();

    static void Main(string[] args)
    {
        ReadTree();

        Tree<int> root = GetRoot();

        //5 Deepest Node
        var deepestNodes = GetDeepestNode(root);

        foreach (var node in deepestNodes)
        {
            Print(node);
            Console.WriteLine();
        }
    }

    private static void Print(Tree<int> node)
    {
        Console.Write(node.Value + " ");

        foreach (var child in node.Children)
        {
            Print(child);
        }
    }

    private static void ReadTree()
    {
        int n = int.Parse(Console.ReadLine());

        for (int i = 0; i < n - 1; i++)
        {
            var edge = Console.ReadLine().Split().Select(int.Parse).ToArray();

            Tree<int> parent = GetNode(edge[0]);
            Tree<int> child = GetNode(edge[1]);

            parent.Children.Add(child);
            child.Parent = parent;
        }
    }

    private static Tree<int> GetNode(int value)
    {
        if (!nodes.ContainsKey(value))
        {
            nodes[value] = new Tree<int>(value);
        }

        return nodes[value];
    }

    private static Tree<int> GetRoot()
    {
        return nodes.Values.Where(x => x.Parent == null).FirstOrDefault();
    }

    private static IEnumerable<Tree<int>> GetDeepestNode(Tree<int> node)
    {
        var target = int.Parse(Console.ReadLine());
        Console.WriteLine($"Subtrees of sum {target}:");

        var leafs = new List<Tree<int>>();

        var sum = DFS(node, target, 0, leafs);

        return leafs;
    }

    private static int DFS(Tree<int> node, int targetSum, int currentSum, List<Tree<int>> leafs)
    {
        if (node == null)
        {
            return 0;
        }

        currentSum = node.Value;
       

        foreach (var child in node.Children)
        {
          currentSum +=  DFS(child, targetSum, currentSum, leafs);
        }

        if (currentSum == targetSum)
        {
            leafs.Add(node);
        }

        return currentSum;
    }
}

