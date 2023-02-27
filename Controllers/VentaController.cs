using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace APPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VentaController : ControllerBase
    {

        [HttpPost("{idUsuario}")]
        public void PostVenta(List<Producto> productos, long idUsuario)
        {
            MetodosVenta.CargarVenta(idUsuario, productos);
        }

        [HttpGet("{idUsuario}")]
        public void GetVenta(long idUsuario)
        {
            MetodosVenta.TraerVentas(idUsuario);
        }

    }
}
