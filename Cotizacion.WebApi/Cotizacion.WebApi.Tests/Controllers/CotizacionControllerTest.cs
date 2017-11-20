using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Cotizacion.Core.Interfaces;
using Cotizacion.Core.Concretes;
using Cotizacion.WebApi.Controllers;
using System.Web;

namespace Cotizacion.WebApi.Tests.Controllers
{
    [TestClass]
    public class CotizacionControllerTest
    {
        private ICotizacionStrategyFactory _factory = new CotizacionStrategyFactory();

        [TestMethod]
        public void GetDolar()
        {
            // Arrange
            CotizacionController controller = new CotizacionController(_factory);

            // Act
            var result = controller.GetCotizacion("Dolar");

            // Assert
            Assert.AreEqual("Dolar", result.Nombre);
            Assert.IsTrue(result.Compra != 0);
            Assert.IsTrue(result.Venta != 0);
        }


        [TestMethod]
        [ExpectedException(typeof(HttpException), "Not Authorized")]
        public void GetPeso()
        {
            // Arrange
            CotizacionController controller = new CotizacionController(_factory);

            // Act
            var result = controller.GetCotizacion("Peso");

            // Assert
            Assert.AreEqual("Peso", result.Nombre);
            Assert.IsTrue(result.Compra != 0);
            Assert.IsTrue(result.Venta != 0);
        }


        [TestMethod]
        [ExpectedException(typeof(HttpException), "Not Authorized")]
        public void GetReal()
        {
            // Arrange
            CotizacionController controller = new CotizacionController(_factory);

            // Act
            var result = controller.GetCotizacion("Real");

            // Assert
            Assert.AreEqual("Dolar", result.Nombre);
            Assert.IsTrue(result.Compra != 0);
            Assert.IsTrue(result.Venta != 0);
        }
    }
}
