using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laboratorio_94
{
    public class Aleatorios    
    {
        int min, max;
        public int Valor { get; set; }
        public static Random random = new Random();

        public Aleatorios()
        {
            Valor = random.Next();
        }

        public void GenerarRandom()
        {
            Console.WriteLine("Ingrese el rango minimo del numero generado");
            min = Int32.Parse(Console.ReadLine());

            Console.WriteLine("Ingrese el rango maximo del numero generado");
            max = Int32.Parse(Console.ReadLine());

            Valor = random.Next(min, max);
            Console.WriteLine(Valor);
        }

        public void GenerarArregloRandom()
        {
            Console.WriteLine("Eliga el tamano del arreglo");
            int tam = Int32.Parse(Console.ReadLine());
            int[] numeros = new int[tam];
            for (int i = 0; i < numeros.Length; i++)
            {
                numeros[i] = random.Next(1, 101); 
            }
            Console.WriteLine("Números aleatorios generados:");
            foreach (int numero in numeros)
            {
                Console.WriteLine(numero);
            }
        }
    }
}
