using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TreesHW
{
    public class BST<T> where T : IComparable<T>
    {
        private Node<T> root;

        public void Insert(T item)
        {
            this.root = this.InsertRecursive(this.root, item);
        }

        private Node<T> InsertRecursive(Node<T> node, T item)
        {
            if (node == null)
            {
                return new Node<T>(item);
            }

            int comparer = item.CompareTo(node.Value);

            if (comparer < 0)
            {
                node.LeftChild = InsertRecursive(node.LeftChild, item);
            }
            else if (comparer > 0)
            {
                node.RightChild = InsertRecursive(node.RightChild, item);
            }

            node.Count = Count(node.LeftChild) + Count(node.RightChild) + 1;

            return node;
        }

        private int Count(Node<T> node)
        {
            if (node == null)
            {
                return 0;
            }

            return node.Count;
        }

        public void DeleteMin()
        {
            this.root = DeleteMin(this.root);
        }

        private Node<T> DeleteMin(Node<T> node)
        {
            if (node == null)
            {
                return null;
            }

            if (node.LeftChild == null)
            {
                return node.RightChild;
            }

            node.LeftChild = DeleteMin(node.LeftChild);
            node.Count = Count(node.LeftChild) + Count(node.RightChild) + 1;
            return node;
        }
    }
}
