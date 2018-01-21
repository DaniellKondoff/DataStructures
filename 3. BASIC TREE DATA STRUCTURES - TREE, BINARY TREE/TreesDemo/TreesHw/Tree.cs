using System;
using System.Collections.Generic;

public class Tree<T>
{
    public T Value { get; set; }

    public Tree<T> Parent { get; set; }

    public List<Tree<T>> Children { get; set; }

    public Tree(T value, params Tree<T>[] children)
    {
        this.Value = value;
        this.Children = new List<Tree<T>>(children);
    }

    public void Print(int indentation = 0)
    {
        Console.WriteLine(new string(' ', indentation) + this.Value);
        this.Children.ForEach(c => c.Print(indentation + 2));
    }

    public IEnumerable<T> OrderDFS()
    {
        var result = new List<T>();

        this.DFS(this, result);

        return result;
    }

    private void DFS(Tree<T> tree, List<T> result)
    {
        foreach (var child in tree.Children)
        {
            this.DFS(child, result);
        }

        result.Add(tree.Value);
    }

    public IEnumerable<T> OrderDFSWithStack()
    {
        var result = new Stack<T>();
        var stack = new Stack<Tree<T>>();
        stack.Push(this);

        while (stack.Count > 0)
        {
            var current = stack.Pop();
            foreach (var child in current.Children)
            {
                stack.Push(child);
            }

            result.Push(current.Value);
        }

        return result.ToArray();
    }

    public IEnumerable<T> OrderBFS()
    {
        var result = new List<T>();
        var queue = new Queue<Tree<T>>();

        queue.Enqueue(this);

        while (queue.Count > 0)
        {
            var current = queue.Dequeue();

            foreach (var child in current.Children)
            {
                queue.Enqueue(child);
            }

            result.Add(current.Value);
        }

        return result;
    }

    public override string ToString()
    {
        return this.Value.ToString();
    }
}
