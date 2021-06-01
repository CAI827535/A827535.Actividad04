using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaAcademico
{
    class Oferta
    {
        public string codigoCurso { get; }

        public string nombreMateria { get; }

        public string titularCurso { get; }

        public string profesorCurso { get; }

        public string diaCurso { get; }


        public List<Oferta> Ofertas = new List<Oferta>();

        public Oferta(string codigoCurso, string nombreMateria, string titularCurso, string profesorCurso, string diaCurso, string horarioCurso)
        {
            this.codigoCurso = codigoCurso;
            this.nombreMateria = nombreMateria;
            this.titularCurso = titularCurso;
            this.profesorCurso = profesorCurso;
            this.diaCurso = diaCurso;
            this.horarioCurso = horarioCurso;
        }

        public Oferta()
        {

        }

        public string horarioCurso { get; }

        public void crearOfertaCalificada()
        {
            using (FileStream texto = File.OpenRead(@"./OfertaCalificada1.txt"))

            using (var OfertaCursos = new StreamReader(texto))
            {
                string line;

                OfertaCursos.ReadLine();
                OfertaCursos.ReadLine();

                while ((line = OfertaCursos.ReadLine()) != null)
                {
                    string codigoCurso = line.Split(';')[1];
                    string nombreMateria = line.Split(';')[0];
                    string TitularCurso = line.Split(';')[0];
                    string ProfesorCurso = line.Split(';')[0];
                    string diaCurso = line.Split(';')[0];
                    string HorarioCurso = line.Split(';')[0];

                    Oferta ofer1 = new Oferta(codigoCurso, nombreMateria, TitularCurso, ProfesorCurso, diaCurso, HorarioCurso);
                    Oferta ofer2 = new Oferta(codigoCurso, nombreMateria, TitularCurso, ProfesorCurso, diaCurso, HorarioCurso);
                    Oferta ofer3 = new Oferta(codigoCurso, nombreMateria, TitularCurso, ProfesorCurso, diaCurso, HorarioCurso);
                    
                    Ofertas.Add(ofer1);
                    Ofertas.Add(ofer2);
                    Ofertas.Add(ofer3);
                }
            }
        }

        public Oferta SeleccionCurso(string IngresoMat1)
        {
            using (FileStream texto = File.OpenRead(@"./OfertaCalificada1.txt"))

            using (var OfertaCursos = new StreamReader(texto))
            {
                string line;

                while ((line = OfertaCursos.ReadLine()) != null)
                {
                    string codigoCurso = line.Split(';')[1];
                    string nombreMateria = line.Split(';')[2];
                    string TitularCurso = line.Split(';')[3];
                    string ProfesorCurso = line.Split(';')[4];
                    string diaCurso = line.Split(';')[5];
                    string HorarioCurso = line.Split(';')[6];

                    Oferta ofer1 = new Oferta(codigoCurso, nombreMateria, TitularCurso, ProfesorCurso, diaCurso, HorarioCurso);
                    Oferta ofer2 = new Oferta(codigoCurso, nombreMateria, TitularCurso, ProfesorCurso, diaCurso, HorarioCurso);
                    Oferta ofer3 = new Oferta(codigoCurso, nombreMateria, TitularCurso, ProfesorCurso, diaCurso, HorarioCurso);

                    if (codigoCurso == IngresoMat1)
                    {
                        return ofer1;
                    }
                }

                return null;           
            }
        }

        public void mostrarOfertaCalificada()
        {
            using (FileStream texto = File.OpenRead(@"./OfertaCalificada.txt"))

            using (var OfertaCursos = new StreamReader(texto))
            {
                string line;
                Console.WriteLine("Cursos disponibles según carrera: ");
                Console.WriteLine();
                Console.WriteLine(OfertaCursos.ReadLine());
                Console.WriteLine(OfertaCursos.ReadLine());
                
                while ((line = OfertaCursos.ReadLine()) != null)
                {
                    Console.WriteLine(line.Replace(";", " "));
                }
            }
        }
    }
}
