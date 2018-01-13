using System;

namespace NodeDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            Node<int> head = new Node<int>(2);
            Node<int> next = new Node<int>(10);

            head.Next = next;

        }
    }
}
