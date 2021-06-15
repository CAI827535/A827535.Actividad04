using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaAcademico
{
    public class ValidaCorr
    {
        public List<Corre> Correlativas;

        public void SetearCorre()
        {
            Correlativas = new List<Corre>();
            
            using (FileStream texto1 = File.OpenRead(@"./Correlativas.txt"))
            
            using (var cor = new StreamReader(texto1))
            {
                string line2;
                cor.ReadLine();
                
                while ((line2 = cor.ReadLine()) != null)
                {
                    string Carre = line2.Split(';')[0];
                    string mate = line2.Split(';')[1];
                    string req = line2.Split(';')[2];

                    Corre f = new Corre(mate, req, Carre);
                    Correlativas.Add(f);
                }
            }
        }

        public bool tienecorrelativas(string mate, string carrera)
        {
            bool data = Correlativas.Exists(x=>x.mate==mate && x.Carre==carrera);
            return data;
        }

        public bool TieneTodasLascorrelativas(string mate, string carrera, List<Materia> materias)
        {
            List<Corre> data = Correlativas.Where(x => x.mate == mate && (x.Carre == carrera || carrera=="carrera")).ToList();
           foreach(Corre corre in data)
           {
                if (!materias.Exists(x => x.nombreMateria == corre.req))
                return false;
           }
            return true;
        }
    }
}