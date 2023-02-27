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

        public static List<Venta> TraerVentas(long idUsuario)
        {
            
            List<Venta> listaObtenerVentas = new List<Venta>();

            using(SqlConnection con = new SqlConnection(conexion))
            {
                
                SqlCommand comando = new SqlCommand ("SELECT * FROM Venta WHERE @IdUsuario = idUsuario", con);
                comando.Parameters.AddWithValue("@IdUsuario", idUsuario);
                con.Open();

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


        public static void CargarVenta(long idUsuario, List<Producto> productosVendidos)
        {
            Venta venta = new Venta();
            using (SqlConnection con = new SqlConnection(conexion))
            {
                SqlCommand comando = new SqlCommand();
                comando.Connection = con;
                comando.Connection.Open();

                venta.Comentarios = "";
                venta.IdUsuario = idUsuario;
                venta.Id = InsertarVenta(venta);

                foreach (Producto producto in productosVendidos)
                {
                    ProductoVendido productoVendido = new ProductoVendido();
                    productoVendido.Stock = producto.Stock;
                    productoVendido.IdProducto = producto.Id;
                    productoVendido.IdVenta = venta.Id;

                    MetodosProductosVendidos.InsertarProductoVendido(productoVendido);

                    MetodosProducto.ModificarStockProducto(productoVendido.IdProducto, productoVendido.Stock);
                }
            }
        }

        public static long InsertarVenta(Venta venta)
        { 
            using(SqlConnection con = new SqlConnection(conexion))
            {
                SqlCommand comando = new SqlCommand();
                comando.Connection = con;
                comando.Connection.Open();

                comando.CommandText = @"INSERT INTO Venta ([Comentarios],[IdUsuario]) VALUES (@Comentarios,@IdUsuario)";
                comando.Parameters.AddWithValue("@Comentarios", venta.Comentarios);
                comando.Parameters.AddWithValue("@IdUsuario", venta.IdUsuario);
                comando.ExecuteNonQuery();

                comando.CommandText = "SELECT @@Identity";
                long LastID = Convert.ToInt64(comando.ExecuteScalar());
                comando.Connection.Close();

                return LastID;
               
             

            }

        }
















    }
}
