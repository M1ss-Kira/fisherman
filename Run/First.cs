using System;
using System.Numerics;

public class BigAdder
{
    public static void Main(string[] args)
    {
        string[] input = Console.ReadLine().Split(' ');

        BigInteger a = BigInteger.Parse(input[0]);
        BigInteger b = BigInteger.Parse(input[1]);

        Console.WriteLine(a + b);
    }
}
