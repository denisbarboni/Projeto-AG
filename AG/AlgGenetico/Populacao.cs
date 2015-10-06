namespace AlgGenetico
{
    public class Populacao
    {

        private Individuo[] individuos;
        private int tamPopulacao;

        //cria uma popula��o com indiv�duos aleat�ria
        public Populacao(int numGenes, int tamPop)
        {
            tamPopulacao = tamPop;
            individuos = new Individuo[tamPop];
            for (int i = 0; i < individuos.Length; i++)
            {
                individuos[i] = new Individuo(numGenes);
            }
        }

        //cria uma popula��o com indiv�duos sem valor, ser� composto posteriormente
        public Populacao(int tamPop)
        {
            tamPopulacao = tamPop;
            individuos = new Individuo[tamPop];
            for (int i = 0; i < individuos.Length; i++)
            {
                individuos[i] = null;
            }
        }

        //coloca um indiv�duo em uma certa posi��o da popula��o
        public virtual void setIndividuo(Individuo individuo, int posicao)
        {
            individuos[posicao] = individuo;
        }

        //coloca um indiv�duo na pr�xima posi��o dispon�vel da popula��o
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

        //verifoca se algum indiv�duo da popula��o possui a solu��o
        public virtual bool temSolocao(int solucao)
        {
            Individuo i = null;
            for (int j = 0; j < individuos.Length; j++)
            {
                if (individuos[j].Aptidao <= solucao)
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

        //ordena a popula��o pelo valor de aptid�o de cada indiv�duo, do maior valor para o menor, assim se eu quiser obter o melhor indiv�duo desta popula��o, acesso a posi��o 0 do array de indiv�duos
        public virtual void ordenaPopulacao()
        {
            bool trocou = true;
            while (trocou)
            {
                trocou = false;
                for (int i = 0; i < individuos.Length - 1; i++)
                {
                    if (individuos[i].Aptidao > individuos[i + 1].Aptidao)
                    {
                        Individuo temp = individuos[i];
                        individuos[i] = individuos[i + 1];
                        individuos[i + 1] = temp;
                        trocou = true;
                    }
                }
            }
        }

        //n�mero de indiv�duos existentes na popula��o
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