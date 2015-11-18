using System;

using Statement = com.mysql.jdbc.Statement;

public class Trabalho
{

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in .NET:
//ORIGINAL LINE: public static void main(String[] args) throws java.sql.SQLException
	public static void Main(string[] args)
	{


		//Define a solu��o
		Algoritimo.Solucao = 300;
		// Ler o arquivo com os genes e respectivos valores e configura as vari�veis de Jobs e Maquinas que est�o no arquivo TXT
		Algoritimo.lerArquivo();
		//taxa de crossover de 60%
		Algoritimo.TaxaDeCrossover = 0.6;
		//taxa de muta��o de 3%
		Algoritimo.TaxaDeMutacao = 0.3;
		//elitismo
		bool eltismo = true;
		//tamanho da popula��o
		int tamPop = 300;
		//numero m�ximo de gera��es
		int numMaxGeracoes = 5000;

		//define o n�mero de genes do indiv�duo baseado na solu��o
		int numGenes = Algoritimo.Jobs.Length;

		//cria a primeira popula��o aleat�ria
		Populacao populacao = new Populacao(numGenes, tamPop);

		bool temSolucao = false;
		int geracao = 0;

		Console.WriteLine("Iniciando... Aptid�o da solu��o: " + Algoritimo.Solucao);

		//loop at� o crit�rio de parada
		while (!temSolucao && geracao < numMaxGeracoes)
		{
			geracao++;

			//cria nova populacao
			populacao = Algoritimo.novaGeracao(populacao, eltismo);

			Console.WriteLine("Gera��o " + geracao + " | Aptid�o: " + populacao.getIndivduo(0).Aptidao + " | Melhor: " + populacao.getIndivduo(0).Genes);



			//verifica se tem a solucao
			temSolucao = populacao.temSolocao(Algoritimo.Solucao);
		}

		if (geracao == numMaxGeracoes)
		{
			Console.WriteLine("N�mero Maximo de Gera��es | " + populacao.getIndivduo(0).Genes + " " + populacao.getIndivduo(0).Aptidao);
		}

		if (temSolucao)
		{
			Console.WriteLine("Encontrado resultado na gera��o " + geracao + " | " + populacao.getIndivduo(0).Genes + " (Aptid�o: " + populacao.getIndivduo(0).Aptidao + ")");
		}
	}
}