using APPI;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace APPI
{
    internal class MetodosProducto
    {
        static string conexion = "Data Source = DESKTOP-2FTHB12\\MSSQLSERVER1; Initial Catalog = SistemaGestion; Integrated Security = True; Connect Timeout = 30; Encrypt = False; TrustServerCertificate = False; ApplicationIntent = ReadWrite; MultiSubnetFailover = False";

        public static List<Producto> ObtenerProducto(long idUsuario)
        {
            
            List<Producto> productos = new List<Producto>();
            using (SqlConnection con = new SqlConnection(conexion))
            {
                con.Open();
                SqlCommand comando = new SqlCommand("SELECT * FROM Producto WHERE @idUsuario=idUsuario",con);
                comando.Parameters.AddWithValue("@IdUsuario", idUsuario);

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



        public static Producto CrearProducto(Producto producto)
        {
            using (SqlConnection con = new SqlConnection(conexion))
            {
                con.Open();
                SqlCommand comando = new SqlCommand("INSERT INTO Producto (Descripciones, Costo, PrecioVenta, Stock, IdUsuario) VALUES (@Descripciones, @Costo, @PrecioVenta, @Stock, @IdUsuario )",con);
                
                comando.Parameters.AddWithValue("@Descripciones", producto.Descripciones);
                comando.Parameters.AddWithValue("@Costo", producto.Costo);
                comando.Parameters.AddWithValue("@PrecioVenta", producto.PrecioVenta);
                comando.Parameters.AddWithValue("@Stock", producto.Stock);
                comando.Parameters.AddWithValue("@IdUsuario", producto.IdUsuario);

                comando.ExecuteNonQuery();
                return producto;
            }
        }

        public static Producto ModificarProducto(Producto producto)
        {
                using (SqlConnection con = new SqlConnection(conexion))
                {
                    con.Open();
                    SqlCommand comando = new SqlCommand("UPDATE Producto SET Descripciones = @Descripciones, Costo = @Costo, PrecioVenta = @PrecioVenta, Stock = @Stock WHERE id = @ID",con);
                    

                    comando.Parameters.AddWithValue("@Descripciones", producto.Descripciones);
                    comando.Parameters.AddWithValue("@Costo", producto.Costo);
                    comando.Parameters.AddWithValue("@PrecioVenta", producto.PrecioVenta);
                    comando.Parameters.AddWithValue("@Stock", producto.Stock);
                    comando.Parameters.AddWithValue("@ID", producto.Id);


                    int recordsAffected = comando.ExecuteNonQuery();




                    return producto;
                }

        }

        public static int EliminarProducto(int id)
        {
            using(SqlConnection con = new SqlConnection(conexion))
            {
                  con.Open();
                  SqlCommand comando = new SqlCommand("DELETE ProductoVendido WHERE IdProducto = @ID",con);
                  comando.Parameters.AddWithValue("@ID", id);

                  int recordsAffected = comando.ExecuteNonQuery();

                  SqlCommand comm = new SqlCommand("DELETE Producto WHERE Id = @ID",con);

                  recordsAffected = comm.ExecuteNonQuery();

                  return id;


            }


        }






    }
}
