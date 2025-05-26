using System;
using System.Linq;

class Program
{
    static void Main()
    {
        Console.WriteLine("Введите числа через пробел:");
        var unique = Console.ReadLine()
            .Split(' ')
            .Distinct();

        Console.WriteLine("Без дубликатов: " + string.Join(" ", unique));
    }
}
