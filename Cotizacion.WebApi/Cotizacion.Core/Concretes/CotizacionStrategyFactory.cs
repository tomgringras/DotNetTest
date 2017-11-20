using Cotizacion.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cotizacion.Core.Concretes
{
    public class CotizacionStrategyFactory : ICotizacionStrategyFactory
    {
        public ICotizacionStrategy GetStrategy(string cotizacionNombre)
        {
            switch(cotizacionNombre)
            {
                case "Dolar":
                    return new DolarStrategy();
                case "Peso":
                    return new PesoStrategy();
                case "Real":
                    return new RealStrategy();
                default:
                    throw new ArgumentException(string.Format("{0} no es una cotización válida.", cotizacionNombre));

            }
        }
    }
}
