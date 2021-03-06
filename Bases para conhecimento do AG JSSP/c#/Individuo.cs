﻿using System;
using System.Collections;

public class Individuo
{

	private string genes = "";
	private double aptidao = 0;

	//gera um indiv�duo aleat�rio
	public Individuo(int numGenes)
	{
		genes = "";
		Random r = new Random();

		string maquinas = Algoritimo.Maquinas;
		string jobs = Algoritimo.Jobs;
		string escolhido;

		escolhido = "";

		for (int i = 0; i < numGenes; i += 3)
		{

			 escolhido += jobs.Substring(i, 3);
			 escolhido += maquinas[r.Next(maquinas.Length)];
		}
		this.genes = escolhido;
		geraAptidao();
	}

	//cria um indiv�duo com os genes definidos
	public Individuo(string genes)
	{
		this.genes = genes;
		bool pontoCerto = false;
		string geneNovo = "";
		int posAleatoria = 0;

		Random r = new Random();
		//se for mutar, cria um gene aleat�rio
		if (r.NextDouble() <= Algoritimo.TaxaDeMutacao)
		{

			string maquinas = Algoritimo.Maquinas;
			  //sorteia o ponto de corte
			while (!pontoCerto)
			{
				posAleatoria = r.Next(genes.Length);
				string tempo = genes.Substring(posAleatoria, 1);
				if (tempo.matches("[A-Z\\s]"))
				{
					pontoCerto = true;
				}
			}

			for (int i = 0; i < genes.Length; i++)
			{
				if (i == posAleatoria)
				{
					geneNovo += maquinas[r.Next(maquinas.Length)];
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

	//gera o valor de aptid�o, ser� calculada buscando o caminho critico do cromossomo
	private void geraAptidao()
	{

		double valorGene = 0.00;
		Hashtable custo;

		// Pensar como colocar isso din�mico!
		double maquinaA = 0;
		double maquinaB = 0;
		double maquinaC = 0;
		double maquinaD = 0;
		double maquinaE = 0;
		double maquinaF = 0;
		double maquinaG = 0;
		double maquinaH = 0;
		double maquinaI = 0;
		double maquinaJ = 0;
		double maquinaK = 0;
		double maquinaL = 0;
		double maquinaM = 0;
		double maquinaN = 0;
		double maquinaO = 0;
		double maquinaP = 0;
		double maquinaQ = 0;
		double maquinaR = 0;
		double maquinaS = 0;

		custo = new Hashtable();

		try
		{
			File file = new File("./amendoim.txt");
			System.IO.StreamReader bf = new System.IO.StreamReader(file);
			string line = null;

			while ((line = bf.ReadLine()) != null)
			{
				string[] vGene = line.Split(",", true);
				custo[vGene[0]] = vGene[1];
			}

			bf.Close();
		}
		catch (Exception e)
		{
			Console.WriteLine(e.ToString());
			Console.Write(e.StackTrace);
		}
// Solu��o = 463		
//		genes = "001E002H003B004G005E006H007D008E009E010H011H012E013G014E015H016D017H018D019D020B021E022B023E024F025A026E027H028D029E030B031B032G033E034H035D036G037E038C039H040E041C042E043H044G045H046H047C048B049E050B051E052F053A054E055H056D057E058H059B060G061E062H063E064C065E066C067H068E069E070E071A072D073H074D075C076A077E078B079E080F081A082E083H084C085E086H087B088G089E090H091D092D093E094E095A096E097D098E099H100E101H102G103C104A105D106B107E108F109A110E111H112G113E114D115E116E117G118G119G";
		for (int i = 0; i < genes.Length; i += 4)
		{

			switch (genes.Substring(i + 3, i + 4 - (i + 3)))
			{
			case "A":
				valorGene = double.Parse((string) custo[genes.Substring(i, 4)]);
				maquinaA += valorGene;
				break;
			case "B":
				valorGene = double.Parse((string) custo[genes.Substring(i, 4)]);
				maquinaB += valorGene;
				break;
			case "C":
				valorGene = double.Parse((string) custo[genes.Substring(i, 4)]);
				maquinaC += valorGene;
				break;
			case "D":
				valorGene = double.Parse((string) custo[genes.Substring(i, 4)]);
				maquinaD += valorGene;
				break;
			case "E":
				valorGene = double.Parse((string) custo[genes.Substring(i, 4)]);
				maquinaE += valorGene;
				break;
			case "F":
				valorGene = double.Parse((string) custo[genes.Substring(i, 4)]);
				maquinaF += valorGene;
				break;
			case "G":
				valorGene = double.Parse((string) custo[genes.Substring(i, 4)]);
				maquinaG += valorGene;
				break;
			case "H":
				valorGene = double.Parse((string) custo[genes.Substring(i, 4)]);
				maquinaH += valorGene;
				break;
			case "I":
				valorGene = double.Parse((string) custo[genes.Substring(i, 4)]);
				maquinaI += valorGene;
				break;
			case "J":
				valorGene = double.Parse((string) custo[genes.Substring(i, 4)]);
				maquinaJ += valorGene;
				break;
			case "K":
				valorGene = double.Parse((string) custo[genes.Substring(i, 4)]);
				maquinaK += valorGene;
				break;
			case "L":
				valorGene = double.Parse((string) custo[genes.Substring(i, 4)]);
				maquinaL += valorGene;
				break;
			case "M":
				valorGene = double.Parse((string) custo[genes.Substring(i, 4)]);
				maquinaM += valorGene;
				break;
			case "N":
				valorGene = double.Parse((string) custo[genes.Substring(i, 4)]);
				maquinaN += valorGene;
				break;
			case "O":
				valorGene = double.Parse((string) custo[genes.Substring(i, 4)]);
				maquinaO += valorGene;
				break;
			case "P":
				valorGene = double.Parse((string) custo[genes.Substring(i, 4)]);
				maquinaP += valorGene;
				break;
			case "Q":
				valorGene = double.Parse((string) custo[genes.Substring(i, 4)]);
				maquinaQ += valorGene;
				break;
			case "R":
				valorGene = double.Parse((string) custo[genes.Substring(i, 4)]);
				maquinaR += valorGene;
				break;
			case "S":
				valorGene = double.Parse((string) custo[genes.Substring(i, 4)]);
				maquinaS += valorGene;
				break;
			default:
				break;
			}
//			System.out.println(genes.substring(i, i+4)+";"+valorGene+";");
		}
		aptidao = maquinaA > maquinaB ? maquinaA : maquinaB;
		aptidao = aptidao > maquinaC ? aptidao:maquinaC;
		 aptidao = aptidao > maquinaD ? aptidao:maquinaD;
		 aptidao = aptidao > maquinaE ? aptidao:maquinaE;
		 aptidao = aptidao > maquinaF ? aptidao:maquinaF;
		 aptidao = aptidao > maquinaG ? aptidao:maquinaG;
		 aptidao = aptidao > maquinaH ? aptidao:maquinaH;
		 aptidao = aptidao > maquinaI ? aptidao:maquinaI;
		 aptidao = aptidao > maquinaJ ? aptidao:maquinaJ;
		 aptidao = aptidao > maquinaK ? aptidao:maquinaK;
		 aptidao = aptidao > maquinaL ? aptidao:maquinaL;
		 aptidao = aptidao > maquinaM ? aptidao:maquinaM;
		 aptidao = aptidao > maquinaN ? aptidao:maquinaN;
		 aptidao = aptidao > maquinaO ? aptidao:maquinaO;
		 aptidao = aptidao > maquinaP ? aptidao:maquinaP;
		 aptidao = aptidao > maquinaQ ? aptidao:maquinaQ;
		 aptidao = aptidao > maquinaR ? aptidao:maquinaR;
		 aptidao = aptidao > maquinaS ? aptidao:maquinaS;

	}

	public virtual double Aptidao
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
