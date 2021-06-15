using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaAcademico
{
	public class Inscr
	{
		public string Alumno { get; }
		public string ValInc { get; }
		public Inscr(string alumno, string valinc)
		{
			this.Alumno = alumno;
			this.ValInc = valinc;
		}
	}
}
