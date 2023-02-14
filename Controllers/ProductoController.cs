using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace APPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductoController : ControllerBase
    {
        [HttpPost]
        public void PostProducto(Producto producto)
        {
            MetodosProducto.CrearProducto(producto);
        }

        [HttpPut]
        public void PutProducto(Producto producto)
        {
            MetodosProducto.ModificarProducto(producto);
        }

        [HttpDelete("{idProducto}")]
        public void DeleteProducto(int idProducto)
        {
            MetodosProducto.EliminarProducto(idProducto);
        }



    }
}
