using System;

internal class Program
{
    private static void Main(string[] args)
    {
        Dictionary<string, string> paisesyCapitales = new Dictionary<string, string>
        {
            {"Francia","Paris" },
            {"Espana","Madrid" },
            {"Italia","Roma" }
        };
        foreach (KeyValuePair<string, string> par in paisesyCapitales)
        {
            Console.WriteLine("La capital de " + par.Key + " es " + par.Value + ".");
        }
    }
}