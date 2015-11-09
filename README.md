NOTA DE LIBERAÇÃO: OTIMIZAÇÃO DO PROCESSO DE PRODUÇÃO COM JSSP	

INTRODUÇÃO

Este documento provê uma visão geral da versão do aplicativo Projeto “Otimização do processo de produção com JSSP” que está sendo liberada. Aqui descreveremos as funcionalidades do aplicativo, bem como seus problemas e limitações conhecidos. Por último são descritas as demandas e os problemas que foram resolvidos para liberação da versão atual.

NOTA DE RELEASE A SER PUBLICADO

Página inicial da aplicação.

Cadastro das máquinas, setores, skus, unidades, Jobs e velocidades por usuário.

PROBLEMAS CONHECIDOS E LIMITAÇÕES

O sistema suporta chega a consumir até 200 MB de memória do servidor por algoritimo rodando, podendo várias da quantidade de cadastro e da quantidade de populações estipulada pelo próprio usuário da aplicação.
O tempo de espera até que o algoritimo seja concluído é alto, podendo váriar de acordo com a quantidade de cadastros realizados pelo usuário.

DATAS IMPORTANTES

Segue abaixo as datas importante do desenvolvimento:

Data	    Evento

01/09/2015	Início do planejamento

10/09/2015	Início da primeira parte do desenvolvimento

29/09/2015	Fim e conclusão dos testes da primeira parte do desenvolvimento

30/09/2015	Início da segunda parte do desenvolvimento

31/10/2015	Fim e conclusão dos testes da segunda parte do desenvolvimento

COMPATIBILIDADE

Segue abaixo os requisitos:

Requisitos Ferramentas

Navegadores	Browser: Mozila Firefox; Chrome; Internet Explorer; Microsoft Edge

Versões: Necessário a mais atual ou compatível com HTML5, CSS3 e JS

Tecnologias

Linguagem de programação: ASP.NET, C#, JS

Framework WEB: Bootstrap, DevExpress, Jquery

IDE: Microsoft Visual Studio 2015 Enterprise

Design pattern: ADO.NET

Servidor Web: A Definir

PROCEDIMENTO E ALTERAÇAO DE CONFIGURAÇÃO DO AMBIENTE

Para implantação do projeto é necessário a configurações de um servidor WEB para hospedagem da aplicação e um servidor de banco de dados. A configuração da aplicação é somente a comunicação com o banco de dados. Feito isso, o sistema estará pronto para utilização.

ATIVIDADES REALIZADAS NO PERÍODO

Nessa liberação foram contemplados os seguintes itens:

Cód - Título - Tarefa - Situação - Observação

1 - Esboço da página inicial - Layout para montagem da página inicial do sistema - Concluído

2 - Login do usuário no serviço prestado - Acesso ao serviço onde o usuário poderá logar com seu usuário e senha para cadastrar os dados necessários para a ação do algoritimo genético. - Concluído

3 - Cadastro das máquinas, setores, unidades, skus, Jobs e velocidades usadas no algoritimo genético - Disponibilizar o acesso do usuário nas opções de cadastro do sistema, onde o mesmo poderá cadastrar as informações necessárias para a execução do algoritimo genético futuramente. - Concluído