using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laboratorio_72
{
    internal class JuegoDados
    {
        private Dado dado1, dado2, dado3;

        public JuegoDados()
        {
            dado1 = new Dado();
            dado2 = new Dado();
            dado3 = new Dado();
        }

        public void Jugar()
        {
            dado1.Tirar();
            dado1.Imprimir();
            dado2.Tirar();
            dado2.Imprimir();
            dado3.Tirar();
            dado3.Imprimir();
            if (dado1.retornarValor() == dado2.retornarValor() &&
                dado1.retornarValor() == dado3.retornarValor())
            {
                Console.WriteLine("Gano");
            }
            else
            {
                Console.WriteLine("Perdio");
            }
            Console.ReadKey();
        }

    }
}
