using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laboratorio_12_2
{
    class Promedio
    {
        public double calcularPromedio(string n1,string n2,string n3)
        {
            double numero1 = double.Parse(n1);
            double numero2 = double.Parse(n2);
            double numero3 = double.Parse(n3);
            double promedio = (numero1 + numero2 + numero3) / 3;
            return promedio;

        }
    }
}
