import java.sql.Connection;
import java.sql.ResultSet;
import java.sql.SQLException;

import com.mysql.jdbc.Statement;

public class Trabalho {

    public static void main(String[] args) throws SQLException {

 	
        //Define a solução
        Algoritimo.setSolucao(300);
        // Ler o arquivo com os genes e respectivos valores e configura as variáveis de Jobs e Maquinas que estão no arquivo TXT
        Algoritimo.lerArquivo();
        //taxa de crossover de 60%
        Algoritimo.setTaxaDeCrossover(0.6);
        //taxa de mutação de 3%
        Algoritimo.setTaxaDeMutacao(0.3);
        //elitismo
        boolean eltismo = true;
        //tamanho da população
        int tamPop = 300;
        //numero máximo de gerações
        int numMaxGeracoes = 5000;

        //define o número de genes do indivíduo baseado na solução
        int numGenes = Algoritimo.getJobs().length(); 

        //cria a primeira população aleatória
        Populacao populacao = new Populacao(numGenes, tamPop);

        boolean temSolucao = false;
        int geracao = 0;

        System.out.println("Iniciando... Aptidão da solução: "+Algoritimo.getSolucao());
        
        //loop até o critério de parada
        while (!temSolucao && geracao < numMaxGeracoes) {
            geracao++;

            //cria nova populacao
            populacao = Algoritimo.novaGeracao(populacao, eltismo);

            System.out.println("Geração " + geracao + " | Aptidão: " + populacao.getIndivduo(0).getAptidao() + " | Melhor: " + populacao.getIndivduo(0).getGenes());
            
            
            
            //verifica se tem a solucao
            temSolucao = populacao.temSolocao(Algoritimo.getSolucao());
        }

        if (geracao == numMaxGeracoes) {
            System.out.println("Número Maximo de Gerações | " + populacao.getIndivduo(0).getGenes() + " " + populacao.getIndivduo(0).getAptidao());
        }

        if (temSolucao) {
            System.out.println("Encontrado resultado na geração " + geracao + " | " + populacao.getIndivduo(0).getGenes() + " (Aptidão: " + populacao.getIndivduo(0).getAptidao() + ")");
        }
    }
}