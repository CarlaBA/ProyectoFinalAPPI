using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace APPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductoVendidoController : ControllerBase
    {

        [HttpGet("{idUsuario}")]
        public List<Producto> GetProductoVendidoId(long idUsuario)
        {
            return MetodosProductosVendidos.ObtenerProductosVendidos(idUsuario);
        }

    }
}
