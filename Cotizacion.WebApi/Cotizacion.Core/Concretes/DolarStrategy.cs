using Cotizacion.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Cotizacion.Core.Concretes
{
    public class DolarStrategy : ICotizacionStrategy
    {
        public Cotizacion GetCotizacion()
        {
            string serviceResponse = ConsumirServiceBancario();
            string[] parsedResponse = DeserializarJson(serviceResponse);

            Validar(parsedResponse);

            Cotizacion cotizacion = ContruirInstancia(parsedResponse);
            return cotizacion;
        }

        private Cotizacion ContruirInstancia(string[] parsedResponse)
        {
            return new Cotizacion()
            {
                Compra = double.Parse(parsedResponse[0]),
                Venta = double.Parse(parsedResponse[1]),
                Nombre = "Dolar"
            };
        }

        private void Validar(string[] parsedResponse)
        {
            if (parsedResponse.Length < 2)
                throw new Exception("La respuesta recibida del service bancario es inválida. Pocas variables.");

            double dummy;
            if (!double.TryParse(parsedResponse[0], out dummy) || !double.TryParse(parsedResponse[1], out dummy))
                throw new Exception("La respuesta recibida del service bancario es inválida. Variables no numéricas.");
        }

        private string[] DeserializarJson(string serviceResponse)
        {
            return Newtonsoft.Json.JsonConvert.DeserializeObject<string[]>(serviceResponse);
        }

        private string ConsumirServiceBancario()
        {
            HttpClient client = new HttpClient();

            var stringReceived = client.GetStringAsync("https://www.bancoprovincia.com.ar/Principal/Dolar").Result;
            return stringReceived;             
        }
    }
}
