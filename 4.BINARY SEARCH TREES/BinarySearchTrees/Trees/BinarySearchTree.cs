using System;
using System.Collections.Generic;

public class BinarySearchTree<T> : IBanarySearchTree<T> where T:IComparable
{
    private class Node
    {
        public T Value { get; set; }

        public Node Left { get; set; }

        public Node Right { get; set; }

        public int ChildrenCount { get; set; }

        public Node(T value)
        {
            this.Value = value;
            this.ChildrenCount = 1;
        }
    }

    private Node root;

    public int NodesCount { get; set; }

    public BinarySearchTree()
    {

    }

    private BinarySearchTree(Node node)
    {
        this.Copy(node);
    }

    private void Copy(Node node)
    {
        if (node == null)
        {
            return;
        }

        this.Insert(node.Value);
        this.Copy(node.Left);
        this.Copy(node.Right);
    }

    public void Insert(T element)
    {
        this.NodesCount++;
        if (this.root == null)
        {
            this.root = new Node(element);
            return;
        }

        Node parent = null;
        Node current = this.root;

        while (current != null)
        {
            parent = current;

            if (current.Value.CompareTo(element) > 0)
            {
                parent.ChildrenCount++;
                current = current.Left;
            }
            else if (current.Value.CompareTo(element) < 0)
            {
                parent.ChildrenCount++;
                current = current.Right;
            }
            else
            {
                this.NodesCount--;
                return;
            }
        }

        current = new Node(element);
        if (parent.Value.CompareTo(element) < 0)
        {
            parent.Right = current;
        }
        else
        {
            parent.Left = current;
        }

    }

    public bool Contains(T element)
    {
        Node current = FindEelement(element);

        return current != null;
    }

    public IEnumerable<T> Range(T startRange, T endRange)
    {
        Queue<T> range = new Queue<T>();
        this.Range(startRange, endRange, range, this.root);

        return range;
    }

    private void Range(T startRange, T endRange, Queue<T> range, Node node)
    {
        if (node == null)
        {
            return;
        }

        int compareLow = startRange.CompareTo(node.Value);
        int compareHigh = endRange.CompareTo(node.Value);

        if (compareLow < 0)
        {
            this.Range(startRange, endRange, range, node.Left);
        }

        if (compareLow <= 0 && compareHigh >= 0)
        {
            range.Enqueue(node.Value);
        }
        if (compareHigh > 0)
        {
            this.Range(startRange, endRange, range, node.Right);
        }
    }

    public BinarySearchTree<T> Search(T element)
    {
        Node current = FindEelement(element);

        if (current == null)
        {
            return null;
        }

        return new BinarySearchTree<T>(current);
    }

    public void DeleteMin()
    {
        if (this.root == null)
        {
            return;
        }

        Node current = this.root;
        Node parrent = null;

        while (current.Left != null)
        {
            parrent = current;
            current = current.Left;
        }

        if (parrent == null)
        {
            this.root = this.root.Right;
        }
        else
        {
            parrent.Left = current.Right;
        }

        this.NodesCount--;
    }

    public void DeleteMax()
    {
        if (this.root == null)
        {
            return;
        }

        Node current = this.root;
        Node parrent = null;

        while (current.Right != null)
        {
            parrent = current;
            current = current.Right;
        }

        if (parrent == null)
        {
            this.root = this.root.Left;
        }
        else
        {
            parrent.Right = current.Left;
        }

        this.NodesCount--;
    }

    public void EachInOrder(Action<T> action)
    {
        this.EachInOrder(this.root, action);
    }

    private void EachInOrder(Node node, Action<T> action)
    {
        if (node == null)
        {
            return;
        }

        this.EachInOrder(node.Left, action);
        action(node.Value);
        this.EachInOrder(node.Right, action);
    }

    private Node FindEelement(T element)
    {
        Node current = this.root;

        while (current != null)
        {
            if (current.Value.CompareTo(element) > 0)
            {
                current = current.Left;
            }
            else if (current.Value.CompareTo(element) < 0)
            {
                current = current.Right;
            }
            else
            {
                break;
            }
        }

        return current;
    }

    public void Delete(T element)
    {
        throw new NotImplementedException();
    }

    public int Count()
    {
        return this.NodesCount;
    }

    public int Rank(T element)
    {
        int rank = this.Rank(element, this.root);

        return rank;
    }

    private int Rank(T element, Node node)
    {
        if (node == null)
        {
            return 0;
        }

        int compare = element.CompareTo(node.Value);

        if (compare < 0)
        {
            return this.Rank(element, node.Left);
        }

        if (compare > 0)
        {
            return 1 + this.GetChildrenCOunt(node.Left) + this.Rank(element, node.Right);
        }


        return this.GetChildrenCOunt(node.Left);
    }

    private int GetChildrenCOunt(Node node)
    {
        if (node == null)
        {
            return 0;
        }

        return node.ChildrenCount;
    }

    public T Select(int rank)
    {
        throw new NotImplementedException();
    }

    public T Ceiling(T element)
    {
        throw new NotImplementedException();
    }

    public T Floor(T element)
    {
        throw new NotImplementedException();
    }
}

