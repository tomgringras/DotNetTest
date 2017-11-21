using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Usuarios.Core.Model
{
    class UsuariosDbContext : DbContext
    {
        public UsuariosDbContext()
        {
            Database.SetInitializer(new AppInitializer());
        }
        public DbSet<Usuario> Usuarios { get; set; }
    }

    internal class AppInitializer : IDatabaseInitializer<UsuariosDbContext>
    {
        public void InitializeDatabase(UsuariosDbContext context)
        {
            var guid = Guid.Parse("03116e65-eb1b-48a1-9434-5dd7839ec640");
            if (!context.Usuarios.Any(u => u.UsuarioId == guid))
            {
                context.Usuarios.Add(new Usuario()
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
}