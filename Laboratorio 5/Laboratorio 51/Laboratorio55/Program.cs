using System;

internal class Program
{
    private static void Main(string[] args)
    {
     List<Estudiante> estudiantes = new List<Estudiante>
        {
        new Estudiante { Nombre = "Ana", Edad = 12 },
        new Estudiante { Nombre = "Juan", Edad = 10 },
        new Estudiante { Nombre = "Sofia", Edad = 11 }
        };

    foreach (Estudiante estudiante in estudiantes)
        {
            Console.WriteLine("nombre: " + estudiante.Nombre + ", edad: " + estudiante.Edad);
        }

    }


    class Estudiante
    {
        public string Nombre { get; set; }
        public int Edad { get; set; }
    }
}