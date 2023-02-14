using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace APPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        [HttpPut]
        public bool PutUsuario(Usuario usuario)
        {
            return MetodosUsuario.ModificarUsuario(usuario);
        }




    }
}
