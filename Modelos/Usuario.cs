using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APPI
{
    public class Usuario
    {
        private long id;
        private string nombre;
        private string apellido;
        private string nombreUsuario;
        private string contrasenia;
        private string mail;

        public long Id { get => id; set => id = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public string Apellido { get => apellido; set => apellido = value; }
        public string NombreUsuario { get => nombreUsuario; set => nombreUsuario = value; }
        public string Contrasenia { get => contrasenia; set => contrasenia = value; }
        public string Mail { get => mail; set => mail = value; }
    }
}
