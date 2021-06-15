using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaAcademico
{
    public class Materia
    {
        public string Dni { get; }
        public string codigoCurso { get; }
        public string nombreMateria { get; }

        public Materia(string codigoCurso, string nombreMateria, string Dni)
        {
            this.codigoCurso = codigoCurso;
            this.nombreMateria = nombreMateria;
            this.Dni = Dni;
        }
    }

}