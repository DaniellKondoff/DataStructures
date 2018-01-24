using System;

namespace TreesHW
{
    public class Node<T> where T : IComparable<T>
    {
        public Node(T value)
        {
            this.Value = value;
            this.Count = 1;
        }

        public T Value { get; set; }

        public Node<T> LeftChild { get; set; }

        public Node<T> RightChild { get; set; }

        public int Count { get; set; }
    }
}
