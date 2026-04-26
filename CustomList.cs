using System;
using System.Collections;
using System.Collections.Generic;

public class Node<T>
{
    public T Data;
    public Node<T> Next;

    public Node(T data)
    {
        Data = data;
        Next = null;
    }
}

public class CustomList<T> : IEnumerable<T>
{
    private Node<T> _head;
    private int _count;

    public int Count => _count;

    public void Add(T value)
    {
        if (_head == null)
        {
            _head = new Node<T>(value);
        }
        else
        {
            Node<T> current = _head;
            while (current.Next != null)
                current = current.Next;
            current.Next = new Node<T>(value);
        }
        _count++;
    }

    public T this[int index]
    {
        get
        {
            if (index < 0 || index >= _count)
                throw new IndexOutOfRangeException("Індекс поза межами списку.");

            Node<T> current = _head;
            for (int i = 0; i < index; i++)
                current = current.Next;

            return current.Data;
        }
    }

    public void RemoveAt(int index)
    {
        if (index < 0 || index >= _count || _head == null) return;

        if (index == 0)
        {
            _head = _head.Next;
        }
        else
        {
            Node<T> current = _head;
            for (int i = 0; i < index - 1; i++)
                current = current.Next;

            if (current.Next != null)
                current.Next = current.Next.Next;
        }
        _count--;
    }

    public int FindFirst(T value)
    {
        Node<T> current = _head;
        int index = 0;
        while (current != null)
        {
            if (current.Data.Equals(value)) return index;
            current = current.Next;
            index++;
        }
        return -1;
    }

    public int SumEvenPositions()
    {
        int sum = 0;
        int position = 1;
        Node<T> current = _head;
        while (current != null)
        {
            if (position % 2 == 0)
            {
                if (int.TryParse(current.Data.ToString(), out int num))
                    sum += num;
            }
            current = current.Next;
            position++;
        }
        return sum;
    }

    public CustomList<T> GetAfter(T value)
    {
        CustomList<T> newList = new CustomList<T>();
        Node<T> current = _head;
        bool found = false;

        while (current != null)
        {
            if (found) newList.Add(current.Data);
            if (current.Data.Equals(value) && !found) found = true;
            current = current.Next;
        }
        return newList;
    }

    public void RemoveAfter(T value)
    {
        Node<T> current = _head;
        while (current != null)
        {
            if (current.Data.Equals(value))
            {
                current.Next = null;
                UpdateCount();
                return;
            }
            current = current.Next;
        }
    }

    private void UpdateCount()
    {
        _count = 0;
        Node<T> current = _head;
        while (current != null) { _count++; current = current.Next; }
    }

    public IEnumerator<T> GetEnumerator()
    {
        Node<T> current = _head;
        while (current != null)
        {
            yield return current.Data;
            current = current.Next;
        }
    }

    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
}
