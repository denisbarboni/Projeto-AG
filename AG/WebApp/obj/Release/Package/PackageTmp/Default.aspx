<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="WebApp.index" %>

<%@ Register Assembly="DevExpress.Web.v15.1, Version=15.1.7.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <title>Projeto - Otimização de Processo com JSSP</title>
    <link rel="shortcut icon" href="img/favicon.ico" type="image/x-icon">
    <link rel="apple-touch-icon" href="img/apple-touch-icon.png">
    <link rel="apple-touch-icon" sizes="72x72" href="img/apple-touch-icon-72x72.png">
    <link rel="apple-touch-icon" sizes="114x114" href="img/apple-touch-icon-114x114.png">

    <!-- Bootstrap -->
    <link rel="stylesheet" type="text/css" href="css/bootstrap.min.css" media="screen">
    <link rel="stylesheet" type="text/css" href="fonts/font-awesome/css/font-awesome.css">

    <!-- All the files that are required -->
    <link rel="stylesheet" href="//maxcdn.bootstrapcdn.com/font-awesome/4.3.0/css/font-awesome.min.css">
    <link href='http://fonts.googleapis.com/css?family=Varela+Round' rel='stylesheet' type='text/css'>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/jquery-validate/1.13.1/jquery.validate.min.js"></script>
    <meta name="viewport" content="width=device-width, initial-scale=1, maximum-scale=1" />

    <!-- Slider
        ================================================== -->
    <link href="css/owl.carousel.css" rel="stylesheet" media="screen">
    <link href="css/owl.theme.css" rel="stylesheet" media="screen">

    <!-- Stylesheet
        ================================================== -->
    <link rel="stylesheet" type="text/css" href="css/style.css">
    <link rel="stylesheet" type="text/css" href="css/responsive.css">

    <link href='http://fonts.googleapis.com/css?family=Lato:100,300,400,700,900,100italic,300italic,400italic,700italic,900italic' rel='stylesheet' type='text/css'>
    <link href='http://fonts.googleapis.com/css?family=Open+Sans:300italic,400italic,600italic,700italic,800italic,700,300,600,800,400' rel='stylesheet' type='text/css'>

    <script type="text/javascript" src="js/modernizr.custom.js"></script>
    <script type="text/javascript" src="ag/js/main/main.js"></script>
</head>
<body>
    <!-- Navegação
    ==========================================-->
    <nav id="tf-menu" class="navbar navbar-default navbar-fixed-top">
        <div class="container">
            <!-- Marca e alternância se agrupados para melhor visualização móvel -->
            <div class="navbar-header">
                <button type="button" class="navbar-toggle collapsed" data-toggle="collapse" data-target="#bs-example-navbar-collapse-1">
                    <span class="sr-only">Toggle navigation</span>
                    <span class="icon-bar"></span>
                    <span class="icon-bar"></span>
                    <span class="icon-bar"></span>
                </button>
                <a class="navbar-brand" href="#">Algoritmo Genético</a>
            </div>

            <!-- Colete as ligações nav, formulários e outros conteúdos para alternar -->
            <div class="collapse navbar-collapse" id="bs-example-navbar-collapse-1">
                <ul class="nav navbar-nav navbar-right">
                    <li><a href="#tf-home" class="page-scroll">Home</a></li>
                    <li><a href="#tf-about" class="page-scroll">Sobre</a></li>
                    <li><a href="#tf-team" class="page-scroll">Equipe</a></li>
                    <li><a href="#tf-services" class="page-scroll">Serviços</a></li>
                    <li><a href="#tf-works" class="page-scroll">Planos</a></li>
                    <li><a href="#tf-contact" class="page-scroll">Contato</a></li>
                    <li><a href="#Login" data-toggle="modal" data-target="#Login">Login</a></li>
                    <li><a href="#Cadastro" data-toggle="modal" data-target="#Cadastro">Cadastre-se</a></li>
                </ul>
            </div>
            <!-- /.navbar-collapse -->
        </div>
        <!-- /.container-fluid -->
    </nav>



    <!-- Home Page
    ==========================================-->
    <div id="tf-home" class="text-center">
        <div class="overlay">
            <div class="content">
                <h1>Bem Vindo ao nosso<strong><span class="color"> Projeto</span></strong></h1>
                <p class="lead">Otimização do processo de <strong>produção </strong>com <strong>JSSP</strong></p>
                <a href="#tf-about" class="fa fa-angle-down page-scroll"></a>
            </div>
        </div>
    </div>

    <!-- LOGIN
    ===========================================-->
    <div class="modal fade" id="Login" tabindex="-1" role="dialog" aria-labelledby="myModalLogin" aria-hidden="true">
        <div class="modal-dialog modal-sm">
            <div class="modal-content">
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal" aria-hidden="true">×</button>
                    <h4 class="modal-title" id="myModalLogin">Login</h4>
                </div>
                <!-- /.modal-header -->
                <form>
                    <div class="modal-body">
                        <div class="form-group has-feedback">
                            <%--<div class="input-group">--%>
                            <input type="text" class="form-control" id="txtLogin" placeholder="Usuário">
                            <span class="glyphicon glyphicon-user form-control-feedback" id="txtLoginSpan"></span>
                            <%--</div>--%>
                        </div>
                        <!-- /.form-group -->

                        <div class="form-group has-feedback">
                            <%--<div class="input-group">--%>
                            <input type="password" class="form-control" id="txtSenha" placeholder="Senha">
                            <span class="glyphicon glyphicon-lock form-control-feedback" id="txtSenhaSpan"></span>
                            <%--</div>--%>
                            <!-- /.input-group -->
                        </div>
                        <!-- /.form-group -->
                    </div>
                </form>
                <div class="modal-footer">
                    <button class="form-control btn btn-primary" onclick="Logar()">Ok</button>
                </div>
                <!-- /.modal-body -->
                <!-- /.modal-footer -->
            </div>
            <!-- /.modal-content -->
        </div>
        <!-- /.modal-dialog -->
    </div>
    <!-- /.modal -->
    <!-- FIM - LOGIN-->

    <!-- ErroLogin -->
    <div class="modal fade" id="modalErroLogin" role="dialog">
        <div class="modal-dialog modal-sm">
            <div class="modal-content">
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal">&times;</button>
                    <h4 class="modal-title">Erro!</h4>
                </div>
                <div class="modal-body">
                    <p>
                        <asp:Label ID="lblErroLogin" runat="server" Text="Verifique seu usuário e/ou sua senha."></asp:Label>
                    </p>
                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-default" data-dismiss="modal">Fechar</button>
                </div>
            </div>
        </div>
    </div>
    <!-- Fim erro login -->

    <!-- CADASTRO
    ===========================================-->
    <div class="modal fade" id="Cadastro" tabindex="-1" role="dialog" aria-labelledby="myModalCadastro" aria-hidden="true">
        <div class="modal-dialog modal-lg">
            <div class="modal-content">
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal" aria-hidden="true">×</button>
                    <h4 class="modal-title" id="myModalCadastro">Cadastre - Se</h4>
                </div>
                <!-- /.modal-header -->

                <div class="modal-body">
                    <form role="form" runat="server">
                        <div class="form-group">
                            <div class="input-group">
                                <div class="row">
                                    <div class="col-sm-6 form-group">
                                        <label>Nome</label>
                                        <asp:TextBox type="text" ID="txtCadNome" runat="server" placeholder="Digire seu Nome" class="form-control" required></asp:TextBox>
                                    </div>
                                    <div class="col-sm-6 form-group">
                                        <label>Sobrenome</label>
                                        <asp:TextBox type="text" ID="txtCadSobrenome" runat="server" placeholder="Digire seu Sobrenome" class="form-control" required></asp:TextBox>
                                    </div>
                                    <div class="col-sm-12 form-group">
                                        <label>Usuario</label>
                                        <asp:TextBox type="text" ID="txtCadUsuario" runat="server" placeholder="Digite nome do Usuario" class="form-control" required></asp:TextBox>
                                    </div>
                                    <div class="col-sm-6 form-group">
                                        <label>Senha</label>
                                        <asp:TextBox type="password" ID="txtCadSenha" runat="server" placeholder="Digite sua Senha" class="form-control" required></asp:TextBox>
                                    </div>
                                    <div class="col-sm-6 form-group">
                                        <label>Comfirmar Senha</label>
                                        <asp:TextBox type="password" ID="txtCadSenha2" runat="server" placeholder="Confirme sua Senha" class="form-control" required></asp:TextBox>
                                    </div>
                                    <div class="col-sm-12 form-group">
                                        <label>E-mail</label>
                                        <asp:TextBox type="email" ID="txtCadEmail" runat="server" placeholder="Digite seu E-mail" class="form-control" required></asp:TextBox>
                                    </div>
                                    <div class="col-sm-6 form-group">
                                        <label for="sel1">Escolha seu Plano</label>
                                        <select class="form-control" id="sel1">
                                            <option>Plano 1</option>
                                            <%--<option>Plano 2</option>--%>
                                            <%--<option>Plano 3</option>--%>
                                        </select>
                                    </div>
                                </div>
                                <!-- /.input-group -->
                            </div>
                            <!-- /.form-group -->
                        </div>
                        <div class="modal-footer">
                            <button type="button" class="form-control btn btn-primary" onclick="btnCadastrar();">Cadastrar</button>
                        </div>
                    </form>
                </div>
                <!-- /.modal-body -->

                <!-- /.modal-footer -->
            </div>
            <!-- /.modal-content -->
        </div>
        <!-- /.modal-dialog -->
    </div>
    <!-- /.modal -->
    <!-- FIM - CADASTRO-->


    <!-- About Us Page
    ==========================================-->
    <div id="tf-about">
        <div class="container">
            <div class="row">
                <div class="col-md-6">
                    <img src="img/02.png" class="img-responsive">
                </div>
                <div class="col-md-6">
                    <div class="about-text">
                        <div class="section-title">
                            <h4>Sobre nós</h4>
                            <h2>Algumas palavras <strong>sobre nós</strong></h2>
                            <hr>
                            <div class="clearfix"></div>
                        </div>
                        <p class="intro">Resumo.</p>
                    </div>
                </div>
            </div>
        </div>
    </div>

    <!-- QUEM SOMOS
    ==========================================-->
    <div id="tf-team" class="text-center">
        <div class="overlay">
            <div class="container">
                <div class="section-title center">
                    <h2>Conheça <strong>nossa equipe</strong></h2>
                    <div class="line">
                        <hr>
                    </div>
                </div>

                <div class="row">
                    <div class="col-md-4 col-sm-6">
                        <div class="item">
                            <div class="thumbnail">
                                <img src="img/team/01.jpg" alt="..." class="img-circle team-img">
                                <div class="caption">
                                    <h3>André Sabes</h3>
                                    <p>CEO / Founder</p>
                                    <p>Frase.</p>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="col-md-4 col-sm-6">
                        <div class="item">
                            <div class="thumbnail">
                                <img src="img/team/02.jpg" alt="..." class="img-circle team-img">
                                <div class="caption">
                                    <h3>Daniel Botter</h3>
                                    <p>CEO / Founder</p>
                                    <p>Frase.</p>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="col-md-4 col-sm-6">
                        <div class="item">
                            <div class="thumbnail">
                                <img src="img/team/03.jpg" alt="..." class="img-circle team-img">
                                <div class="caption">
                                    <h3>Denis Barboni</h3>
                                    <p>CEO / Founder</p>
                                    <p>Frase.</p>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>

    <!-- SERVIÇOS
    ==========================================-->
    <div id="tf-services" class="text-center">
        <div class="container">
            <div class="section-title center">
                <h2>Dê uma olhada no <strong>nosso serviço</strong></h2>
                <div class="line">
                    <hr>
                </div>
                <div class="clearfix"></div>

            </div>

            <div class="row">
                <div class="col-md-12 col-sm-6 service">
                    <i class="fa fa-desktop"></i>
                    <h4><strong>Otimização de Produção</strong></h4>
                    <p>Otimização de Produção com JSSP.</p>
                </div>
            </div>
        </div>
    </div>

    <!-- PLANOS
    ==========================================-->
    <div id="tf-works" class="text-center">
        <div class="container">
            <!-- Container -->
            <div class="section-title center">
                <h2>Conheça <strong>nossos Planos</strong></h2>
                <div class="line">
                    <hr>
                </div>
                <div class="clearfix"></div>
                <!-- <small><em>Lorem Ipsum comes from sections 1.10.32 and 1.10.33 of "de Finibus Bonorum et Malorum" (The
                    Extremes of Good and Evil) by Cicero, written in 45 BC. This book is a treatise on the theory of
                    ethics, very popular during the Renaissance. The first line of Lorem Ipsum, "Lorem ipsum dolor sit
                    amet..", comes from a line in section 1.10.32.</em></small>-->
            </div>
            <br>
            <br>

            <div class="row">
                <div class="col-xs-12 col-md-4">
                    <div class="panel panel-primary">
                        <div class="panel-heading">
                            <h3 class="panel-title">Bronze</h3>
                        </div>
                        <div class="panel-body">
                            <div class="the-price">
                                <h1>$10<span class="subscript">/mo</span></h1>
                                <small>1 month FREE trial</small>
                            </div>
                            <table class="table">
                                <tr>
                                    <td>1 Account
                                    </td>
                                </tr>
                                <tr class="active">
                                    <td>1 Project
                                    </td>
                                </tr>
                                <tr>
                                    <td>100K API Access
                                    </td>
                                </tr>
                                <tr class="active">
                                    <td>100MB Storage
                                    </td>
                                </tr>
                                <tr>
                                    <td>Custom Cloud Services
                                    </td>
                                </tr>
                                <tr class="active">
                                    <td>Weekly Reports
                                    </td>
                                </tr>
                            </table>
                        </div>
                        <div class="panel-footer">
                            <a href="#" class="btn btn-success" role="button">Sign Up</a>
                            1 month FREE trial
                        </div>
                    </div>
                </div>
                <div class="col-xs-12 col-md-4">
                    <div class="panel panel-success">
                        <div class="cnrflash">
                            <div class="cnrflash-inner">
                                <span class="cnrflash-label">MOST
                                        <br>
                                    POPULR</span>
                            </div>
                        </div>
                        <div class="panel-heading">
                            <h3 class="panel-title">Silver</h3>
                        </div>
                        <div class="panel-body">
                            <div class="the-price">
                                <h1>$20<span class="subscript">/mo</span></h1>
                                <small>1 month FREE trial</small>
                            </div>
                            <table class="table">
                                <tr>
                                    <td>2 Account
                                    </td>
                                </tr>
                                <tr class="active">
                                    <td>5 Project
                                    </td>
                                </tr>
                                <tr>
                                    <td>100K API Access
                                    </td>
                                </tr>
                                <tr class="active">
                                    <td>200MB Storage
                                    </td>
                                </tr>
                                <tr>
                                    <td>Custom Cloud Services
                                    </td>
                                </tr>
                                <tr class="active">
                                    <td>Weekly Reports
                                    </td>
                                </tr>
                            </table>
                        </div>
                        <div class="panel-footer">
                            <a href="#" class="btn btn-success" role="button">Sign Up</a>
                            1 month FREE trial
                        </div>
                    </div>
                </div>
                <div class="col-xs-12 col-md-4">
                    <div class="panel panel-info">
                        <div class="panel-heading">
                            <h3 class="panel-title">Gold</h3>
                        </div>
                        <div class="panel-body">
                            <div class="the-price">
                                <h1>$35<span class="subscript">/mo</span></h1>
                                <small>1 month FREE trial</small>
                            </div>
                            <table class="table">
                                <tr>
                                    <td>5 Account
                                    </td>
                                </tr>
                                <tr class="active">
                                    <td>20 Project
                                    </td>
                                </tr>
                                <tr>
                                    <td>300K API Access
                                    </td>
                                </tr>
                                <tr class="active">
                                    <td>500MB Storage
                                    </td>
                                </tr>
                                <tr>
                                    <td>Custom Cloud Services
                                    </td>
                                </tr>
                                <tr class="active">
                                    <td>Weekly Reports
                                    </td>
                                </tr>
                            </table>
                        </div>
                        <div class="panel-footer">
                            <a href="#" class="btn btn-success" role="button">Sign Up</a> 1 month FREE trial
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>

    <!-- CONTATO
    ==========================================-->
    <div id="tf-contact" class="text-center">
        <div class="container">

            <div class="row">
                <div class="col-md-8 col-md-offset-2">

                    <div class="section-title center">
                        <h2><strong>Contato</strong></h2>
                        <div class="line">
                            <hr>
                        </div>
                        <div class="clearfix"></div>
                    </div>
                    <form>
                        <div class="row">
                            <div class="col-md-6">
                                <div class="form-group">
                                    <label for="exampleInputEmail1"><strong>Email</strong></label>
                                    <input type="email" class="form-control" id="exampleInputEmail1" placeholder="Digite email">
                                </div>
                            </div>
                            <div class="col-md-6">
                                <div class="form-group">
                                    <label for="exampleInputPassword1"><strong>Senha</strong></label>
                                    <input type="password" class="form-control" id="exampleInputPassword1" placeholder="Digite senha">
                                </div>
                            </div>
                        </div>
                        <div class="form-group">
                            <label for="exampleInputEmail1"><strong>Mensagem</strong></label>
                            <textarea class="form-control" rows="3"></textarea>
                        </div>

                        <button type="submit" class="btn tf-btn btn-default">Enviar</button>
                    </form>
                </div>
            </div>

        </div>
    </div>

    <!-- FOOTER
   ==========================================-->
    <nav id="footer">
        <div class="container">
            <div class="pull-left fnav">
                <p>Todos os direitos reservados. COPYRIGHT © 2015.</p>
            </div>
            <div class="pull-right fnav">
                <ul class="footer-social">
                    <li><a href="#"><i class="fa fa-facebook"></i></a></li>
                </ul>
            </div>
        </div>
    </nav>


    <!-- jQuery (necessary for Bootstrap's JavaScript plugins) -->
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/1.11.1/jquery.min.js"></script>
    <script type="text/javascript" src="js/jquery.1.11.1.js"></script>
    <!-- Include all compiled plugins (below), or include individual files as needed -->
    <script type="text/javascript" src="js/bootstrap.js"></script>
    <script type="text/javascript" src="js/SmoothScroll.js"></script>
    <script type="text/javascript" src="js/jquery.isotope.js"></script>

    <script src="js/owl.carousel.js"></script>
    <!-- Javascripts
    ================================================== -->
    <script type="text/javascript" src="js/main.js"></script>
</body>
</html>
