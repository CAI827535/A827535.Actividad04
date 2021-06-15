using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaAcademico
{


 class Corre
	{

		public string Mate { get; }

		public string Req { get; }


		public Corre(string Mate, string Req)
		{
			this.Mate = mate;
			this.Req = req;


		}
	

	public class ValidaCorr
	{

		public List<Corre> Correlativas;

		public void SetearCorre()
		{
			Correlativas = new List<Corre>();
			using (FileStream texto = File.OpenRead(@"./Correlativas.txt"))
			using (var cor = new StreamReader(texto))
			{
				string line;
				cor.ReadLine();
				while ((line = cor.ReadLine()) != null)
				{
					string Mate = line.Split('|')[0];
					string Req = line.Split('|')[1];

					Corre f = new Corre(Mate, Req);
					Correlativas.Add(f);

				}
			}
		}
	}
}
}