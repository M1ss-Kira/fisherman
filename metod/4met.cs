using System;
using System.Linq;

class Program
{
    static void Main()
    {
        Console.WriteLine("Введите числа через пробел:");
        int max = Console.ReadLine()
            .Split(' ')
            .Select(int.Parse)
            .Max();

        Console.WriteLine($"Максимум: {max}");
    }
}
