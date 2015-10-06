<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="WebApp.index" %>

<%@ Register Assembly="System.Web.DataVisualization, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" Namespace="System.Web.UI.DataVisualization.Charting" TagPrefix="asp" %>
<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <link rel="Stylesheet" href="../css/bootstrap.min.css" />
    <link rel="Stylesheet" href="../css/bootstrap-theme.min.css" />
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div class="container">
            <div class="row">
                <div class="col-xs-12">
                    <button class="btn btn-primary" id="btnVaiAlg" runat="server" onserverclick="btnVaiAlg_ServerClick">Rode o Alg</button>
                </div>
            </div>
            <div class="row">
                <div class="col-xs-12">
                    <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
                </div>
            </div>
            <div class="row">
                <div class="col-xs-12">
                    <asp:Label ID="Label2" runat="server" Text="Label"></asp:Label>
                </div>
            </div>
            <div class="row">
                <div class="col-xs-12">
                    <asp:Label ID="Label3" runat="server" Text="Label"></asp:Label>
                </div>
            </div>
            <div class="row">
                <div class="col-xs-12">
                    <asp:Label ID="Label4" runat="server" Text="Label"></asp:Label>
                </div>
            </div>
            <div class="row">
                <div class="col-xs-12">
                    <asp:Chart ID="Chart1" runat="server" Width="600" CssClass="bg-warning">
                        <Series>
                            <asp:Series Name="Series1" ChartType="StackedBar" ChartArea="ChartArea1">
                            </asp:Series>
                        </Series>
                        <ChartAreas>
                            <asp:ChartArea Name="ChartArea1">
                            </asp:ChartArea>
                        </ChartAreas>
                    </asp:Chart>
                </div>
            </div>
        </div>

        <script type="text/javascript" src="./js/jquery-1.9.1.min.js"></script>
        <script type="text/javascript" src="./js/bootstrap.min.js"></script>
    </form>
</body>
</html>
