using System;

class Program
{
    static void Main()
    {
        Console.WriteLine("Введите число:");
        int n = int.Parse(Console.ReadLine());
        long result = 1;

        for (int i = 1; i <= n; i++)
            result *= i;

        Console.WriteLine($"Факториал: {result}");
    }
}
