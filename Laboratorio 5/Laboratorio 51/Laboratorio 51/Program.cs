using System;

class Program
{
    // Declaramos un vector para 5 sueldos
    private int[] sueldos;

    // Cargar los sueldos
    public void Cargar()
    {
        sueldos = new int[5];   // Vector de 5 elementos

        for (int i = 0; i < 5; i++)   // índices de 0 a 4
        {
            Console.Write("Ingrese sueldo del operario {0}: ", i + 1);
            string linea = Console.ReadLine();
            sueldos[i] = int.Parse(linea);
        }
    }

    // Imprimir los sueldos
    public void Imprimir()
    {
        Console.WriteLine("\nLos 5 sueldos de los operarios son:");
        for (int i = 0; i < 5; i++)
        {
            Console.Write("[{0}] ", sueldos[i]);
        }
        Console.ReadKey();
    }

    // Método principal
    static void Main(string[] args)
    {
        Program pv = new Program();
        pv.Cargar();
        pv.Imprimir();
    }
}
