using System;

public class BinarySearchTree<T> where T : IComparable
{
    private class Node
    {
        public T Value { get; set; }

        public Node Left { get; set; }

        public Node Right { get; set; }

        public Node(T value)
        {
            this.Value = value;
        }
    }

    private Node root;

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
                current = current.Left;
            }
            else if (current.Value.CompareTo(element) < 0)
            {
                current = current.Right;
            }
            else
            {
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
}

