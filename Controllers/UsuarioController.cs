using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace APPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        [HttpGet("{nombreUsuario}/{contrasenia}")]
        public Usuario GetLogin(string nombreUsuario, string contrasenia)
        {
            var usuario = MetodosUsuario.LogginUsuario(nombreUsuario, contrasenia);
            return usuario == null ? new Usuario() : usuario;
        }



        [HttpGet("{nombreUsuario}")]
        public Usuario GetNombreUsuario(string nombreUsuario)
        {
            var usuario = MetodosUsuario.ObtenerNombreUsuario(nombreUsuario);
            return usuario == null ? new Usuario() : usuario;
        }


        [HttpPost]
        public void InsertUsuario(Usuario usuario)
        {
            MetodosUsuario.InsertarUsuario(usuario);
        }
        
        [HttpPut]
        public void PutUsuario(Usuario usuario)
        {
            MetodosUsuario.ModificarUsuario(usuario);
        }

        [HttpDelete("{id}")]
        public void DeleteUsuario(long id)
        {
            MetodosUsuario.EliminarUsuario(id);
        }



    }
}
