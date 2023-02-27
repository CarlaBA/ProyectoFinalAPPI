using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;


namespace APPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductoController : ControllerBase
    {
        [HttpGet("{idUsuario}")]
        public List<Producto> GetProductoVendido(long idUsuario)
        {
            return MetodosProducto.ObtenerProducto(idUsuario);
        }

        
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
        public void DeleteProducto(long idProducto)
        {
            MetodosProducto.EliminarProducto(idProducto);
        }



    }
}
