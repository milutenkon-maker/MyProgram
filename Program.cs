using System;

class Program
{
    static void Main()
    {
        char target = '*';
        
        CustomList<char> list = new CustomList<char>();
        char[] data = { '5', '2', '*', '9', '4', '*', '1' };
        foreach (char c in data) list.Add(c);

        Console.WriteLine("Початковий список:");
        PrintList(list);

        int index = list.FindFirst(target);
        Console.WriteLine($"\n1. Перше входження '{target}' на позиції: {(index != -1 ? (index + 1).ToString() : "не знайдено")}");

        int sum = list.SumEvenPositions();
        Console.WriteLine($"2. Сума елементів на парних позиціях: {sum}");

        CustomList<char> newList = list.GetAfter(target);
        Console.Write($"3. Новий список після '{target}': ");
        PrintList(newList);

        list.RemoveAfter(target);
        Console.WriteLine($"4. Список після видалення елементів після '{target}':");
        PrintList(list);
    }

    static void PrintList(CustomList<char> l)
    {
        foreach (var item in l) Console.Write(item + " ");
        Console.WriteLine();
    }
}
