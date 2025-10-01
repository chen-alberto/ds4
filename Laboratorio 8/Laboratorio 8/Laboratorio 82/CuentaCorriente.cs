using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laboratorio_82
{
    internal class CuentaCorriente : Cuenta
    {
        public CuentaCorriente(string prmtidCuenta)
            : base(prmtidCuenta)
        {
        }
        public override void CalcularInteres()
        {
            System.Console.WriteLine(
                "CuentaCorriente.CalcularIntereses() efectuado para la cuenta {0}",
                this.getIdCuenta());
        }
    }
}
