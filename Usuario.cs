using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaAcademico
{
    class Usuario
    {
        public int dni { get; }
        public string contraseña { get; }
        public string nombre { get; }
        public string apellido { get; }
        public int registro { get; }

        public Usuario(int dni, string contraseña, string nombre , string apellido , int registro)
        {
            this.dni = dni;
            this.contraseña = contraseña;
            this.nombre = nombre;
            this.apellido = apellido;
            this.registro = registro;
        }
    }
}
