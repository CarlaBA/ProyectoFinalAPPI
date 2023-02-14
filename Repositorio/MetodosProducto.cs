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
       
        public static List<Producto> ObtenerProducto(long idUsuario)
        {
            
            List<Producto> productos = new List<Producto>();
            
            SqlCommand comando = new SqlCommand("SELECT * FROM Producto");
            ConexionSql.conexionSql.GetCommand(comando);
               

                SqlDataReader reader = comando.ExecuteReader();
                if(reader.HasRows)
                {
                    while(reader.Read())
                    {
                        Producto producto = new Producto();
                        producto.Id = reader.GetInt64(0);
                        producto.Descripciones = reader.GetString(1);
                        producto.Costo = reader.GetDecimal(2);
                        producto.PrecioVenta = reader.GetDecimal(3);
                        producto.Stock = reader.GetInt32(4);
                        producto.IdUsuario = reader.GetInt64(5);

                        productos.Add(producto);
                    }
                } return productos;

           
        }



        public static bool CrearProducto(Producto producto)
        {

            SqlCommand comando = new SqlCommand("INSERT INTO Prodcuto (Descripciones, Costo, PrecioVenta, Stock, IdUsuario) VALUES (@Descripciones, @Costo, @PrecioVenta, @Stock, @IdUsuario )");
            ConexionSql.conexionSql.GetCommand(comando);
            comando.Parameters.AddWithValue("@Descripciones", producto.Descripciones);
            comando.Parameters.AddWithValue("@Costo", producto.Costo);
            comando.Parameters.AddWithValue("@PrecioVenta", producto.PrecioVenta);
            comando.Parameters.AddWithValue("@Stock", producto.Stock);
            comando.Parameters.AddWithValue("@IdUsuario", producto.IdUsuario);

            comando.ExecuteNonQuery();
            return true;

        }

        public static bool ModificarProducto(Producto producto)
        {

            SqlCommand comando = new SqlCommand("UPDATE Producto SET Descripciones = @Descripciones, Costo = @Costo, PrecioVenta = @PrecioVenta, Stock = @Stock WHERE id = @ID");
            ConexionSql.conexionSql.GetCommand(comando);

            comando.Parameters.AddWithValue("@Descripciones", producto.Descripciones);
            comando.Parameters.AddWithValue("@Costo", producto.Costo);
            comando.Parameters.AddWithValue("@PrecioVenta", producto.PrecioVenta);
            comando.Parameters.AddWithValue("@Stock", producto.Stock);
            comando.Parameters.AddWithValue("@ID", producto.Id);


            int recordsAffected = comando.ExecuteNonQuery();




            return true;


        }

        public static bool EliminarProducto(int id)
        {

            {
                SqlCommand comando = new SqlCommand("DELETE ProductoVendido WHERE IdProducto = @ID");
                comando.Parameters.AddWithValue("@ID", id);

                int recordsAffected = comando.ExecuteNonQuery();

                SqlCommand comm = new SqlCommand("DELETE Producto WHERE Id = @ID");

                recordsAffected = comm.ExecuteNonQuery();

                return true;


            }


        }






    }
}
