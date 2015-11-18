
public class Populacao {

    private Individuo[] individuos;
    private int tamPopulacao;

    //cria uma popula��o com indiv�duos aleat�ria
    public Populacao(int numGenes, int tamPop) {
        tamPopulacao = tamPop;
        individuos = new Individuo[tamPop];
        for (int i = 0; i < individuos.length; i++) {
            individuos[i] = new Individuo(numGenes);
        }
    }

    //cria uma popula��o com indiv�duos sem valor, ser� composto posteriormente
    public Populacao(int tamPop) {
        tamPopulacao = tamPop;
        individuos = new Individuo[tamPop];
        for (int i = 0; i < individuos.length; i++) {
            individuos[i] = null;
        }
    }

    //coloca um indiv�duo em uma certa posi��o da popula��o
    public void setIndividuo(Individuo individuo, int posicao) {
        individuos[posicao] = individuo;
    }

    //coloca um indiv�duo na pr�xima posi��o dispon�vel da popula��o
    public void setIndividuo(Individuo individuo) {
        for (int i = 0; i < individuos.length; i++) {
            if (individuos[i] == null) {
                individuos[i] = individuo;
                return;
            }
        }
    }

    //verifoca se algum indiv�duo da popula��o possui a solu��o
    public boolean temSolocao(int solucao) {
        Individuo i = null;
        for (int j = 0; j < individuos.length; j++) {
            if (individuos[j].getAptidao() <= solucao) {
                i = individuos[j];
                break;
            }
        }
        if (i == null) {
            return false;
        }
        return true;
    }

    //ordena a popula��o pelo valor de aptid�o de cada indiv�duo, do maior valor para o menor, assim se eu quiser obter o melhor indiv�duo desta popula��o, acesso a posi��o 0 do array de indiv�duos
    public void ordenaPopulacao() {
        boolean trocou = true;
        while (trocou) {
            trocou = false;
            for (int i = 0; i < individuos.length - 1; i++) {
                if (individuos[i].getAptidao() > individuos[i + 1].getAptidao()) {
                    Individuo temp = individuos[i];
                    individuos[i] = individuos[i + 1];
                    individuos[i + 1] = temp;
                    trocou = true;
                }
            }
        }
    }

    //n�mero de indiv�duos existentes na popula��o
    public int getNumIndividuos() {
        int num = 0;
        for (int i = 0; i < individuos.length; i++) {
            if (individuos[i] != null) {
                num++;
            }
        }
        return num;
    }

    public int getTamPopulacao() {
        return tamPopulacao;
    }

    public Individuo getIndivduo(int pos) {
        return individuos[pos];
    }
}