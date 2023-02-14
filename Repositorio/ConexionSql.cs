using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APPI
{

    internal class ConexionSql
    {
        static public ConexionSql conexionSql = new ConexionSql();
        static string conexion = "Data Source = DESKTOP-2FTHB12\\MSSQLSERVER1; Initial Catalog = SistemaGestion; Integrated Security = True; Connect Timeout = 30; Encrypt = False; TrustServerCertificate = False; ApplicationIntent = ReadWrite; MultiSubnetFailover = False";
        private SqlConnection con = new SqlConnection(conexion);
        


        public void GetCommand(SqlCommand comando)
        {
            con.Open();
            comando.Connection = con;
            con.Close();
            
        }


    }

 
      
    
}
