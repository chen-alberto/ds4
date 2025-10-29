using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pARCIAL_2
{
   
    internal class Conversion
    {
        public double ConversionDolarEuro(double monto)
        {
            return monto * 1.17;
        }

        public double ConversionDolarPeso(double monto)
        {
            return monto * 4.258;
        }

        public double ConversionPesoDolar(double monto)
        {
            return monto / 4.258;
        }

        public double ConversionPesoEuro(double monto)
        {
            return monto / 4.258 * 1.17;
        }

        public double ConversionEuroDolar(double monto)
        {
            return monto / 1.17;
        }

        public double ConversionEuroPeso(double monto)
        {
            return monto / 1.17 * 4.258;
        }
    }
}
