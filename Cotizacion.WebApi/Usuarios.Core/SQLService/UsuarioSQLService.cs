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
            using (UsuariosContext db = new UsuariosContext())
            {
                return db.Usuarios.ToList();
            }
        }

        public static Usuario GetById(Guid guid)
        {
            using (UsuariosContext db = new UsuariosContext())
            {
                return db.Usuarios.Find(guid);
            }
        }

        public static Guid Insert(Usuario usuario)
        {
            using (UsuariosContext db = new UsuariosContext())
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
            using (UsuariosContext db = new UsuariosContext())
            {
                db.Entry(usuario).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
            }
        }

        public static void DeleteById(Guid id)
        {
            using (UsuariosContext db = new UsuariosContext())
            {
                var toBeDeleted = db.Usuarios.Find(id);
                db.Usuarios.Remove(toBeDeleted);
                db.SaveChanges();
            }
        }
    }
}

