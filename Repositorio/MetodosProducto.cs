using APPI;
using System.Data.SqlClient;


namespace APPI
{
    internal static class MetodosProducto
    {
        public static string conexion = "Data Source = DESKTOP-2FTHB12\\MSSQLSERVER1; Initial Catalog = SistemaGestion; Integrated Security = True; Connect Timeout = 30; Encrypt = False; TrustServerCertificate = False; ApplicationIntent = ReadWrite; MultiSubnetFailover = False";

        public static List<Producto> ObtenerProducto(long idUsuario)
        {
            
            List<Producto> productos = new List<Producto>();
            using (SqlConnection con = new SqlConnection(conexion))
            {
                
                SqlCommand comando = new SqlCommand("SELECT * FROM Producto WHERE @idUsuario=idUsuario",con);
                comando.Parameters.AddWithValue("@IdUsuario", idUsuario);
                con.Open();

                SqlDataReader reader = comando.ExecuteReader();
                if (reader.HasRows)
                {
                    reader.Read();

                    Producto producto = new Producto();
                    producto.Id = reader.GetInt64(0);
                    producto.Descripciones = reader.GetString(1);
                    producto.Costo = reader.GetDecimal(2);
                    producto.PrecioVenta = reader.GetDecimal(3);
                    producto.Stock = reader.GetInt32(4);
                    producto.IdUsuario = reader.GetInt64(5);

                    productos.Add(producto);

                }
                return productos;
            }
           
        }


        public static Producto ObtenerProductoId(long id)
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



        public static Producto CrearProducto(Producto producto)
        {
            using (SqlConnection con = new SqlConnection(conexion))
            {
                
                SqlCommand comando = new SqlCommand();

                comando.Connection = con; 
                comando.Connection.Open();
                comando.CommandText = @"INSERT INTO Producto ([Descripciones], [Costo], [PrecioVenta], [Stock], [IdUsuario]) VALUES (@Descripciones, @Costo, @PrecioVenta, @Stock, @IdUsuario)";
                comando.Parameters.AddWithValue("@Descripciones", producto.Descripciones);
                comando.Parameters.AddWithValue("@Costo", producto.Costo);
                comando.Parameters.AddWithValue("@PrecioVenta", producto.PrecioVenta);
                comando.Parameters.AddWithValue("@Stock", producto.Stock);
                comando.Parameters.AddWithValue("@IdUsuario", producto.IdUsuario);
                comando.ExecuteNonQuery();
                comando.Connection.Close();
            }
            return producto;
        }

        public static Producto ModificarProducto(Producto producto)
        {
                using (SqlConnection con = new SqlConnection(conexion))
                {
                    
                    SqlCommand comando = new SqlCommand();

                    comando.Connection = con;
                    comando.Connection.Open();
                    comando.CommandText = @"UPDATE Producto SET [Descripciones] = @Descripciones, [Costo] = @Costo, [PrecioVenta] = @PrecioVenta, [Stock] = @Stock WHERE [Id] = @ID";
                    comando.Parameters.AddWithValue("@Descripciones", producto.Descripciones);
                    comando.Parameters.AddWithValue("@Costo", producto.Costo);
                    comando.Parameters.AddWithValue("@PrecioVenta", producto.PrecioVenta);
                    comando.Parameters.AddWithValue("@Stock", producto.Stock);
                    comando.Parameters.AddWithValue("@ID", producto.Id);
                    comando.ExecuteNonQuery();
                    comando.Connection.Close();




                    
                }
            return producto;
        }

        public static long EliminarProducto(long id)
        {
            using(SqlConnection con = new SqlConnection(conexion))
            {
                  
                SqlCommand comando = new SqlCommand();
                comando.Connection = con;
                comando.Connection.Open();
                comando.CommandText = @"DELETE [ProductoVendido] WHERE [IdProducto] = @ID";
                comando.Parameters.AddWithValue("@ID", id);

                comando.ExecuteNonQuery();

                comando.CommandText = "DELETE [Producto] WHERE [Id] = @ID";

                comando.ExecuteNonQuery();
                comando.Connection.Close();

                  


            }
            return id;

        }


        public static Producto ModificarStockProducto(long id, int cantidadVendidos)
        {
            Producto producto = ObtenerProductoId(id);
            producto.Stock -= cantidadVendidos;
            return ModificarProducto(producto);
        }




    }
}
