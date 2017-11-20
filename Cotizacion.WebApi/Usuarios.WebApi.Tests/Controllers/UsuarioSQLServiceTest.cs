using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using Usuarios.Core.Model;
using Usuarios.Core.SQLService;
using System.Linq;

namespace Usuarios.WebApi.Tests.Controllers
{
    [TestClass]
    public class UsuarioSQLServiceTest
    {
        [TestMethod]
        public void GetAll()
        {
            // Act
            IEnumerable<Usuario> result = UsuarioSQLService.GetAll();

            // Assert
            Assert.IsNotNull(result);
            Assert.IsTrue(result.Count() > 0);
        }

        [TestMethod]
        public void GetById()
        {
            Usuario result = UsuarioSQLService.GetById(Guid.Parse("03116e65-eb1b-48a1-9434-5dd7839ec640"));

            Assert.IsNotNull(result);
            Assert.AreEqual(result.Apellido, "ApellidoTest");
            Assert.AreEqual(result.Email, "un@e.mail");
            Assert.AreEqual(result.Nombre, "NombreTest");
            Assert.AreEqual(result.Password, "No leer por favor");
        }

        [TestMethod]
        public void InsertNew()
        {
            //Arrange
            Usuario usuario = new Usuario()
            {
                Apellido = "ApellidoAutoGenerado",
                Email = "Unit@Test.com",
                Password = "Un1tT35t",
                Nombre = "NombreAutoGenerado"
            };

            //Act
            Guid newID = UsuarioSQLService.Insert(usuario);

            //Assert
            var check = UsuarioSQLService.GetById(newID);

            Assert.IsNotNull(check);
            Assert.AreEqual(usuario.Apellido, check.Apellido);
            Assert.AreEqual(usuario.Email, check.Email);
            Assert.AreEqual(usuario.Password, check.Password);
            Assert.AreEqual(usuario.Nombre, check.Nombre);
        }

        [TestMethod]
        public void Update()
        {
            //Arrange
            Usuario usuario = new Usuario()
            {
                Apellido = "ApellidoAutoGenerado",
                Email = "Unit@Test.com",
                Password = "Un1tT35t",
                Nombre = "NombreAutoGenerado"
            };

            Guid newID = UsuarioSQLService.Insert(usuario);

            usuario.Apellido = "Modificado";

            //Act
            UsuarioSQLService.Update(usuario);

            //Assert
            var check = UsuarioSQLService.GetById(newID);

            Assert.IsNotNull(check);
            Assert.AreEqual(usuario.Apellido, check.Apellido);
        }

        [TestMethod]
        public void DeleteById()
        {
            //Arrange
            Usuario usuario = new Usuario()
            {
                Apellido = "ApellidoAutoGenerado",
                Email = "Unit@Test.com",
                Password = "Un1tT35t",
                Nombre = "NombreAutoGenerado"
            };

            Guid newID = UsuarioSQLService.Insert(usuario);

            //Act
            UsuarioSQLService.DeleteById(newID);

            //Assert
            var check = UsuarioSQLService.GetById(newID);

            Assert.IsNull(check);
        }
    }
}