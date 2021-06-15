using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaAcademico
{
	public class ValidaIncr
	{
		public List<Inscr> anotados;
		public void SetearIncr()
		{
			anotados = new List<Inscr>();
			using (FileStream texto = File.OpenRead(@"./ValidaciónInscripción.txt"))
			using (var Anot = new StreamReader(texto))
			{
				string line6;
				Anot.ReadLine();
				while ((line6 = Anot.ReadLine()) != null)
				{
					string alumno = line6.Split('|')[0];
					string ValInc = line6.Split('|')[1];

					Inscr v = new Inscr(alumno, ValInc);
					anotados.Add(v);
				}
			}
		}
	}
}
