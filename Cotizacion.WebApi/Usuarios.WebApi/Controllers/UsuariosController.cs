using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Usuarios.Core.Model;
using Usuarios.Core.SQLService;

namespace Usuarios.WebApi.Controllers
{
    public class UsuariosController : ApiController
    {
        // GET: api/Usuarios
        public IEnumerable<Usuario> Get()
        {
            return UsuarioSQLService.GetAll();
        }

        // GET: api/Usuarios/5
        public Usuario Get(Guid id)
        {
            return UsuarioSQLService.GetById(id);
        }

        // POST: api/Usuarios
        public void Post([FromBody]Usuario value)
        {
            UsuarioSQLService.Insert(value);
        }

        // PUT: api/Usuarios/5
        public void Put(Guid id, [FromBody]Usuario value)
        {
            value.UsuarioId = id;
            UsuarioSQLService.Update(value);
        }

        // DELETE: api/Usuarios/5
        public void Delete(Guid id)
        {
            UsuarioSQLService.DeleteById(id);
        }
    }
}
