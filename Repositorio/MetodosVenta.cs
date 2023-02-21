using APPI;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APPI
{
    internal class MetodosVenta
    {
        static string conexion = "Data Source = DESKTOP-2FTHB12\\MSSQLSERVER1; Initial Catalog = SistemaGestion; Integrated Security = True; Connect Timeout = 30; Encrypt = False; TrustServerCertificate = False; ApplicationIntent = ReadWrite; MultiSubnetFailover = False";

        public static List<Venta> TraerVentas(long id)
        {
            
            List<Venta> listaObtenerVentas = new List<Venta>();

            using(SqlConnection con = new SqlConnection(conexion))
            {
                con.Open();
                SqlCommand comando = new SqlCommand ("SELECT * FROM Venta WHERE @Id = id");
                comando.Parameters.AddWithValue("@Id", id);
                

                SqlDataReader reader = comando.ExecuteReader();
                
                if (reader.HasRows)
                {
                    reader.Read();
               
                    Venta venta = new Venta();
                    venta.Id = reader.GetInt64(0);
                    venta.Comentarios = reader.GetString(1);
                    venta.IdUsuario = reader.GetInt64(2);
                    listaObtenerVentas.Add(venta);
                }
                            
            }
              return listaObtenerVentas;
            
            
        }


        public static void CargarVenta(List<Producto> productosVendidos, long idUsuario)
        {
            Venta venta = new Venta();
            using (SqlConnection con = new SqlConnection(conexion))
            {
                con.Open();
                SqlCommand comando = new SqlCommand("INSERT INTO Venta ([Comentarios],[IdUsuario]) VALUES (@Comentarios,@IdUsuario)");
                comando.Parameters.AddWithValue("@Comentarios", "");
                comando.Parameters.AddWithValue("@IdUsuario", idUsuario);
            
                
                comando.ExecuteNonQuery();


                venta.IdUsuario = idUsuario;
                foreach (Producto producto in productosVendidos)
                {
                    SqlCommand comando1 = new SqlCommand("INSERT INTO ProductoVendido ([Stock],[IdProducto],[IdVenta]) VALUES (@Stock, @IdProducto, @IdVenta)");

                    comando1.Parameters.AddWithValue("@Stock", producto.Stock);
                    comando1.Parameters.AddWithValue("@IdProducto", producto.Id);
                    comando1.Parameters.AddWithValue("@IdVenta", venta.Id);

                    comando1.ExecuteNonQuery();


                    SqlCommand comando2 = new SqlCommand(" UPDATE Producto SET Stock = Stock - @Stock WHERE id = @IdProducto");

                    comando2.Parameters.AddWithValue("@Stock", producto.Stock);
                    comando2.Parameters.AddWithValue("@IdProducto", producto.Id);

                    comando2.ExecuteNonQuery();

                }

            }

        }
















    }
}
