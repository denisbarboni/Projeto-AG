using System;

namespace helloWorldAG
{

	public class Algoritimo
	{

		private static string solucao;
		private static double taxaDeCrossover;
		private static double taxaDeMutacao;
		private static string caracteres;

		public static Populacao novaGeracao(Populacao populacao, bool elitismo)
		{
			Random r = new Random();
			//nova população do mesmo tamanho da antiga
			Populacao novaPopulacao = new Populacao(populacao.TamPopulacao);

			//se tiver elitismo, mantém o melhor indivíduo da geração atual
			if (elitismo)
			{
				novaPopulacao.Individuo = populacao.getIndivduo(0);
			}

			//insere novos indivíduos na nova população, até atingir o tamanho máximo
			while (novaPopulacao.NumIndividuos < novaPopulacao.TamPopulacao)
			{
				//seleciona os 2 pais por torneio
				Individuo[] pais = selecaoTorneio(populacao);

				Individuo[] filhos = new Individuo[2];

				//verifica a taxa de crossover, se sim realiza o crossover, se não, mantém os pais selecionados para a próxima geração
				if (r.NextDouble() <= taxaDeCrossover)
				{
					filhos = crossover(pais[1], pais[0]);
				}
				else
				{
					filhos[0] = new Individuo(pais[0].Genes);
					filhos[1] = new Individuo(pais[1].Genes);
				}

				//adiciona os filhos na nova geração
				novaPopulacao.Individuo = filhos[0];
				novaPopulacao.Individuo = filhos[1];
			}

			//ordena a nova população
			novaPopulacao.ordenaPopulacao();
			return novaPopulacao;
		}

		public static Individuo[] crossover(Individuo individuo1, Individuo individuo2)
		{
			Random r = new Random();

			//sorteia o ponto de corte
			int pontoCorte1 = r.Next((individuo1.Genes.Length / 2) - 2) + 1;
			int pontoCorte2 = r.Next((individuo1.Genes.Length / 2) - 2) + individuo1.Genes.Length / 2;

			Individuo[] filhos = new Individuo[2];

			//pega os genes dos pais
			string genePai1 = individuo1.Genes;
			string genePai2 = individuo2.Genes;

			string geneFilho1;
			string geneFilho2;

			//realiza o corte, 
			geneFilho1 = genePai1.Substring(0, pontoCorte1);
			geneFilho1 += genePai2.Substring(pontoCorte1, pontoCorte2 - pontoCorte1);
			geneFilho1 += genePai1.Substring(pontoCorte2, genePai1.Length - pontoCorte2);

			geneFilho2 = genePai2.Substring(0, pontoCorte1);
			geneFilho2 += genePai1.Substring(pontoCorte1, pontoCorte2 - pontoCorte1);
			geneFilho2 += genePai2.Substring(pontoCorte2, genePai2.Length - pontoCorte2);

			//cria o novo indivíduo com os genes dos pais
			filhos[0] = new Individuo(geneFilho1);
			filhos[1] = new Individuo(geneFilho2);

			return filhos;
		}

		public static Individuo[] selecaoTorneio(Populacao populacao)
		{
			Random r = new Random();
			Populacao populacaoIntermediaria = new Populacao(3);

			//seleciona 3 indivíduos aleatóriamente na população
			populacaoIntermediaria.Individuo = populacao.getIndivduo(r.Next(populacao.TamPopulacao));
			populacaoIntermediaria.Individuo = populacao.getIndivduo(r.Next(populacao.TamPopulacao));
			populacaoIntermediaria.Individuo = populacao.getIndivduo(r.Next(populacao.TamPopulacao));

			//ordena a população
			populacaoIntermediaria.ordenaPopulacao();

			Individuo[] pais = new Individuo[2];

			//seleciona os 2 melhores deste população
			pais[0] = populacaoIntermediaria.getIndivduo(0);
			pais[1] = populacaoIntermediaria.getIndivduo(1);

			return pais;
		}

		public static string Solucao
		{
			get
			{
				return solucao;
			}
			set
			{
				Algoritimo.solucao = value;
			}
		}


		public static double TaxaDeCrossover
		{
			get
			{
				return taxaDeCrossover;
			}
			set
			{
				Algoritimo.taxaDeCrossover = value;
			}
		}


		public static double TaxaDeMutacao
		{
			get
			{
				return taxaDeMutacao;
			}
			set
			{
				Algoritimo.taxaDeMutacao = value;
			}
		}


		public static string Caracteres
		{
			get
			{
				return caracteres;
			}
			set
			{
				Algoritimo.caracteres = value;
			}
		}



	}
}