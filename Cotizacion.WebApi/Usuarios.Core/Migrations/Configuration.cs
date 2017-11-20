namespace Usuarios.Core.Migrations
{
    using Model;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Usuarios.Core.Model.UsuariosContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(Usuarios.Core.Model.UsuariosContext context)
        {
            context.Usuarios.AddOrUpdate(new Usuario()
            {
                Apellido = "ApellidoTest",
                Email = "un@e.mail",
                Nombre = "NombreTest",
                Password = "No leer por favor",
                UsuarioId = Guid.Parse("03116e65-eb1b-48a1-9434-5dd7839ec640")
            });

            context.SaveChanges();
        }
    }
}
