using APPI;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APPI
{
    internal class MetodosUsuario
    {
        static string conexion = "Data Source = DESKTOP-2FTHB12\\MSSQLSERVER1; Initial Catalog = SistemaGestion; Integrated Security = True; Connect Timeout = 30; Encrypt = False; TrustServerCertificate = False; ApplicationIntent = ReadWrite; MultiSubnetFailover = False";

        public static List<Usuario> TraerUsuario(long id)
        {
            List<Usuario> listaUsuario = new List<Usuario>();

            using(SqlConnection con = new SqlConnection(conexion))
            {
                con.Open();
                SqlCommand comando = new SqlCommand ("SELECT * FROM Usuario WHERE @Id = id",con);
                comando.Parameters.AddWithValue("@id", id);
                

                SqlDataReader reader = comando.ExecuteReader();
                if (reader.HasRows)
                {
                    reader.Read();
              
                    Usuario usuario = new Usuario();
                    usuario.Id = reader.GetInt64(0);
                    usuario.Nombre = reader.GetString(1);
                    usuario.Apellido = reader.GetString(2);
                    usuario.NombreUsuario = reader.GetString(3);
                    usuario.Contrasenia = reader.GetString(4);
                    usuario.Mail = reader.GetString(5);
                    listaUsuario.Add(usuario);
                }
            }

                return listaUsuario;
            

        }
            
   


        public static Usuario LogginUsuario(string usuario, string contraseña)
        {
            Usuario user = new Usuario();
         
            using(SqlConnection con = new SqlConnection(conexion))
            {
                con.Open();
                SqlCommand comando = new SqlCommand("SELECT * FROM Usuario WHERE @NombreUsuario = NombreUsuario and @Contraseña = Contraseña",con);
                comando.Parameters.AddWithValue("@NombreUsuario", usuario);
                comando.Parameters.AddWithValue("@Contraseña", contraseña);
              

                SqlDataReader reader = comando.ExecuteReader();

                if (reader.HasRows)
                {
                    reader.Read();
               
                  
                    user.Id = reader.GetInt64(0);
                    user.Nombre = reader.GetString(1);
                    user.Apellido = reader.GetString(2);
                    user.NombreUsuario = reader.GetString(3);
                    user.Contrasenia = reader.GetString(4);
                    user.Mail = reader.GetString(5);

                  
                }
            }
             
                return user;

        }


        public static Usuario ModificarUsuario(Usuario usuario)
        {
            using (SqlConnection con = new SqlConnection(conexion))
            {
                con.Open();
                SqlCommand comando = new SqlCommand("UPDATE Usuario SET Nombre = @Nombre, Apellido = @Apellido, NombreUsuario = @NombreUsuario, Contraseña = @Contrasenia, Mail = @Mail WHERE id = @ID",con);

                comando.Parameters.AddWithValue("@Nombre", usuario.Nombre);
                comando.Parameters.AddWithValue("@Apellido", usuario.Apellido);
                comando.Parameters.AddWithValue("@NombreUsuario", usuario.NombreUsuario);
                comando.Parameters.AddWithValue("@Contraseña", usuario.Contrasenia);
                comando.Parameters.AddWithValue("@Mail", usuario.Mail);
                comando.Parameters.AddWithValue("@ID", usuario.Id);


                int recordsAffected = comando.ExecuteNonQuery();




                return usuario;
            }

        }




    }
}










