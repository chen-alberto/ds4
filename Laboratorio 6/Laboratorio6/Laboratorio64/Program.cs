using System;

internal class Program
{
    static void checkAge(int age)
    {
        if (age < 18)
        {
            throw new ArithmeticException("Acceso negado - no cumple con el criterio de edad");
        }
        else
        {
            Console.WriteLine("acceso concedido");
        }
    }
    static void Main(string[] args)
    {
        checkAge(15);
    }
}