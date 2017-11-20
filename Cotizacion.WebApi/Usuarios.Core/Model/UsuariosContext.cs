using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Usuarios.Core.Model
{
    class UsuariosContext : DbContext
    {
        public UsuariosContext()
        {
            Database.SetInitializer(new DropCreateDatabaseIfModelChanges<UsuariosContext>());
        }

        public DbSet<Usuario> Usuarios { get; set; }

    }
}