using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laboratorio_12
{
    class CalcularDistancia
    {
        public double Calcular(string tiempoTexto, string velocidadTexto)
        {
            double tiempo = double.Parse(tiempoTexto);
            double velocidad = double.Parse(velocidadTexto);
            double distancia = tiempo * velocidad;
            return distancia;
        }
    }
}

