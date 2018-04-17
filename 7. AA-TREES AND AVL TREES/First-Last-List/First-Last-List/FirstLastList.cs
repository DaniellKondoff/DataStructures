using System;
using System.Collections.Generic;
using System.Linq;
using Wintellect.PowerCollections;

public class FirstLastList<T> : IFirstLastList<T> where T : IComparable<T>
{
    private LinkedList<T> byInsertion = new LinkedList<T>();
    private OrderedBag<LinkedListNode<T>> byOrderSorted = new OrderedBag<LinkedListNode<T>>((x,y) => x.Value.CompareTo(y.Value));
    private OrderedBag<LinkedListNode<T>> byOrderReversed = new OrderedBag<LinkedListNode<T>>((x,y) => - x.Value.CompareTo(y.Value));

    public int Count
    {
        get
        {
            return this.byInsertion.Count;
        }
    }

    public void Add(T element)
    {
        var node = new LinkedListNode<T>(element);

        byInsertion.AddLast(node);
        byOrderSorted.Add(node);
        byOrderReversed.Add(node);
    }

    public void Clear()
    {
        byInsertion.Clear();
        byOrderSorted.Clear();
        byOrderReversed.Clear();
    }

    public IEnumerable<T> First(int count)
    {
        this.ValidateCount(count);

        return this.byInsertion.Take(count).ToList();
    }

    public IEnumerable<T> Last(int count)
    {
        this.ValidateCount(count);

        return this.byInsertion.Reverse().Take(count).ToList();
    }

    public IEnumerable<T> Max(int count)
    {
        this.ValidateCount(count);

        return this.byOrderReversed.Take(count).Select(x=>x.Value).ToList();
    }

    public IEnumerable<T> Min(int count)
    {
        this.ValidateCount(count);

        return this.byOrderSorted.Take(count).Select(x=>x.Value).ToList();
    }

    public int RemoveAll(T element)
    {
        var node = new LinkedListNode<T>(element);
        var forDeleteRange =  byOrderSorted.Range(node,true,node,true);


        foreach (var item in forDeleteRange)
        {
            byInsertion.Remove(item);
        }

        int count = byOrderSorted.RemoveAllCopies(node);
        byOrderReversed.RemoveAllCopies(node);

        return count;
    }

    private void ValidateCount(int count)
    {
        if (count > this.Count)
        {
            throw new ArgumentOutOfRangeException();
        }
    }
}
