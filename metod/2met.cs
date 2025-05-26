using System;

class Program
{
    static void Main()
    {
        Console.WriteLine("Введите строку:");
        string text = Console.ReadLine();
        string reversed = new string(text.Reverse().ToArray());

        if (text == reversed)
            Console.WriteLine("Это палиндром.");
        else
            Console.WriteLine("Это не палиндром.");
    }
}
