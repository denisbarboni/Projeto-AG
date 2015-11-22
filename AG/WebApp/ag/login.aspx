<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="login.aspx.cs" Inherits="WebApp.login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <link rel="Stylesheet" href="css/bootstrap.min.css" />
    <link rel="Stylesheet" href="css/bootstrap-theme.min.css" />
    <title>Login</title>
</head>
<body>
    <form id="form1" runat="server" class="form-horizontal" onsubmit="Logar()">
        <div class="container">
            <div class="row">
                <div class="col-xs-4 col-xs-offset-4 ">
                    <div class="form-group">
                        <label class="control-label">Login</label>
                        <div class="input-group">
                            <div class="input-group-addon">
                                <span class="glyphicon glyphicon-user"></span>
                            </div>
                            <asp:TextBox ID="txtLogin" runat="server" ClientIDMode="Static" CssClass="form-control" placeholder="Login" required MaxLength="30"></asp:TextBox>
                        </div>
                    </div>

                    <div class="form-group">
                        <label class="control-label">Senha</label>
                        <div class="input-group">
                            <div class="input-group-addon">
                                <span class="glyphicon glyphicon-lock"></span>
                            </div>
                            <asp:TextBox ID="txtSenha" runat="server" ClientIDMode="Static" CssClass="form-control" placeholder="Senha" required TextMode="Password" MaxLength="030"></asp:TextBox>
                        </div>
                    </div>

                    <div class="form-group">
                        <button type="button" class="btn btn-primary btn-block" id="btnLogar" onclick="Logar()">Logar</button>
                    </div>
                </div>
            </div>
            <div class="row">
                <div class="col-xs-12">
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

                </div>
            </div>
        </div>
    </form>

    <script type="text/javascript" src="./js/jquery-1.9.1.min.js"></script>
    <script type="text/javascript" src="./js/bootstrap.min.js"></script>
    <script type="text/javascript" src="./js/main/main.js"></script>
</body>
</html>
