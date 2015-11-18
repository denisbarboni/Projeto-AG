using System;

namespace helloWorldAG
{

	public class Individuo
	{

		private string genes = "";
		private int aptidao = 0;

		//gera um indivíduo aleatório
		public Individuo(int numGenes)
		{
			genes = "";
			Random r = new Random();

			string caracteres = Algoritimo.Caracteres;

			for (int i = 0; i < numGenes; i++)
			{
				genes += caracteres[r.Next(caracteres.Length)];
			}

			geraAptidao();
		}

		//cria um indivíduo com os genes definidos
		public Individuo(string genes)
		{
			this.genes = genes;

			Random r = new Random();
			//se for mutar, cria um gene aleatório
			if (r.NextDouble() <= Algoritimo.TaxaDeMutacao)
			{
				string caracteres = Algoritimo.Caracteres;
				string geneNovo = "";
				int posAleatoria = r.Next(genes.Length);
				for (int i = 0; i < genes.Length; i++)
				{
					if (i == posAleatoria)
					{
						geneNovo += caracteres[r.Next(caracteres.Length)];
					}
					else
					{
						geneNovo += genes[i];
					}

				}
				this.genes = geneNovo;
			}
			geraAptidao();
		}

		//gera o valor de aptidão, será calculada pelo número de bits do gene iguais ao da solução
		private void geraAptidao()
		{
			string solucao = Algoritimo.Solucao;
			for (int i = 0; i < solucao.Length; i++)
			{
				if (solucao[i] == genes[i])
				{
					aptidao++;
				}
			}
		}

		public virtual int Aptidao
		{
			get
			{
				return aptidao;
			}
		}

		public virtual string Genes
		{
			get
			{
				return genes;
			}
		}
	}
}