using APPI;
using System.Data.SqlClient;

namespace APPI
{
    internal static class MetodosProductosVendidos
    {
        public static string conexion = "Data Source = DESKTOP-2FTHB12\\MSSQLSERVER1; Initial Catalog = SistemaGestion; Integrated Security = True; Connect Timeout = 30; Encrypt = False; TrustServerCertificate = False; ApplicationIntent = ReadWrite; MultiSubnetFailover = False";

        public static Producto ObtenerProducto(long id)
        {
            Producto producto = new Producto();
            using (SqlConnection con = new SqlConnection(conexion))
            {
                SqlCommand comando = new SqlCommand("SELECT * FROM Producto WHERE id=@Id", con);
                comando.Parameters.AddWithValue("@Id", id);

                con.Open();

                SqlDataReader reader = comando.ExecuteReader();
                if (reader.HasRows)
                {
                    reader.Read();

                    Producto producto2 = new Producto();
                    producto.Id = reader.GetInt64(0);
                    producto.Descripciones = reader.GetString(1);
                    producto.Costo = reader.GetDecimal(2);
                    producto.PrecioVenta = reader.GetDecimal(3);
                    producto.Stock = reader.GetInt32(4);
                    producto.IdUsuario = reader.GetInt64(5);

                }

                return producto;
            }
        }

        public static List<Producto> ObtenerProductosVendidos(long idUsuario)
        {
            List<long> idProductos = new List<long>();
            using (SqlConnection con = new SqlConnection(conexion))
            {
                
                SqlCommand comando = new SqlCommand("SELECT IdProducto FROM Venta INNER JOIN ProductoVendido ON Venta.Id = ProductoVendido.IdVenta WHERE IdUsuario = @idUsuario ",con);
                comando.Parameters.AddWithValue("@idUsuario", idUsuario);
                con.Open();

                SqlDataReader reader = comando.ExecuteReader();
                if (reader.HasRows)
                {
                    reader.Read();

                    idProductos.Add(reader.GetInt64(0));


                }
                List<Producto> productos = new List<Producto>();
                foreach (var id in idProductos)
                {

                    Producto producto = ObtenerProducto(id);
                    productos.Add(producto);
                }


                return productos;


            }
        }

        

        public static void InsertarProductoVendido (ProductoVendido productoVendido)
        {
            using (SqlConnection con = new SqlConnection(conexion))
            {
                SqlCommand comando = new SqlCommand();

                comando.Connection = con;
                comando.Connection.Open();
                comando.CommandText = @"INSERT INTO ProductoVendido ([Stock], [IdProducto], [IdVenta]) VALUES ( @stock, @idProducto, @idVenta)";

                comando.Parameters.AddWithValue("@stock", productoVendido.Stock);
                comando.Parameters.AddWithValue("@idProducto", productoVendido.IdProducto);
                comando.Parameters.AddWithValue("@idVenta", productoVendido.IdVenta);
                comando.ExecuteNonQuery();
                comando.Connection.Close();

            }
        }


    }
}
