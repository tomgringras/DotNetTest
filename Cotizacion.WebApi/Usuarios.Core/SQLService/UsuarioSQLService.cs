using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Usuarios.Core.Model;

namespace Usuarios.Core.SQLService
{
    public static class UsuarioSQLService
    {
        public static IEnumerable<Usuario> GetAll()
        {
            using (UsuariosDbContext db = new UsuariosDbContext())
            {
                return db.Usuarios.ToList();
            }
        }

        public static Usuario GetById(Guid guid)
        {
            using (UsuariosDbContext db = new UsuariosDbContext())
            {
                return db.Usuarios.Find(guid);
            }
        }

        public static Guid Insert(Usuario usuario)
        {
            using (UsuariosDbContext db = new UsuariosDbContext())
            {
                if (usuario.UsuarioId.Equals(Guid.Empty))
                    usuario.UsuarioId = Guid.NewGuid();

                db.Usuarios.Add(usuario);
                db.SaveChanges();

                return usuario.UsuarioId;
            }
        }

        public static void Update(Usuario usuario)
        {
            using (UsuariosDbContext db = new UsuariosDbContext())
            {
                db.Entry(usuario).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
            }
        }

        public static void DeleteById(Guid id)
        {
            using (UsuariosDbContext db = new UsuariosDbContext())
            {
                var toBeDeleted = db.Usuarios.Find(id);
                db.Usuarios.Remove(toBeDeleted);
                db.SaveChanges();
            }
        }
    }
}

