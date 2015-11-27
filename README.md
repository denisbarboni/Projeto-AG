#NOTA DE LIBERAÇÃO: OTIMIZAÇÃO DO PROCESSO DE PRODUÇÃO COM JSSP	
#INTRODUÇÃO
Este documento provê uma visão geral da versão do aplicativo Projeto “Otimização do processo de produção com JSSP” que está sendo liberada. Aqui descreveremos as funcionalidades do aplicativo, bem como seus problemas e limitações conhecidos. Por último são descritas as demandas e os problemas que foram resolvidos para liberação da versão atual.

#NOTA DE RELEASE A SER PUBLICADO
Página inicial do site.<br>
Página inicial da aplicação corrigida.<br>
Cadastro das máquinas, setores, skus, unidades, Jobs e velocidades por usuário.<br>
Execução do Algoritimo sobre os cadastros feitos por usuário.<br>
Demonstração do gráfico.<br>

#PROBLEMAS CONHECIDOS E LIMITAÇÕES
Limitação

O gráfico que será apresentado como resultado não está responsivo, podendo ser um problema ao acessar a aplicação via mobile. (componente utilizado: DevExpress).

#DATAS IMPORTANTES
Segue abaixo as datas importante do desenvolvimento:<br>
01/09/2015	Início do planejamento<br>
10/09/2015	Início da primeira parte do desenvolvimento<br>
29/09/2015	Fim e conclusão dos testes da primeira parte do desenvolvimento<br>
30/09/2015	Início da segunda parte do desenvolvimento<br>
31/10/2015	Fim e conclusão dos testes da segunda parte do desenvolvimento<br>
01/11/2015	Início da terceira parte do desenvolvimento<br>
07/11/2015	Liberação das duas primeiras notas de liberação<br>
17/11/2015	Demonstração da aplicação para o cliente.<br>
24/11/2015	Liberação do acesso a ferramenta de monitoramento.<br>
25/11/2015	Liberação do acesso a ferramenta de log.<br>
26/11/2015	Liberação da terceira e ultima nota de liberação<br>

#COMPATIBILIDADE

Segue abaixo os requisitos:<br>
Requisitos	Ferramentas

Navegadores	Browser:<br>
•	Mozila Firefox<br>
•	Chrome<br>
•	Internet Explorer<br>
•	Microsoft Edge<br>
Versões	Necessário a mais atual ou compatível com HTML5, CSS3 e JS<br>

Tecnologias<bR>
Linguagem de programação	ASP.NET, C#, JS<br>
Framework WEB	Bootstrap, DevExpress, Jquery<br>
IDE 	Microsoft Visual Studio 2015 Enterprise<br>
Design pattern	ADO.NET<br>
Servidor Web	Azure<br>

#PROCEDIMENTO E ALTERAÇAO DE CONFIGURAÇÃO DO AMBIENTE
Para implantação do projeto é necessário a configurações de um servidor WEB para hospedagem da aplicação e um servidor de banco de dados. A configuração da aplicação é somente a comunicação com o banco de dados. Feito isso, o sistema estará pronto para utilização.

#ATIVIDADES REALIZADAS NO PERÍODO
Nessa liberação foram contemplados os seguintes itens:
Cód 	Título	Tarefa	Situação	Observação
1	Esboço da página inicial	Layout para montagem da página inicial do sistema	Concluído	
2	Login do usuário no serviço prestado	Acesso ao serviço onde o usuário poderá logar com seu usuário e senha para cadastrar os dados necessários para a ação do algoritimo genético.	Concluído	
3	Cadastro das máquinas, setores, unidades, skus, Jobs e velocidades usadas no algoritimo genético	Disponibilizar o acesso do usuário nas opções de cadastro do sistema, onde o mesmo poderá cadastrar as informações necessárias para a execução do algoritimo genético futuramente.
	Concluído	
4	Execução do algoritimo genético.	Disponibilizar o acesso do usuário junto ao algoritimo genético, onde o mesmo irá apurar a melhor solução de acordo com as configurações definidas.	Concluido 	
5	Disponibilização da aplicação no Servidor Web	Disponibilizar acesso por meio do servidor web	Concluído	
6	Acesso as ferrametas administrativas	Disponibilizar acesso para as ferramentas administrativas	Concluído parcialmente	Falta configurar o logentries 
7.	FERRAMENTA DE MONITORAMENTO
A ferramenta de monitoramento escolhida para a aplicação é o New Relic. Trata-se de uma ferramenta multi-plataforma (PHP, Java, .NET, Ruby e Python) capaz de monitorar, este caso, a a aplicação.
O principal propósito do New Relic é auxiliar no diagnóstico de possíveis problemas no código da aplicação, facilitando a identificação de gargalos que prejudiquem sua performance. A partir de gráficos de desempenho de fácil compreensão, é possível acompanhar resumos dos tempos de resposta da aplicação, transações com o banco de dados, conexões com serviços externos, visualizar relatórios de disponibilidade e de erros recorrentes, configurar alertas, entre outros.
A Integração com a aplicação foi teoricamente simples, pois, como para a aplicação está sendo usado um servidor da Microsoft, o Azure, add-ons podem ser adicionados na aplicação com certa facilidade.
O acesso na ferramenta é feita pelo site HTTP://RPM.NEWRELIC.COM, pois se trata de um serviço SaaS.
8.	FERRAMENTA DE LOG
A ferramenta de log escolhida para a aplicação foi o uso de FTP e também do Logentries. O log entries trata-se de uma ferramenta que auxilia o desenvolvedor a ver os logs da aplicação em tempo real e de forma analítica.
Já o acesso via FTP mostra os logs crus, ou seja, não existe ferramenta para deixar de forma analítica os logs, porém, esses logs são bem completos, pois se trata do recurso do próprio Azure.
9.	TESTE
Os testes realizados foram decorrentes para mostrar o funcionamento da aplicação, utilizando a ferramenta Selenium IDE, onde foram realizados testes automatizados.
