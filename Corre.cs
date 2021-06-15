using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaAcademico
{
    public class Corre
    {      
        public string mate { get; }
        public string req { get; }
        public string Carre { get; }
        public Corre(string mate, string req, string Carre)
        {
            this.mate = mate;
            this.req = req;
            this.Carre = Carre;
        }
    }
}
