NOTA DE LIBERAÇÃO: OTIMIZAÇÃO DO PROCESSO DE PRODUÇÃO COM JSSP	

INTRODUÇÃO

Este documento provê uma visão geral da versão do aplicativo Projeto “Otimização do processo de produção com JSSP” que está sendo liberada. Aqui descreveremos as funcionalidades do aplicativo, bem como seus problemas e limitações conhecidos. Por último são descritas as demandas e os problemas que foram resolvidos para liberação da versão atual.

NOTA DE RELEASE A SER PUBLICADO

Página inicial da aplicação.<br>
Cadastro das máquinas, setores, skus, unidades, Jobs e velocidades por usuário.<br>
Execução parcial do Algoritimo sobre os cadastros feitos por usuário.

PROBLEMAS CONHECIDOS E LIMITAÇÕES

O sistema suporta chega a consumir até 200 MB de memória do servidor por algoritimo rodando, podendo várias da quantidade de cadastro e da quantidade de populações estipulada pelo próprio usuário da aplicação.<br>
O tempo de espera até que o algoritimo seja concluído é alto, podendo váriar de acordo com a quantidade de cadastros realizados pelo usuário.<br>
O gráfico que será apresentado como resultado não está responsivo, podendo ser um problema ao acessar a aplicação via mobile. (componente utilizado: DevExpress)

DATAS IMPORTANTES

Segue abaixo as datas importante do desenvolvimento:<br>
Data	    Evento

01/09/2015	Início do planejamento<br>
10/09/2015	Início da primeira parte do desenvolvimento<br>
29/09/2015	Fim e conclusão dos testes da primeira parte do desenvolvimento<br>
30/09/2015	Início da segunda parte do desenvolvimento<br>
31/10/2015	Fim e conclusão dos testes da segunda parte do desenvolvimento<br>
07/11/2015  Liberação das duas primeiras notas.

COMPATIBILIDADE

Segue abaixo os requisitos:

Requisitos Ferramentas

Navegadores	Browser: Mozila Firefox; Chrome; Internet Explorer; Microsoft Edge

Versões: Necessário a mais atual ou compatível com HTML5, CSS3 e JS

Tecnologias

Linguagem de programação: ASP.NET, C#, JS<br>
Framework WEB: Bootstrap, DevExpress, Jquery<br>
IDE: Microsoft Visual Studio 2015 Enterprise<br>
Design pattern: ADO.NET<br>
Servidor Web: A Definir<br>

PROCEDIMENTO E ALTERAÇAO DE CONFIGURAÇÃO DO AMBIENTE

Para implantação do projeto é necessário a configurações de um servidor WEB para hospedagem da aplicação e um servidor de banco de dados. A configuração da aplicação é somente a comunicação com o banco de dados. Feito isso, o sistema estará pronto para utilização.

ATIVIDADES REALIZADAS NO PERÍODO

Nessa liberação foram contemplados os seguintes itens:

Cód - Título - Tarefa - Situação - Observação<br>
1 - Esboço da página inicial - Layout para montagem da página inicial do sistema - Concluído<br>
2 - Login do usuário no serviço prestado - Acesso ao serviço onde o usuário poderá logar com seu usuário e senha para cadastrar os dados necessários para a ação do algoritimo genético. - Concluído<br>
3 - Cadastro das máquinas, setores, unidades, skus, Jobs e velocidades usadas no algoritimo genético - Disponibilizar o acesso do usuário nas opções de cadastro do sistema, onde o mesmo poderá cadastrar as informações necessárias para a execução do algoritimo genético futuramente. - Concluído<br>
4 - Execução do algoritimo genético. - Disponibilizar o acesso do usuário junto ao algoritimo genético, onde o mesmo irá apurar a melhor solução de acordo com as configurações definidas. - Concluido parcialmente - Falta alguns ajustes para apresentação do resultado