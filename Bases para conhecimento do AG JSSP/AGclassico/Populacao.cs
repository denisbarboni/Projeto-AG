namespace helloWorldAG
{

	public class Populacao
	{

		private Individuo[] individuos;
		private int tamPopulacao;

		//cria uma população com indivíduos aleatória
		public Populacao(int numGenes, int tamPop)
		{
			tamPopulacao = tamPop;
			individuos = new Individuo[tamPop];
			for (int i = 0; i < individuos.Length; i++)
			{
				individuos[i] = new Individuo(numGenes);
			}
		}

		//cria uma população com indivíduos sem valor, será composto posteriormente
		public Populacao(int tamPop)
		{
			tamPopulacao = tamPop;
			individuos = new Individuo[tamPop];
			for (int i = 0; i < individuos.Length; i++)
			{
				individuos[i] = null;
			}
		}

		//coloca um indivíduo em uma certa posição da população
		public virtual void setIndividuo(Individuo individuo, int posicao)
		{
			individuos[posicao] = individuo;
		}

		//coloca um indivíduo na próxima posição disponível da população
		public virtual Individuo Individuo
		{
			set
			{
				for (int i = 0; i < individuos.Length; i++)
				{
					if (individuos[i] == null)
					{
						individuos[i] = value;
						return;
					}
				}
			}
		}

		//verifoca se algum indivíduo da população possui a solução
		public virtual bool temSolocao(string solucao)
		{
			Individuo i = null;
			for (int j = 0; j < individuos.Length; j++)
			{
				if (individuos[j].Genes.Equals(solucao))
				{
					i = individuos[j];
					break;
				}
			}
			if (i == null)
			{
				return false;
			}
			return true;
		}

		//ordena a população pelo valor de aptidão de cada indivíduo, do maior valor para o menor, assim se eu quiser obter o melhor indivíduo desta população, acesso a posição 0 do array de indivíduos
		public virtual void ordenaPopulacao()
		{
			bool trocou = true;
			while (trocou)
			{
				trocou = false;
				for (int i = 0; i < individuos.Length - 1; i++)
				{
					if (individuos[i].Aptidao < individuos[i + 1].Aptidao)
					{
						Individuo temp = individuos[i];
						individuos[i] = individuos[i + 1];
						individuos[i + 1] = temp;
						trocou = true;
					}
				}
			}
		}

		//número de indivíduos existentes na população
		public virtual int NumIndividuos
		{
			get
			{
				int num = 0;
				for (int i = 0; i < individuos.Length; i++)
				{
					if (individuos[i] != null)
					{
						num++;
					}
				}
				return num;
			}
		}

		public virtual int TamPopulacao
		{
			get
			{
				return tamPopulacao;
			}
		}

		public virtual Individuo getIndivduo(int pos)
		{
			return individuos[pos];
		}
	}
}