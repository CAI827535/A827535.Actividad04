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

        public Usuario(int dni, string contraseña)
        {
            this.dni = dni;
            this.contraseña = contraseña;
        }
    }
}
