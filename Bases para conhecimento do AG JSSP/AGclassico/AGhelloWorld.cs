using System;

namespace helloWorldAG
{

	public class AGhelloWorld
	{

		public static void Main(string[] args)
		{

			//Define a solução
			Algoritimo.Solucao = "Algorítimos Genéticos, AGs, são métodos de busca inspirados na evolução dos seres vivos, introduzidos por John Holland e popularizados por um de seus alunos, David Goldberg, seguem o princípio da seleção natural e sobrevivência dos mais aptos, segundo Charles Darwin.";
			//Define os caracteres existentes
			Algoritimo.Caracteres = "!,.:;?áÁãÃâÂõÕôÔóÓéêíÉÊQWERTYUIOPASDFGHJKLÇZXCVBNMqwertyuiopasdfghjklçzxcvbnm1234567890 ";
			//taxa de crossover de 60%
			Algoritimo.TaxaDeCrossover = 0.6;
			//taxa de mutação de 3%
			Algoritimo.TaxaDeMutacao = 0.3;
			//elitismo
			bool eltismo = true;
			//tamanho da população
			int tamPop = 100;
			//numero máximo de gerações
			int numMaxGeracoes = 10000;

			//define o número de genes do indivíduo baseado na solução
			int numGenes = Algoritimo.Solucao.Length;

			//cria a primeira população aleatérioa
			Populacao populacao = new Populacao(numGenes, tamPop);

			bool temSolucao = false;
			int geracao = 0;

			Console.WriteLine("Iniciando... Aptidão da solução: " + Algoritimo.Solucao.Length);

			//loop até o critério de parada
			while (!temSolucao && geracao < numMaxGeracoes)
			{
				geracao++;

				//cria nova populacao
				populacao = Algoritimo.novaGeracao(populacao, eltismo);

				Console.WriteLine("Geração " + geracao + " | Aptidão: " + populacao.getIndivduo(0).Aptidao + " | Melhor: " + populacao.getIndivduo(0).Genes);

				//verifica se tem a solucao
				temSolucao = populacao.temSolocao(Algoritimo.Solucao);
			}

			if (geracao == numMaxGeracoes)
			{
				Console.WriteLine("Número Maximo de Gerações | " + populacao.getIndivduo(0).Genes + " " + populacao.getIndivduo(0).Aptidao);
			}

			if (temSolucao)
			{
				Console.WriteLine("Encontrado resultado na geração " + geracao + " | " + populacao.getIndivduo(0).Genes + " (Aptidão: " + populacao.getIndivduo(0).Aptidao + ")");
			}
		}
	}
}