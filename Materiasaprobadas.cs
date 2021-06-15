using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaAcademico
{
    public class Materiasaprobadas
    {
        public List<Materia> Aprobadas;

        public void SetearMateriasaprobadas()
        {
            Aprobadas = new List<Materia>();
            
            using (FileStream texto = File.OpenRead(@"./MateriasAprobadasporAlumno.txt"))
            
            using (var Materiasaprobadas = new StreamReader(texto))
            {
                string line;
                
                while ((line = Materiasaprobadas.ReadLine()) != null)
                {
                    string Dni = line.Split(';')[0];
                    string codigoCurso = line.Split(';')[1];
                    string nombreMateria = line.Split(';')[3];

                    Materia mat = new Materia(codigoCurso, nombreMateria, Dni);
                    Aprobadas.Add(mat);
                }
            }
        }

        public bool existePersona(string dni)
        {
            bool resp = false;
            List<Materia> mat = Aprobadas.FindAll(x => x.Dni == dni);
            return resp;
        }
    }
}
