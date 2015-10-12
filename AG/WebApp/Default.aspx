<%@ Page Language="C#" AutoEventWireup="true" MaintainScrollPositionOnPostback="true" CodeBehind="Default.aspx.cs" Inherits="WebApp.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1" />

    <link rel="Stylesheet" href="../css/bootstrap.min.css" />
    <link rel="Stylesheet" href="../css/bootstrap-theme.min.css" />
    <link rel="Stylesheet" href="../css/style.css" />

    <title>Index</title>

    <script type="text/javascript" src="./js/jquery-1.9.1.min.js"></script>
    <script type="text/javascript" src="./js/bootstrap.min.js"></script>
    <script type="text/javascript" src="./js/main.js"></script>

    <script src="./js/AddRemEdtTableMaq.js"></script>
    <%--jquery para manipulação da tabela de máquinas--%>

    <script src="./js/AddRemEdtTableSetor.js"></script>
    <%--jquery para manipulação da tabela de setor--%>

    <script src="./js/AddRemEdtTableSku.js"></script>
    <%--jquery para manipulação da tabela de sku--%>

    <script src="./js/AddRemEdtTableUnidade.js"></script>
    <%--jquery para manipulação da tabela de unidade--%>

    <script src="./js/AddRemEdtTableJob.js"></script>
    <%--jquery para manipulação da tabela de job--%>

    <script src="./js/AddRemEdtTableVelocidade.js"></script>
    <%--jquery para manipulação da tabela de velocidade--%>

    <script>
        $(document).ready(function () {
            $(".btn-pref .btn").click(function () {
                $(".btn-pref .btn").removeClass("btn-primary").addClass("btn-default");
                // $(".tab").addClass("active"); // instead of this do the below 
                $(this).removeClass("btn-default").addClass("btn-primary");
            });
        });

    </script>
</head>
<body>
    <nav class="navbar navbar-default">
        <div class="container-fluid">
            <div class="navbar-header">
                <button type="button" class="navbar-toggle collapsed" data-toggle="collapse" data-target="#navbar-collapse-top" aria-expanded="false">
                    <span class="sr-only">Toggle navigation</span>
                    <span class="icon-bar"></span>
                    <span class="icon-bar"></span>
                    <span class="icon-bar"></span>
                </button>
                <a class="navbar-brand" href="#">Algoritimo Genetico</a>
            </div>

            <div class="collapse navbar-collapse" id="navbar-collapse-top">
                <ul class="nav navbar-nav navbar-right">
                    <li class="dropdown">
                        <a href="#" class="dropdown-toggle" data-toggle="dropdown" role="button" aria-haspopup="true" aria-expanded="false">Opções <span class="caret"></span>
                        </a>
                        <ul class="dropdown-menu">
                            <li>
                                <a href="#" data-toggle="modal" data-target="#modalConfiguracoes" id="configNavbar">Configurações</a>
                            </li>
                            <li role="separator" class="divider"></li>
                            <li><a href="#" id="sairNavbar" runat="server" onserverclick="sairNavbar_ServerClick">Sair</a></li>
                        </ul>
                    </li>
                </ul>
            </div>
        </div>
    </nav>

    <div class="modal fade" id="modalConfiguracoes" tabindex="-1" role="dialog" aria-labelledby="modalConfiguracoesLabel">
        <div class="modal-dialog" role="document">
            <div class="modal-content">
                <form runat="server">
                    <div class="modal-header">
                        <button type="button" class="close" data-dismiss="modal" aria-label="Close"><span aria-hidden="true">&times;</span></button>
                        <h4 class="modal-title" id="modalConfiguracoesLabel">Configurações</h4>
                    </div>
                    <div class="modal-body">
                        <div class="form-group">
                            <label class="control-label">Atingir solução máxima de: </label>
                            <div class="input-group">
                                <div class="input-group-addon">
                                    <span class="glyphicon glyphicon-wrench"></span>
                                </div>
                                <asp:TextBox ID="txtDefineSolucao" runat="server" CssClass="form-control" placeholder="Solução" required ClientIDMode="Static" MaxLength="6"></asp:TextBox>
                            </div>
                        </div>
                        <div class="form-group">
                            <label class="control-label">Taxa de Crossover</label>
                            <div class="input-group">
                                <div class="input-group-addon">
                                    <span class="glyphicon glyphicon-wrench"></span>
                                </div>
                                <asp:TextBox ID="txtCrossover" runat="server" CssClass="form-control" placeholder="0.0 até 1.0" required ClientIDMode="Static" MaxLength="3"></asp:TextBox>
                            </div>
                        </div>
                        <div class="form-group">
                            <label class="control-label">Taxa de mutação</label>
                            <div class="input-group">
                                <div class="input-group-addon">
                                    <span class="glyphicon glyphicon-wrench"></span>
                                </div>
                                <asp:TextBox ID="txtMutacao" runat="server" CssClass="form-control" placeholder="0.0 até 1.0" required ClientIDMode="Static" MaxLength="3"></asp:TextBox>
                            </div>
                        </div>
                        <div class="form-group">
                            <label class="control-label">Eltismo</label>

                            <div class="radio">
                                <label>
                                    <input type="radio" name="eltismo" id="EltismoSim" value="true">
                                    Sim
                                </label>
                                <label>
                                    <input type="radio" name="eltismo" id="EltismoNao" value="false">
                                    Não
                                </label>
                            </div>
                        </div>
                        <div class="form-group">
                            <label class="control-label">Tamanho máximo de população: </label>
                            <div class="input-group">
                                <div class="input-group-addon">
                                    <span class="glyphicon glyphicon-wrench"></span>
                                </div>
                                <asp:TextBox ID="txtPopulacao" runat="server" CssClass="form-control" placeholder="População" required ClientIDMode="Static" MaxLength="6"></asp:TextBox>
                            </div>
                        </div>
                        <div class="form-group">
                            <label class="control-label">Atingir um máximo de geração igual à: </label>
                            <div class="input-group">
                                <div class="input-group-addon">
                                    <span class="glyphicon glyphicon-wrench"></span>
                                </div>
                                <asp:TextBox ID="txtGeracoes" runat="server" CssClass="form-control" placeholder="Gerações" required ClientIDMode="Static" MaxLength="6"></asp:TextBox>
                            </div>
                        </div>
                    </div>
                    <div class="modal-footer">
                        <asp:Button Text="Fechar" ID="btnFecharModalConfig" CssClass="btn btn-default" data-dismiss="modal" runat="server" AutoPostBack="false" OnClick="btnFecharModalConfig_Click" />
                        <button type="button" id="btnSalvarConfig" data-loading-text="Loading..." class="btn btn-primary" autocomplete="off">
                            Salvar configurações
                        </button>
                    </div>
                </form>
            </div>
        </div>
    </div>

    <div class="container">
        <div class="col-xs-12">
            <div class="card hovercard">
                <div class="card-background">
                    <img class="card-bkimg" alt="" src="//ssl.gstatic.com/accounts/ui/avatar_2x.png">
                </div>
                <div class="useravatar">
                    <img alt="" src="//ssl.gstatic.com/accounts/ui/avatar_2x.png">
                </div>
                <div class="card-info">
                    <span class="card-title">
                        <asp:Label ID="lblUserNavBar" runat="server" Text="User"></asp:Label></span>
                </div>
            </div>
            <div class="btn-pref btn-group btn-group-justified btn-group-lg" role="group" aria-label="...">
                <div class="btn-group" role="group">
                    <button type="button" id="stars" class="btn btn-primary" href="#tab1" data-toggle="tab">
                        <span class="glyphicon glyphicon-star" aria-hidden="true"></span>
                        <div class="hidden-xs">Cadastro</div>
                    </button>
                </div>
                <div class="btn-group" role="group">
                    <button type="button" id="favorites" class="btn btn-default" href="#tab2" data-toggle="tab">
                        <span class="glyphicon glyphicon-heart" aria-hidden="true"></span>
                        <div class="hidden-xs">Algoritimo</div>
                    </button>
                </div>
            </div>

            <div class="well">
                <div class="tab-content">
                    <div class="tab-pane fade in active" id="tab1">
                        <div class="container">
                            <div class="row">

                                <div class="col-xs-12 col-sm-3 col-md-3">
                                    <div class="panel-group" id="accordion">
                                        <div class="panel panel-default">

                                            <div class="panel-heading">
                                                <h4 class="panel-title">
                                                    <a data-toggle="collapse" data-parent="#accordion" href="#collapseOne"><span class="glyphicon glyphicon-pencil"></span>Cadastros gerais</a>
                                                </h4>
                                            </div>

                                            <div id="collapseOne" class="panel-collapse collapse in">
                                                <div class="panel-body">
                                                    <table class="table">
                                                        <tr>
                                                            <td>
                                                                <span class="glyphicon glyphicon-wrench text-primary"></span><a href="#tabtab1" data-toggle="tab">Máquina</a>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                <span class="glyphicon glyphicon-wrench text-primary"></span><a href="#tabtab2" data-toggle="tab">Setor</a>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                <span class="glyphicon glyphicon-wrench text-primary"></span><a href="#tabtab3" data-toggle="tab">Sku</a>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                <span class="glyphicon glyphicon-wrench text-primary"></span><a href="#tabtab4" data-toggle="tab">Unidade</a>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                <span class="glyphicon glyphicon-wrench text-primary"></span><a href="#tabtab5" data-toggle="tab">Job</a>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                <span class="glyphicon glyphicon-wrench text-primary"></span><a href="#tabtab6" data-toggle="tab">Velocidade</a>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </div>
                                            </div>

                                        </div>
                                        <div class="panel panel-default">

                                            <div class="panel-heading">
                                                <h4 class="panel-title">
                                                    <a data-toggle="collapse" data-parent="#accordion" href="#collapseTwo"><span class="glyphicon glyphicon-user"></span>Account</a>
                                                </h4>
                                            </div>

                                            <div id="collapseTwo" class="panel-collapse collapse">
                                                <div class="panel-body">
                                                    <table class="table">
                                                        <tr>
                                                            <td>
                                                                <a href="#tabtab4" data-toggle="tab">Change Password</a>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                <a href="#tabtab5" data-toggle="tab">Change Password</a>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                <a href="#tabtab6" data-toggle="tab">Change Password</a>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </div>
                                            </div>

                                        </div>
                                        <div class="panel panel-default">

                                            <div class="panel-heading">
                                                <h4 class="panel-title">
                                                    <a data-toggle="collapse" data-parent="#accordion" href="#collapseThree"><span class="glyphicon glyphicon-user"></span>Account</a>
                                                </h4>
                                            </div>

                                            <div id="collapseThree" class="panel-collapse collapse">
                                                <div class="panel-body">
                                                    <table class="table">
                                                        <tr>
                                                            <td>
                                                                <a href="#tabtab7" data-toggle="tab">Change Password</a>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                <a href="#tabtab8" data-toggle="tab">Change Password</a>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                <a href="#tabtab9" data-toggle="tab">Change Password</a>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </div>
                                            </div>

                                        </div>
                                    </div>
                                </div>

                                <div class="col-xs-12 col-sm-7 col-md-8">
                                    <div class="well">
                                        <div class="tab-content">
                                            <div class="tab-pane fade in active" id="tabtab1" style="padding-bottom: 25px;">
                                                <table class="table table-hover" id="tblMaquina">
                                                    <thead>
                                                        <tr>
                                                            <th>Máquina</th>
                                                            <th>&nbsp</th>
                                                        </tr>
                                                    </thead>
                                                    <tbody>
                                                        <%--aqui vai as máquinas via jquery--%>
                                                    </tbody>
                                                </table>
                                                <button class="btn btn-primary pull-right" id="addMaq">Adicionar máquina</button>
                                            </div>

                                            <div class="tab-pane fade in" id="tabtab2" style="padding-bottom: 25px;">
                                                <table class="table table-hover" id="tblSetor">
                                                    <thead>
                                                        <tr>
                                                            <th>Setor</th>
                                                            <th>&nbsp</th>
                                                        </tr>
                                                    </thead>
                                                    <tbody>
                                                        <%--aqui vai os setores via jquery--%>
                                                    </tbody>
                                                </table>
                                                <button class="btn btn-primary pull-right" id="addSetor">Adicionar Setor</button>
                                            </div>

                                            <div class="tab-pane fade in" id="tabtab3" style="padding-bottom: 25px;">
                                                <table class="table table-hover" id="tblSku">
                                                    <thead>
                                                        <tr>
                                                            <th style="width: 55%">Sku</th>
                                                            <th style="width: 30%">Peso</th>
                                                            <th>&nbsp</th>
                                                        </tr>
                                                    </thead>
                                                    <tbody>
                                                        <%--aqui vai os setores via jquery--%>
                                                    </tbody>
                                                </table>
                                                <%--<button class="btn btn-primary pull-right" id="btnTesteForeach">teste</button>--%>
                                                <button class="btn btn-primary pull-right" id="addSku">Adicionar Sku</button>
                                            </div>

                                            <div class="tab-pane fade in" id="tabtab4" style="padding-bottom: 25px;">
                                                <table class="table table-hover" id="tblUnidade">
                                                    <thead>
                                                        <tr>
                                                            <th style="width: 30%">Código Unidade</th>
                                                            <th style="width: 55%">Unidade</th>
                                                            <th>&nbsp</th>
                                                        </tr>
                                                    </thead>
                                                    <tbody>
                                                        <%--aqui vai os setores via jquery--%>
                                                    </tbody>
                                                </table>
                                                <button class="btn btn-primary pull-right" id="addUnidade">Adicionar Unidade</button>
                                            </div>

                                            <div class="tab-pane fade in" id="tabtab5" style="padding-bottom: 25px;">
                                                <table class="table table-hover" id="tblJob">
                                                    <thead>
                                                        <tr>
                                                            <th>Sku do Job</th>
                                                            <th>Quantidade</th>
                                                            <th>&nbsp</th>
                                                        </tr>
                                                    </thead>
                                                    <tbody>                                                        
                                                        <%--aqui vai os setores via jquery--%>                                                        
                                                    </tbody>
                                                </table>
                                                <button class="btn btn-primary pull-right" id="addJob">Adicionar Job</button>
                                            </div>

                                            <div class="tab-pane fade in" id="tabtab6" style="padding-bottom: 25px;">
                                                <table class="table table-hover" id="tblVelocidade">
                                                    <thead>
                                                        <tr>
                                                            <th>Máquina</th>
                                                            <th>Setor</th>
                                                            <th>Sku</th>
                                                            <th>Velocidade</th>
                                                            <th>&nbsp</th>
                                                            <%--  style="width: 20%" --%>
                                                        </tr>
                                                    </thead>
                                                    <tbody>                                                                                                                
                                                    </tbody>
                                                </table>
                                                <button class="btn btn-primary pull-right" id="addVelocidade">Adicionar Velocidade</button>
                                            </div>
                                            
                                            <div class="tab-pane fade in" id="tabtab7" style="padding-bottom: 25px;">
                                                Teste7
                                            </div>

                                            <div class="tab-pane fade in" id="tabtab8" style="padding-bottom: 25px;">
                                                Teste8
                                            </div>

                                            <div class="tab-pane fade in" id="tabtab9" style="padding-bottom: 25px;">
                                                Teste9
                                            </div>

                                        </div>
                                    </div>
                                </div>

                            </div>
                        </div>
                    </div>

                    <div class="tab-pane fade in" id="tab2">
                        Teste
                    </div>
                </div>
            </div>

            <div class="row">
                <div class="col-xs-12">
                    <div class="modal fade" id="modalErro" role="dialog">
                        <div class="modal-dialog modal-sm">
                            <div class="modal-content">
                                <div class="modal-header">
                                    <button type="button" class="close" data-dismiss="modal">&times;</button>
                                    <h4 class="modal-title">Erro!</h4>
                                </div>
                                <div class="modal-body">
                                    <p>
                                        <asp:Label ID="lblErro" runat="server" Text="Verifique seu usuário e/ou sua senha."></asp:Label>
                                    </p>
                                </div>
                                <div class="modal-footer">
                                    <button type="button" class="btn btn-default" data-dismiss="modal">Fechar</button>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>

        </div>
    </div>
</body>
</html>
