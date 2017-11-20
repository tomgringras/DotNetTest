using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Cotizacion.WebApi.Models
{
    public class CotizacionDTO
    {
        public CotizacionDTO(Core.Concretes.Cotizacion cotizacion)
        {
            this.Compra = cotizacion.Compra;
            this.Nombre = cotizacion.Nombre;
            this.Venta = cotizacion.Venta;
        }

        public string Nombre { get; set; }
        public double Venta { get; set; }
        public double Compra { get; set; }
    }
}