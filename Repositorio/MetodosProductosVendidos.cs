using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APPI
{
    internal class MetodosProductosVendidos
    {
        public static List<Producto> ObtenerProductosVendidos(long idUsuario)
        {
            List<long> idProductos = new List<long>();

            SqlCommand comando = new SqlCommand("SELECT IdProducto FROM Venta INNER JOIN ProductoVendido ON Venta.Id = ProductoVendido.IdVenta WHERE IdUsuario = @idUsuario ");
            comando.Parameters.AddWithValue("@idUsuario", idUsuario);

            ConexionSql.conexionSql.GetCommand(comando);

            SqlDataReader reader = comando.ExecuteReader();
            if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        idProductos.Add(reader.GetInt64(0));

                    }
                }
                List<Producto> productos = new List<Producto>();
                foreach (var item in idProductos)
                {

                    Producto producto = new Producto();
                    MetodosProducto.ObtenerProducto(item);
                    productos.Add(producto);
                }


                return productos;

           
        }
















    }
}
