using System;

internal class Program
{
    private static void Main(string[] args)
    {
        int num, pago;
        string tarjeta;

        try
        {

            Console.WriteLine("Bienvenido al sistema de cobro automatico, Ingrese el monto a pagar o presione 0 si desea salir");

            while (true)
            {
                num = Int16.Parse(Console.ReadLine());

                if (num > 0)
                {
                    Console.WriteLine("Elige un metodo de pago:\n 1 = Para efectivo\n 2 = Para Tarjeta\n");
                    pago = Int16.Parse(Console.ReadLine());
                    if (pago == 1)
                    {
                        Console.WriteLine("Gracias por su pago vuelva pronto");
                        break;
                    }
                    else if (pago == 2)
                    {
                        Console.WriteLine("Ingrese su numero de tarjeta");
                        tarjeta = Console.ReadLine();
                        if (tarjeta.Length == 16)
                        {
                            Console.WriteLine("Gracias por su pago vuelva pronto");
                            break;
                        }
                        else
                        {
                            Console.WriteLine("Error: El numero de tarjeta debe tener 16 digitos, intente de nuevo");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Error: Metodo de pago no valido, intente de nuevo");
                    }
                }
                else if (num == 0)
                {
                    Console.WriteLine("Gracias por usar el sistema de cobro automatico, hasta luego");
                    break;
                }
                else
                {
                    Console.WriteLine("Error: El monto a pagar no puede ser negativo, intente de nuevo");
                }
            }
        }
        catch (Exception e)
        {
            Console.WriteLine("Eligio un numero invalido para procesar su consulta");


        }
    }
}