using Cotizacion.Core.Exceptions;
using Cotizacion.Core.Interfaces;
using Cotizacion.WebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;

namespace Cotizacion.WebApi.Controllers
{
    public class CotizacionController : ApiController
    {
        private ICotizacionStrategyFactory stratFactory;

        public CotizacionController(ICotizacionStrategyFactory stratFactory)
        {
            this.stratFactory = stratFactory;
        }

        [HttpGet]
        public CotizacionDTO GetCotizacion([FromUri]string cotizacionNombre)
        {
            var strat = stratFactory.GetStrategy(cotizacionNombre);
            Core.Concretes.Cotizacion cotizacion;

            try
            {
                cotizacion = strat.GetCotizacion();
                return new CotizacionDTO(cotizacion);
            }
            catch (UsuarioNoAutorizadoException)
            {
                throw new HttpException(401, "No Autorizado");
            }
            catch (Exception ex)
            {
                throw new HttpException("Error interno.", ex);
            }

        }
    }
}
