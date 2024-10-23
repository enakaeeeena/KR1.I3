using System;

class Program
{
    static void Main()
    {
        Console.Write("Введите действительное число: ");
        int x = Convert.ToInt32(Console.ReadLine());

        double rez = x - Math.Pow(x, 3) / Factorial(3) + Math.Pow(x, 5) / Factorial(5) - Math.Pow(x, 7) / Factorial(7) + Math.Pow(x, 9) / Factorial(9) - Math.Pow(x, 11) / Factorial(11) + Math.Pow(x, 13) / Factorial(13);

        Console.WriteLine(rez);
    }

    static double Factorial(int n)
    {
        double result = 1;
        for (int i = 2; i <= n; i++)
        {
            result *= i;
        }
        return result;
    }
}