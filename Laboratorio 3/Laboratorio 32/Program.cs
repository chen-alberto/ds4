using System;

namespace Laboratorio_32
{
    public class CalculosMatematicos
    {
        public static double CalculoArea(double radio)
        {
            const double PI = 3.1416;  
            return PI * radio * radio;
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Ingrese el radio del círculo: ");
            double radio = Convert.ToDouble(Console.ReadLine());

            double area = CalculosMatematicos.CalculoArea(radio);
            Console.WriteLine("Área del círculo = {0}", area);
        }
    }
}
