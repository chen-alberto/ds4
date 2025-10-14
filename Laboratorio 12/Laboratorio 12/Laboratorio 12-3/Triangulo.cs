using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laboratorio_12_3
{
    internal class Triangulo
    {
        public double Semiperimetro(string lado1Texto, string lado2Texto, string lado3Texto)
        {
            double lado1 = double.Parse(lado1Texto);
            double lado2 = double.Parse(lado2Texto);
            double lado3 = double.Parse(lado3Texto);
            double semiperimetro = (lado1 + lado2 + lado3) / 2;
            return semiperimetro;
        }

        public double Area(string lado1Texto, string lado2Texto, string lado3Texto)
        {
            double lado1 = double.Parse(lado1Texto);
            double lado2 = double.Parse(lado2Texto);
            double lado3 = double.Parse(lado3Texto);
            double s = (lado1 + lado2 + lado3) / 2;
            double area = Math.Sqrt(s * (s - lado1) * (s - lado2) * (s - lado3));
            return area;
        }
    }
}
