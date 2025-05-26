using System;

internal class Program
{
    static void Main(string[] args)
    {
        double x, y;
        Console.WriteLine("Введите 1 число: ");
        x = Convert.ToDouble(Console.ReadLine());
        Console.WriteLine("Введите 2 число: ");
        y = Convert.ToDouble(Console.ReadLine());

        Console.WriteLine("Выбери что хоч: +, -, *, /, %, ++, --");
        string operation = Console.ReadLine();

        switch (operation)
        {
            case "+":
                Console.WriteLine($"{x} + {y} = {x + y}");
                break;
            case "-":
                Console.WriteLine($"{x} - {y} = {x - y}");
                break;
            case "*":
                Console.WriteLine($"{x} * {y} = {x * y}");
                break;
            case "/":
                if (y != 0)
                {
                    Console.WriteLine($"{x} / {y} = {x / y}");
                }
                else
                {
                    Console.WriteLine("сэр, вообще-то это не место для деления на ноль");
                }
                break;
            case "%":
                Console.WriteLine($"{x} % {y} = {x % y}");
                break;
            case "++":
                Console.WriteLine($"Инкремент {x} = {++x}");
                break;
            case "--":
                Console.WriteLine($"Декремент {x} = {--x}");
                break;
            default:
                Console.WriteLine("та я ваще хз");
                break;
        }
    }
}
