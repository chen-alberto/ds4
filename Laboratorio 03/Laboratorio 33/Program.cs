using System;

namespace Laboratorio_33
{
    public class CalculosMatematicos
    {
        public static double PerimetroRectangulo(double lado1, double lado2)
        {
            return 2 * (lado1 + lado2);
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Ingrese el lado 1 del rectángulo: ");
            double lado1 = Convert.ToDouble(Console.ReadLine());

            Console.Write("Ingrese el lado 2 del rectángulo: ");
            double lado2 = Convert.ToDouble(Console.ReadLine());

            double perimetro = CalculosMatematicos.PerimetroRectangulo(lado1, lado2);
            Console.WriteLine("Perímetro del rectángulo = {0}",perimetro);
        }
    }
}
