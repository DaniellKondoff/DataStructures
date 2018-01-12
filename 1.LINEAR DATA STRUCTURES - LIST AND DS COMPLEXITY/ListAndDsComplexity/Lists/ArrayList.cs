using System;

public class ArrayList<T>
{
    private T[] arr;
    private const int InitialCapacity = 2;

    public ArrayList()
    {
        this.arr = new T[InitialCapacity];
    }

    public int Count { get; set; }

    public T this[int index]
    {
        get
        {
            if (index < 0 || index >= this.Count)
            {
                throw new ArgumentOutOfRangeException("Out of Range");
            }

            return this.arr[index];
        }

        set
        {
            if (index < 0 || index >= this.Count)
            {
                throw new ArgumentOutOfRangeException("Out Of Range");
            }

            this.arr[index] = value;
        }
    }

    public void Add(T item)
    {
        if (this.arr.Length == this.Count)
        {
            this.Resize();
        }

        this.arr[this.Count] = item;
        this.Count++;
    }

    public T RemoveAt(int index)
    {
        T item = this[index];
        this[index] = default(T);
        this.ShiftLeft(index);

        if (this.Count  < this.arr.Length / 4)
        {
            this.Shrink();
        }
        this.Count--;

        return item;
    }

    private void Shrink()
    {
        T[] newArr = new T[this.arr.Length / 2];
        Array.Copy(this.arr, newArr, this.Count);

        this.arr = newArr;
    }

    private void ShiftLeft(int index)
    {
        for (int i = index; i < this.Count - 1; i++)
        {
            this.arr[i] = this.arr[i + 1];
        }
    }

    private void Resize()
    {
        T[] newArr = new T[this.arr.Length * 2];
        Array.Copy(this.arr, newArr, this.Count);

        this.arr = newArr;
    }
}
