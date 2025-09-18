using System;

namespace Laboratorio_31
{
    public class CalculosMatematicos
    {
        public static int Calcular(int a, int b)
        {
            return (a + b) * (a - b);
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Ingrese el primer número: ");
            int a = Convert.ToInt32(Console.ReadLine());

            Console.Write("Ingrese el segundo número: ");
            int b = Convert.ToInt32(Console.ReadLine());

            int resultado = CalculosMatematicos.Calcular(a, b);
            Console.WriteLine("Resultado de (a + b) * (a - b) = {0}", resultado);
        }
    }
}
