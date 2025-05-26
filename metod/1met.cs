using System;
using System.Linq;

class Program
{
    static void Main()
    {
        Console.WriteLine("Введите числа через пробел:");
        int sum = Console.ReadLine()
            .Split(' ')
            .Select(int.Parse)
            .Sum();
        Console.WriteLine($"Сумма: {sum}");
    }
}
