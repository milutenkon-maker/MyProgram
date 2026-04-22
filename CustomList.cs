using System;
using System.Collections;
using System.Collections.Generic;

/// <summary>
/// Вузол однозв'язного списку.
/// </summary>
/// <typeparam name="T">Тип даних, що зберігаються у вузлі.</typeparam>
public class Node<T>
{
    /// <summary> Дані, що зберігаються у вузлі. </summary>
    public T Data;
    /// <summary> Посилання на наступний вузол. </summary>
    public Node<T> Next;

    /// <summary>
    /// Конструктор вузла.
    /// </summary>
    /// <param name="data">Значення елемента.</param>
    public Node(T data)
    {
        Data = data;
        Next = null;
    }
}

/// <summary>
/// Власна структура даних: Однозв'язний список.
/// </summary>
/// <typeparam name="T">Тип елементів списку.</typeparam>
public class CustomList<T> : IEnumerable<T>
{
    private Node<T> _head;
    private int _count;

    /// <summary> Кількість елементів у списку. </summary>
    public int Count => _count;

    /// <summary>
    /// Додавання елемента в кінець списку.
    /// </summary>
    /// <param name="value">Значення для додавання.</param>
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

    /// <summary>
    /// Індексатор для доступу до елементів на читання.
    /// </summary>
    /// <param name="index">Індекс елемента.</param>
    /// <returns>Значення елемента.</returns>
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

    /// <summary>
    /// Видалення елемента за номером (позицією).
    /// </summary>
    /// <param name="index">Індекс елемента (починаючи з 0).</param>
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

    /// <summary>
    /// 1. Знайти перше входження заданого символу.
    /// </summary>
    /// <param name="value">Символ для пошуку.</param>
    /// <returns>Індекс або -1, якщо не знайдено.</returns>
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

    /// <summary>
    /// 2. Знайти суму елементів на парних позиціях.
    /// Позиції рахуються як 1, 2, 3... (2, 4, 6 - парні).
    /// </summary>
    /// <returns>Сума цілих значень.</returns>
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

    /// <summary>
    /// 3. Отримати новий список зі значень після заданого символу.
    /// </summary>
    /// <param name="value">Символ-роздільник.</param>
    /// <returns>Новий CustomList.</returns>
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

    /// <summary>
    /// 4. Видалити елементи поточного списку після заданого символу.
    /// Якщо символів декілька, видаляє після першого входження (згідно з логікою завдання).
    /// </summary>
    /// <param name="value">Символ-маркер.</param>
    public void RemoveAfter(T value)
    {
        Node<T> current = _head;
        while (current != null)
        {
            if (current.Data.Equals(value))
            {
                current.Next = null;
                // Оновлюємо лічильник Count (спрощено)
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

    /// <summary> Реалізація IEnumerable для foreach. </summary>
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