using System;

namespace Laboratorio_2
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Client client = new Client();
            client.FirstName = "Su Nombre";
            client.LastName = "Su Apellido";
            client.Age = 15;
            client.id = 1;

            Console.WriteLine(client.GetFullName());    
        }
    }
    public class Client
    {
        //Declarando variables de instancia de clase
        public int id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public ushort Age { get; set; }

        public string GetFullName()
        {
            //Utilizando variables de instancia dentro de metodos de clase
            return FirstName + " " + LastName;
        }
    }
}