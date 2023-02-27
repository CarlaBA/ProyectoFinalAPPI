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

        public static Usuario TraerUsuario(long id)
        {
            Usuario usuario = new Usuario();
            List<Usuario> listaUsuario = new List<Usuario>();

            using(SqlConnection con = new SqlConnection(conexion))
            {
                
                SqlCommand comando = new SqlCommand ("SELECT * FROM Usuario WHERE @Id = id",con);
                comando.Parameters.AddWithValue("@id", id);
                con.Open();

                SqlDataReader reader = comando.ExecuteReader();
                if (reader.HasRows)
                {
                    reader.Read();
              
                    Usuario usuario1 = new Usuario();
                    usuario.Id = reader.GetInt64(0);
                    usuario.Nombre = reader.GetString(1);
                    usuario.Apellido = reader.GetString(2);
                    usuario.NombreUsuario = reader.GetString(3);
                    usuario.Contrasenia = reader.GetString(4);
                    usuario.Mail = reader.GetString(5);
                    
                }
            }

                return usuario;
            

        }
            
   


        public static Usuario LogginUsuario(string usuario, string contraseña)
        {
            Usuario usuarioLogin = new Usuario();
         
            using(SqlConnection con = new SqlConnection(conexion))
            {
                
                SqlCommand comando = new SqlCommand("SELECT * FROM Usuario WHERE @NombreUsuario = NombreUsuario and @Contraseña = Contraseña",con);
                comando.Parameters.AddWithValue("@NombreUsuario", usuario);
                comando.Parameters.AddWithValue("@Contraseña", contraseña);
                con.Open();

                SqlDataReader reader = comando.ExecuteReader();

                if (reader.HasRows)
                {
                    reader.Read();

                    Usuario user = new Usuario();
                    user.Id = reader.GetInt64(0);
                    user.Nombre = reader.GetString(1);
                    user.Apellido = reader.GetString(2);
                    user.NombreUsuario = reader.GetString(3);
                    user.Contrasenia = reader.GetString(4);
                    user.Mail = reader.GetString(5);

                    usuarioLogin = user;
                  
                }
            }
             
                return usuarioLogin;

        }

        public static Usuario ObtenerNombreUsuario(string usuario)
        {
            Usuario userNombre = new Usuario();
            using(SqlConnection con = new SqlConnection(conexion))
            {
                SqlCommand comando = new SqlCommand("SELECT * FROM Usuario WHERE @NombreUsuario = NombreUsuario", con);
                comando.Parameters.AddWithValue("@NombreUsuario", usuario);

                con.Open();

                SqlDataReader reader = comando.ExecuteReader();
                if(reader.HasRows)
                {
                    reader.Read();
                    Usuario usuarioNombre = new Usuario();
                    usuarioNombre.Id = reader.GetInt64(0);
                    usuarioNombre.Nombre = reader.GetString(1);
                    usuarioNombre.Apellido = reader.GetString(2);
                    usuarioNombre.NombreUsuario = reader.GetString(3);
                    userNombre = usuarioNombre;
                }
                return userNombre;
            }
        }

        public static Usuario InsertarUsuario(Usuario usuario)
        {
            using (SqlConnection con = new SqlConnection(conexion))
            {
                SqlCommand comando = new SqlCommand();

                comando.Connection = con;
                comando.Connection.Open();
                comando.CommandText = @"INSERT INTO Usuario ([Nombre], [Apellido], [NombreUsuario], [Contrasenia], [Mail]) VALUES(@nombre, @apellido, @nombreUsuario, @contrasenia, @mail)";
                comando.Parameters.AddWithValue("@nombre", usuario.Nombre);
                comando.Parameters.AddWithValue("@apellido", usuario.Apellido);
                comando.Parameters.AddWithValue("@nombreUsuario", usuario.NombreUsuario);
                comando.Parameters.AddWithValue("@contrasenia", usuario.Contrasenia);
                comando.Parameters.AddWithValue("@mail", usuario.Mail);
                comando.ExecuteNonQuery();
                comando.Connection.Close();

            }
            return usuario;
        }


        public static Usuario ModificarUsuario(Usuario usuario)
        {
            using (SqlConnection con = new SqlConnection(conexion))
            {
                SqlCommand comando = new SqlCommand();

                comando.Connection = con;
                comando.Connection.Open();
                comando.CommandText = @"UPDATE Usuario SET [Nombre] = @nombre, [Apellido] = @apellido, [NombreUsuario] = @nombreUsuario, [Contraseña] = @contrasenia, []Mail = @mail WHERE id = @ID";

                comando.Parameters.AddWithValue("@nombre", usuario.Nombre);
                comando.Parameters.AddWithValue("@apellido", usuario.Apellido);
                comando.Parameters.AddWithValue("@nombreUsuario", usuario.NombreUsuario);
                comando.Parameters.AddWithValue("@contraseña", usuario.Contrasenia);
                comando.Parameters.AddWithValue("@mail", usuario.Mail);
                comando.Parameters.AddWithValue("@ID", usuario.Id);
                comando.ExecuteNonQuery();
                comando.Connection.Close();
                




                
            }
            return usuario;
        }

        public static long EliminarUsuario(long id)
        {
            using (SqlConnection con = new SqlConnection(conexion))
            {
                SqlCommand comando = new SqlCommand();

                comando.Connection = con;
                comando.Connection.Open();
                comando.CommandText = @"DELETE [Usuario] WHERE [Id]=@ID";
                comando.Parameters.AddWithValue("@ID", id);
                comando.ExecuteNonQuery();
                comando.Connection.Close();

            }
            return id;

        }

    }
}










