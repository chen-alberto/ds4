using System;
class Program
{
    static void Main()
    {
        Console.Write("Ingrese el tamaño n de la matriz: ");
        int n = int.Parse(Console.ReadLine());
        int[,] matriz = new int[n, n];
        Random random = new Random();
        int suma = 0;
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < n; j++)
            {
                if (n % 2 == 0 && 
                    (i == n / 2 - 1 || i == n / 2) &&
                    (j != 0 && j != n - 1)) 
                {
                    matriz[i, j] = random.Next(101, 200);
                }
                else
                {
                    matriz[i, j] = 0;
                }
                suma += matriz[i, j];
                Console.Write(matriz[i, j] + "\t");
            }
            Console.WriteLine();
        }
    }
}

