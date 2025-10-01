using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laboratorio_82
{
    internal class CuentaAhorro : Cuenta
    {
        public CuentaAhorro(string prmtidCuenta) : base(prmtidCuenta)
        {
        }
        public override void CalcularInteres()
        {
            System.Console.WriteLine(
                "CuentaAhorro.CalcularIntereses() efectuado para la cuenta {0}",
                this.getIdCuenta());
        }
    }
}
