using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace APPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VentaController : ControllerBase
    {

        [HttpPost("{idUsuario}")]
        public void PostVenta(List<Producto> productosVendidos, long idUsuario)
        {
            MetodosVenta.CargarVenta(productosVendidos, idUsuario);
        }

    }
}
