using System;

class Program
{
    static void Main()
    {
        // Символ, який ми шукаємо (згідно з варіантом)
        char target = '*';

        // Створюємо список і заповнюємо його (цифри та дві зірочки)
        CustomList<char> list = new CustomList<char>();
        char[] data = { '5', '2', '*', '9', '4', '*', '1' };
        foreach (char c in data) list.Add(c);

        Console.WriteLine("Початковий список:");
        PrintList(list);

        // 1. Знайти перше входження символу «*»
        int index = list.FindFirst(target);
        Console.WriteLine($"\n1. Перше входження '{target}' на позиції: {(index != -1 ? (index + 1).ToString() : "не знайдено")}");

        // 2. Знайти суму елементів на парних позиціях
        int sum = list.SumEvenPositions();
        Console.WriteLine($"2. Сума елементів на парних позиціях: {sum}");

        // 3. Отримати новий список зі значень після символу «*»
        CustomList<char> newList = list.GetAfter(target);
        Console.Write($"3. Новий список після '{target}': ");
        PrintList(newList);

        // 4. Видалити елементи поточного списку після символу «*»
        list.RemoveAfter(target);
        Console.WriteLine($"4. Список після видалення елементів після '{target}':");
        PrintList(list);
    }

    // Метод для зручного виводу (використання списку)
    static void PrintList(CustomList<char> l)
    {
        foreach (var item in l) Console.Write(item + " ");
        Console.WriteLine();
    }
}