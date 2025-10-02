using System.Diagnostics.CodeAnalysis;

internal class Program
{
    private static void Main(string[] args)
    {
        int a, b, c, suma1, suma2, suma3;
        Console.WriteLine("Ingrese el lado A");
        a = Int16.Parse(Console.ReadLine());

        Console.WriteLine("Ingrese el lado B");
        b = Int16.Parse(Console.ReadLine());

        Console.WriteLine("Ingrese el lado C");
        c = Int16.Parse(Console.ReadLine());

        suma1 = a + b;
        suma2 = a + c;
        suma3 = b + c;

        if (suma1 > c && suma2 > b && suma3 > a)
        {

            if (a == b && b == c)
            {
                Console.WriteLine("Es un triángulo equilátero");
            }
            else if (a == b || a == c || b == c)
            {
                Console.WriteLine("Es un triángulo isósceles");
            }
            else
            {
                Console.WriteLine("Es un triángulo escaleno");
            }
        }
        else
        {
            Console.WriteLine("No es un triángulo");
        }
    }
}