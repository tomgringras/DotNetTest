using Cotizacion.Core.Exceptions;
using Cotizacion.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cotizacion.Core.Concretes
{
    public class PesoStrategy : ICotizacionStrategy
    {
        public Cotizacion GetCotizacion()
        {
            throw new UsuarioNoAutorizadoException();
        }
    }
}
