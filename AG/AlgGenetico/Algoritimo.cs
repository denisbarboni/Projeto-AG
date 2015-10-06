using System;
using System.IO;
using System.Text.RegularExpressions;

namespace AlgGenetico
{
    public static class Algoritimo
    {

        public static int solucao;
        public static double taxaDeCrossover;
        public static double taxaDeMutacao;
        public static string maquinas;
        public static string jobs;


        public static Populacao novaGeracao(Populacao populacao, bool elitismo)
        {
            Random r = new Random();
            //nova popula��o do mesmo tamanho da antiga
            Populacao novaPopulacao = new Populacao(populacao.TamPopulacao);

            //se tiver elitismo, mant�m o melhor indiv�duo da gera��o atual
            if (elitismo)
            {
                novaPopulacao.Individuo = populacao.getIndivduo(0);
            }

            //insere novos indiv�duos na nova popula��o, at� atingir o tamanho m�ximo
            while (novaPopulacao.NumIndividuos < novaPopulacao.TamPopulacao)
            {
                //seleciona os 2 pais por torneio
                Individuo[] pais = selecaoTorneio(populacao);

                Individuo[] filhos = new Individuo[2];

                //verifica a taxa de crossover, se sim realiza o crossover, se n�o, mant�m os pais selecionados para a pr�xima gera��o
                if (r.NextDouble() <= taxaDeCrossover)
                {
                    filhos = crossover(pais[1], pais[0]);
                }
                else
                {
                    filhos[0] = new Individuo(pais[0].Genes);
                    filhos[1] = new Individuo(pais[1].Genes);
                }

                //adiciona os filhos na nova gera��o
                novaPopulacao.Individuo = filhos[0];
                novaPopulacao.Individuo = filhos[1];
            }

            //ordena a nova popula��o
            novaPopulacao.ordenaPopulacao();
            return novaPopulacao;
        }

        // Realiza o crossover de 1 ponto
        public static Individuo[] crossover(Individuo individuo1, Individuo individuo2)
        {
            Random r = new Random();
            bool pontoCerto = false;
            int pontoCorte1 = 0;

            //sorteia o ponto de corte
            while (!pontoCerto)
            {
                pontoCorte1 = r.Next(individuo1.Genes.Length);
                string tempo = individuo1.Genes.Substring(pontoCorte1, 1);
                Match matchTempo = Regex.Match(tempo, "[A-Z\\s]");
                if (matchTempo.Success)
                {
                    pontoCerto = true;
                }
            }

            //pega os genes dos pais
            string genePai1 = individuo1.Genes;
            string genePai2 = individuo2.Genes;

            Individuo[] filhos = new Individuo[2];

            string geneFilho1;
            string geneFilho2;


            //Gera o primeiro filho. 
            geneFilho1 = genePai1.Substring(0, pontoCorte1 + 1);
            geneFilho1 += genePai2.Substring(pontoCorte1 + 1, genePai1.Length - (pontoCorte1 + 1));

            //Gera o segundo filho. 
            geneFilho2 = genePai2.Substring(0, pontoCorte1 + 1);
            geneFilho2 += genePai1.Substring(pontoCorte1 + 1, genePai2.Length - (pontoCorte1 + 1));

            //cria o novo indiv�duo com os genes dos pais
            filhos[0] = new Individuo(geneFilho1);
            filhos[1] = new Individuo(geneFilho2);

            return filhos;
        }



        public static Individuo[] selecaoTorneio(Populacao populacao)
        {
            Random r = new Random();
            Populacao populacaoIntermediaria = new Populacao(3);

            //seleciona 3 indiv�duos aleat�riamente na popula��o
            populacaoIntermediaria.Individuo = populacao.getIndivduo(r.Next(populacao.TamPopulacao));
            populacaoIntermediaria.Individuo = populacao.getIndivduo(r.Next(populacao.TamPopulacao));
            populacaoIntermediaria.Individuo = populacao.getIndivduo(r.Next(populacao.TamPopulacao));

            //ordena a popula��o
            populacaoIntermediaria.ordenaPopulacao();

            Individuo[] pais = new Individuo[2];

            //seleciona os 2 melhores deste popula��o
            pais[0] = populacaoIntermediaria.getIndivduo(0);
            pais[1] = populacaoIntermediaria.getIndivduo(1);

            return pais;
        }

        public static int Solucao
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


        public static string Maquinas
        {
            get
            {
                return maquinas;
            }
            set
            {
                if (!Algoritimo.maquinas.Contains(value))
                {
                    Algoritimo.maquinas += value;
                }
            }
        }


        public static string Jobs
        {
            get
            {
                return jobs;
            }
            set
            {
                Algoritimo.jobs += value;
            }
        }


        public static void lerArquivo()
        {

            try
            {
                StreamReader file = new StreamReader("C:/Users/dbsbo/Desktop/amendoim2.txt");
                string line = null;
                jobs = "";
                maquinas = "";

                while ((line = file.ReadLine()) != null)
                {

                    string[] vGene = line.Split(',');
                    Jobs = vGene[0].Substring(0, 3);
                    Maquinas = vGene[0].Substring(3, 1);

                }

                int tamanho = (Jobs.Length / Maquinas.Length);
                Algoritimo.jobs = Jobs.Substring(0, tamanho);
                file.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
                Console.Write(e.StackTrace);
            }
        }   
    }
}