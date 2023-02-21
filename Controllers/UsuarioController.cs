using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace APPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        [HttpPut]
        public void PutUsuario(Usuario usuario)
        {
            MetodosUsuario.ModificarUsuario(usuario);
        }




    }
}
