using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Usuarios.WebApi.Controllers;
using Usuarios.Core.Model;
using System.Linq;

namespace Usuarios.WebApi.Tests.Controllers
{
    [TestClass]
    public class UsuariosControllerTest
    {
        [TestMethod]
        public void Get_Usuarios()
        {
            // Arrange
            UsuariosController controller = new UsuariosController();

            // Act
            var result = controller.Get();

            // Assert
            Assert.IsNotNull(result);
            Assert.IsTrue(result.Count() > 0);
        }


        [TestMethod]
        public void GetById_Usuario()
        {
            // Arrange
            UsuariosController controller = new UsuariosController();

            Usuario result = controller.Get(Guid.Parse("03116e65-eb1b-48a1-9434-5dd7839ec640"));

            Assert.IsNotNull(result);
            Assert.AreEqual(result.Apellido, "ApellidoTest");
            Assert.AreEqual(result.Email, "un@e.mail");
            Assert.AreEqual(result.Nombre, "NombreTest");
            Assert.AreEqual(result.Password, "No leer por favor");
        }

        [TestMethod]
        public void InsertNew_Usuario()
        {
            // Arrange
            UsuariosController controller = new UsuariosController();

            Usuario usuario = new Usuario()
            {
                Apellido = "ApellidoAutoGenerado",
                Email = "Unit@Test.com",
                Password = "Un1tT35t",
                Nombre = "NombreAutoGenerado",
                UsuarioId = Guid.NewGuid()
            };

            //Act
            controller.Post(usuario);

            //Assert
            var check = controller.Get(usuario.UsuarioId);

            Assert.IsNotNull(check);
            Assert.AreEqual(usuario.Apellido, check.Apellido);
            Assert.AreEqual(usuario.Email, check.Email);
            Assert.AreEqual(usuario.Password, check.Password);
            Assert.AreEqual(usuario.Nombre, check.Nombre);
        }

        [TestMethod]
        public void Update_Usuario()
        {
            //Arrange
            UsuariosController controller = new UsuariosController();

            Usuario usuario = new Usuario()
            {
                Apellido = "ApellidoAutoGenerado",
                Email = "Unit@Test.com",
                Password = "Un1tT35t",
                Nombre = "NombreAutoGenerado",
                UsuarioId = Guid.NewGuid()
            };

            controller.Post(usuario);

            usuario.Apellido = "Modificado";

            //Act
            controller.Put(usuario.UsuarioId, usuario);

            //Assert
            var check = controller.Get(usuario.UsuarioId);

            Assert.IsNotNull(check);
            Assert.AreEqual(usuario.Apellido, check.Apellido);
        }

        [TestMethod]
        public void Delete_Usuario()
        {
            //Arrange
            UsuariosController controller = new UsuariosController();

            Usuario usuario = new Usuario()
            {
                Apellido = "ApellidoAutoGenerado",
                Email = "Unit@Test.com",
                Password = "Un1tT35t",
                Nombre = "NombreAutoGenerado"
            };

            controller.Post(usuario);

            //Act
            controller.Delete(usuario.UsuarioId);

            //Assert
            var check = controller.Get(usuario.UsuarioId);

            Assert.IsNull(check);
        }
    }
}
