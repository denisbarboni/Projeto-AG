

import java.io.BufferedReader;
import java.io.File;
import java.io.FileReader;
import java.util.ArrayList;
import java.util.HashMap;
import java.util.Random;

public class Algoritimo {

    private static int solucao;
    private static double taxaDeCrossover;
    private static double taxaDeMutacao;
    private static String maquinas;
    private static String jobs;
    
    
    public static Populacao novaGeracao(Populacao populacao, boolean elitismo) {
        Random r = new Random();
        //nova população do mesmo tamanho da antiga
        Populacao novaPopulacao = new Populacao(populacao.getTamPopulacao());

        //se tiver elitismo, mantém o melhor indivíduo da geração atual
        if (elitismo) {
            novaPopulacao.setIndividuo(populacao.getIndivduo(0));
        }

        //insere novos indivíduos na nova população, até atingir o tamanho máximo
        while (novaPopulacao.getNumIndividuos() < novaPopulacao.getTamPopulacao()) {
            //seleciona os 2 pais por torneio
            Individuo[] pais = selecaoTorneio(populacao);

            Individuo[] filhos = new Individuo[2];

            //verifica a taxa de crossover, se sim realiza o crossover, se não, mantém os pais selecionados para a próxima geração
            if (r.nextDouble() <= taxaDeCrossover) {
                filhos = crossover(pais[1], pais[0]);
            } else {
                filhos[0] = new Individuo(pais[0].getGenes());
                filhos[1] = new Individuo(pais[1].getGenes());
            }

            //adiciona os filhos na nova geração
            novaPopulacao.setIndividuo(filhos[0]);
            novaPopulacao.setIndividuo(filhos[1]);
        }

        //ordena a nova população
        novaPopulacao.ordenaPopulacao();
        return novaPopulacao;
    }

    // Realiza o crossover de 1 ponto
    public static Individuo[] crossover(Individuo individuo1, Individuo individuo2) {
        Random r = new Random();
        boolean pontoCerto = false;
        int pontoCorte1 = 0;
        
  	        //sorteia o ponto de corte
        	while ( !pontoCerto) {
        		pontoCorte1 = r.nextInt(individuo1.getGenes().length());
        		String tempo = individuo1.getGenes().substring(pontoCorte1, pontoCorte1+1);
        		if ( tempo.matches("[A-Z\\s]") ) { 
        			pontoCerto = true;
        		}
        	}
        	
	        //pega os genes dos pais
	        String genePai1 = individuo1.getGenes();
	        String genePai2 = individuo2.getGenes();
	        
	        Individuo[] filhos = new Individuo[2];
	        
	        String geneFilho1; 
	        String geneFilho2;
	
	        
	        //Gera o primeiro filho. 
	        geneFilho1 = genePai1.substring(0, pontoCorte1+1);      
	        geneFilho1 += genePai2.substring(pontoCorte1+1, genePai1.length());
              
	        //Gera o segundo filho. 
	        geneFilho2 = genePai2.substring(0, pontoCorte1+1);      
	        geneFilho2 += genePai1.substring(pontoCorte1+1, genePai2.length());
	        	
	        //cria o novo indivíduo com os genes dos pais
	        filhos[0] = new Individuo(geneFilho1);
	        filhos[1] = new Individuo(geneFilho2);
	        
	        return filhos;
    }
    


    public static Individuo[] selecaoTorneio(Populacao populacao) {
        Random r = new Random();
        Populacao populacaoIntermediaria = new Populacao(3);

        //seleciona 3 indivíduos aleatóriamente na população
        populacaoIntermediaria.setIndividuo(populacao.getIndivduo(r.nextInt(populacao.getTamPopulacao())));
        populacaoIntermediaria.setIndividuo(populacao.getIndivduo(r.nextInt(populacao.getTamPopulacao())));
        populacaoIntermediaria.setIndividuo(populacao.getIndivduo(r.nextInt(populacao.getTamPopulacao())));

        //ordena a população
        populacaoIntermediaria.ordenaPopulacao();

        Individuo[] pais = new Individuo[2];

        //seleciona os 2 melhores deste população
        pais[0] = populacaoIntermediaria.getIndivduo(0);
        pais[1] = populacaoIntermediaria.getIndivduo(1);

        return pais;
    }

    public static int getSolucao() {
        return solucao;
    }

    public static void setSolucao(int solucao) {
        Algoritimo.solucao = solucao;
    }

    public static double getTaxaDeCrossover() {
        return taxaDeCrossover;
    }

    public static void setTaxaDeCrossover(double taxaDeCrossover) {
        Algoritimo.taxaDeCrossover = taxaDeCrossover;
    }

    public static double getTaxaDeMutacao() {
        return taxaDeMutacao;
    }

    public static void setTaxaDeMutacao(double taxaDeMutacao) {
        Algoritimo.taxaDeMutacao = taxaDeMutacao;
    }

    public static String getMaquinas() {
        return maquinas;
    }

    public static void setMaquinas(String maquinas) {
        if ( !Algoritimo.maquinas.contains(maquinas) ) {
        	Algoritimo.maquinas += maquinas;
        }
    }
    
    public static String getJobs() {
        return jobs;
    }

    public static void setJobs(String jobs) {
    	Algoritimo.jobs += jobs;
    }
    
    public static void lerArquivo() {
	
	try {
		File file = new File("./amendoim.txt");
		BufferedReader bf = new BufferedReader(new FileReader(file));
		String line = null;
		jobs = "";
		maquinas = "";
		
		while((line = bf.readLine()) != null ) {

			String[] vGene = line.split(",");
			setJobs(vGene[0].substring(0, 3));
			setMaquinas(vGene[0].substring(3, 4));

		}
		
		int tamanho = (getJobs().length()/getMaquinas().length());
		Algoritimo.jobs = getJobs().substring(0, tamanho);
		bf.close();
	} 
	catch (Exception e) {
		e.printStackTrace();
	}    			
} 	

    
}