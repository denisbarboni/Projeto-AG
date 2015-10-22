using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AlgGenetico;
using System.Web.UI.DataVisualization.Charting;
using System.IO;

namespace WebApp
{
    public partial class index : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        private void executaAlgGenetico()
        {
            //Define a solu��o
            AlgGenetico.Algoritimo.Solucao = 100000;
            // Ler o arquivo com os genes e respectivos valores e configura as vari�veis de Jobs e Maquinas que est�o no arquivo TXT
            AlgGenetico.Algoritimo.lerArquivo(1);
            //taxa de crossover de 60%
            AlgGenetico.Algoritimo.TaxaDeCrossover = 0.6;
            //taxa de muta��o de 3%
            AlgGenetico.Algoritimo.TaxaDeMutacao = 0.3;
            //elitismo
            bool eltismo = true;
            //tamanho da popula��o
            int tamPop = 10;
            //numero m�ximo de gera��es
            int numMaxGeracoes = 5000;

            //define o n�mero de genes do indiv�duo baseado na solu��o
            int numGenes = AlgGenetico.Algoritimo.Jobs.Length;

            //cria a primeira popula��o aleat�ria
            AlgGenetico.Populacao populacao = new AlgGenetico.Populacao(numGenes, tamPop);

            bool temSolucao = false;
            int geracao = 0;

            //Console.WriteLine("Iniciando... Aptid�o da solu��o: " + Algoritimo.Solucao);
            Label1.Text = "Iniciando... Aptid�o da solu��o: " + AlgGenetico.Algoritimo.Solucao;

            //loop at� o crit�rio de parada
            while (!temSolucao && geracao < numMaxGeracoes)
            {
                geracao++;

                //cria nova populacao
                populacao = AlgGenetico.Algoritimo.novaGeracao(populacao, eltismo);

                //Console.WriteLine("Gera��o " + geracao + " | Aptid�o: " + populacao.getIndivduo(0).Aptidao + " | Melhor: " + populacao.getIndivduo(0).Genes);
                Label2.Text = "Gera��o " + geracao + " | Aptid�o: " + populacao.getIndivduo(0).Aptidao + " | Melhor: " + populacao.getIndivduo(0).Genes;

                //verifica se tem a solucao
                temSolucao = populacao.temSolocao(AlgGenetico.Algoritimo.Solucao);
            }

            if (geracao == numMaxGeracoes)
            {
                //Console.WriteLine("N�mero Maximo de Gera��es | " + populacao.getIndivduo(0).Genes + " " + populacao.getIndivduo(0).Aptidao);
                Label3.Text = "N�mero Maximo de Gera��es | " + populacao.getIndivduo(0).Genes + " " + populacao.getIndivduo(0).Aptidao;
            }

            if (temSolucao)
            {

                //Console.WriteLine("Encontrado resultado na gera��o " + geracao + " | " + populacao.getIndivduo(0).Genes + " (Aptid�o: " + populacao.getIndivduo(0).Aptidao + ")");
                Label4.Text = "Encontrado resultado na gera��o " + geracao + " | ";

                var teste = populacao.getIndivduo(0).Genes;

                // Create new data series and set it's visual attributes
                Series series = new Series("StrackedBar");
                series.ChartType = SeriesChartType.StackedBar;
                series.BorderWidth = 3;
                series.ShadowOffset = 2;

                for (int i = 0; i < teste.Length - 3; i++)
                {
                    string separaJobMaq = teste.Substring(i, 4);
                    Label4.Text += separaJobMaq.Substring(0, 3) + " - " + separaJobMaq.Substring(3, 1) + "<br>";
                    i += 3;

                    int condParada = 0;

                    for (int j = 0; j < series.Points.Count; j++)
                    {
                        condParada = 0;
                        if (series.Points[j].Label.Equals(separaJobMaq.Substring(3, 1)))
                        {
                            condParada = 1;
                            double[] ed = series.Points[j].YValues;
                            ed[0] += populacao.getIndivduo(0).getCustoMaquina(separaJobMaq);
                            series.Points[j].YValues = ed;
                        }
                    }

                    if (condParada == 0)
                    {
                        double[] ins = new double[2];
                        ins[0] = populacao.getIndivduo(0).getCustoMaquina(separaJobMaq);

                        series.Points.Add(new DataPoint()
                        {
                            Label = separaJobMaq.Substring(3, 1),
                            YValues = ins
                        });
                    }
                }

                Chart1.Series.Add(series);
                Chart1.ChartAreas[0].AxisX.Enabled = AxisEnabled.False;
            }
        }

        protected void btnVaiAlg_ServerClick(object sender, EventArgs e)
        {
            executaAlgGenetico();
        }
    }
}