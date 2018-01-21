using System;
using System.Collections.Generic;
using System.Linq;

public class Program
{
    static Dictionary<int, Tree<int>> nodes = new Dictionary<int, Tree<int>>();

    static void Main(string[] args)
    {
        ReadTree();

        Tree<int> root = GetRoot();

        //root.Print();

        //3 LeafNodes
        //var leafs = GetLeafsOrdered();
        //Console.WriteLine("Leaf nodes: " + string.Join(" ",leafs));

        //4 MiddleNodes
        //var middleNodes = GetMiddleNodesOrdered();
        //Console.WriteLine("Middle nodes: " + string.Join(" ", middleNodes));

        //5 Deepest Node
        //var deepestNodes = GetDeepestNode(root);
        //Console.WriteLine(deepestNodes.Value);

        //Console.WriteLine(GetDeepestNodeDFS(root).Value);

        ////6 LongestPath
        //var longestPath = GetLongestPathDFS(root);
        //Console.WriteLine("Longest path: " + string.Join(" ", longestPath));

        //7 AllPathsWithGivenSum
        //foreach (var leaf in GetPathWithSum(root))
        //{
        //    PrintAllSumPath(leaf);
        //}

        //8 AllSubtreeWithGivenSum
        foreach (var node in GetSubTreeWithSum(root))
        {
            PrintPreOrder(node);
            Console.WriteLine();

        }
    }

    private static void PrintPreOrder(Tree<int> node)
    {
        Console.Write(node.Value +" ");

        foreach (var child in node.Children)
        {
            PrintPreOrder(child);
        }
    }

    private static void PrintAllSumPath(Tree<int> leaf)
    {
        var stack = new Stack<int>();
        var current = leaf;

        while (current != null)
        {
            stack.Push(current.Value);
            current = current.Parent;
        }

        Console.WriteLine(string.Join(" ", stack.ToArray()));
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

    private static Tree<int> GetRoot()
    {
        return nodes.Values.Where(x => x.Parent == null).FirstOrDefault();
    }

    private static int[] GetLeafsOrdered()
    {
        return nodes.Values.Where(x => x.Children.Count == 0).Select(x => x.Value).OrderBy(x => x).ToArray();
    }

    private static int[] GetMiddleNodesOrdered()
    {
        return nodes.Values.Where(x => x.Children.Count > 0 && x.Parent != null).Select(x=>x.Value).OrderBy(x => x).ToArray();
    }

    private static Tree<int> GetNode(int value)
    {
        if (!nodes.ContainsKey(value))
        {
            nodes[value] = new Tree<int>(value);
        }

        return nodes[value];
    }

    private static Tree<int> GetDeepestNode(Tree<int> root)
    {
        var queue = new Queue<Tree<int>>();
        queue.Enqueue(root);

        Tree<int> current = null;

        while (queue.Count > 0)
        {
            current = queue.Dequeue();

            current.Children.Reverse();
            foreach (var child in current.Children)
            {
                queue.Enqueue(child);
            }
        }

        return current;
    }

    private static Tree<int> GetDeepestNodeDFS(Tree<int> root)
    {
        int maxLevel = 0;
        Tree<int> deepest = null;
        DFS(root, 1, ref maxLevel,ref deepest);

        return deepest;
    }

    private static void DFS(Tree<int> node, int level, ref int maxLevel, ref Tree<int> deepest)
    {
        if (node == null)
        {
            return;
        }

        if (level > maxLevel)
        {
            deepest = node;
            maxLevel = level;
        }

        foreach (var child in node.Children)
        {
            DFS(child, level + 1, ref maxLevel, ref deepest);
        }
    }

    private static IEnumerable<int> GetLongestPathDFS(Tree<int> root)
    {
        int maxLevel = 0;
        List<int> longestPath = new List<int>();
        LognestPathDFS(root, 1, ref maxLevel, longestPath);

        return longestPath;
    }

    private static void LognestPathDFS(Tree<int> node, int level, ref int maxLevel,  List<int> longestPath)
    {
        if (node == null)
        {
            return;
        }

        if (level > maxLevel)
        {
            longestPath.Add(node.Value);
            maxLevel = level;
        }

        foreach (var child in node.Children)
        {
            LognestPathDFS(child, level + 1, ref maxLevel, longestPath);
        }
    }

    private static IEnumerable<Tree<int>> GetPathWithSum(Tree<int> root)
    {
        var target = int.Parse(Console.ReadLine());
        Console.WriteLine($"Path of sum {target}:");

        var leafs = new List<Tree<int>>();

        DFSAllPathSum(root, target, 0, leafs);

        return leafs;
    }

    private static void DFSAllPathSum(Tree<int> node, int targetSum, int currentSum, List<Tree<int>> leafs)
    {
        if (node == null)
        {
            return;
        }

        currentSum += node.Value;

        if (currentSum == targetSum && node.Children.Count == 0)
        {
            leafs.Add(node);
        }

        foreach (var child in node.Children)
        {
            DFSAllPathSum(child, targetSum, currentSum, leafs);
        }
    }

    private static IEnumerable<Tree<int>> GetSubTreeWithSum(Tree<int> root)
    {
        var target = int.Parse(Console.ReadLine());
        Console.WriteLine($"Subtrees of sum {target}:");

        var roots = new List<Tree<int>>();

        var sum = DFSAllSubtreeSum(root, target, 0, roots);

        return roots;
    }

    private static int DFSAllSubtreeSum(Tree<int> node, int targetSum, int currentSum, List<Tree<int>> roots)
    {
        if (node == null)
        {
            return 0;
        }
        currentSum = node.Value;

        foreach (var child in node.Children)
        {
          currentSum+= DFSAllSubtreeSum(child, targetSum, currentSum, roots);
        }

        if (currentSum == targetSum)
        {
            roots.Add(node);
        }

        return currentSum;
    }

}

