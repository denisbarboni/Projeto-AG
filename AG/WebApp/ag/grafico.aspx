<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="grafico.aspx.cs" Inherits="WebApp.grafico" Culture="pt-br" UICulture="pt-br" %>
<%@ PreviousPageType VirtualPath="~/ag/Default.aspx" %>

<%@ Register Assembly="DevExpress.XtraCharts.v15.1.Web, Version=15.1.7.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.XtraCharts.Web" TagPrefix="dxchartsui" %> 
 
<%@ Register Assembly="DevExpress.XtraCharts.v15.1.Web, Version=15.1.7.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.XtraCharts.Web.Designer" TagPrefix="dxchartdesigner" %> 
 
<%@ Register Assembly="DevExpress.XtraCharts.v15.1, Version=15.1.7.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.XtraCharts" TagPrefix="cc1" %> 

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1" />

    <link rel="Stylesheet" href="../css/bootstrap.min.css" />
    <link rel="Stylesheet" href="../css/bootstrap-theme.min.css" />
    <link rel="Stylesheet" href="../css/style.css" />

    <script type="text/javascript" src="./js/jquery-1.9.1.min.js"></script>
    <script type="text/javascript" src="./js/bootstrap.min.js"></script>

    <script type="text/javascript" src="./js/main/main.js"></script>

    <script src="./js/tbls/AddRemEdtTableMaq.js"></script>
    <%--jquery para manipulação da tabela de máquinas--%>

    <script src="./js/tbls/AddRemEdtTableSetor.js"></script>
    <%--jquery para manipulação da tabela de setor--%>

    <script src="./js/tbls/AddRemEdtTableSku.js"></script>
    <%--jquery para manipulação da tabela de sku--%>

    <script src="./js/tbls/AddRemEdtTableUnidade.js"></script>
    <%--jquery para manipulação da tabela de unidade--%>

    <script src="./js/tbls/AddRemEdtTableJob.js"></script>
    <%--jquery para manipulação da tabela de job--%>

    <script src="./js/tbls/AddRemEdtTableVelocidade.js"></script>
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

    <title>Gráfico</title>
</head>
<body>
<dxchartsui:WebChartControl ID="WebChartControl1" runat="server" EnableCallBacks="false" ClientInstanceName="chart" Width="800" Height="1024"> 
    <fillstyle> 
        <OptionsSerializable> 
            <cc1:SolidFillOptions HiddenSerializableString="to be serialized" /> 
        </OptionsSerializable> 
    </fillstyle> 
    <seriestemplate> 
        <ViewSerializable> 
            <cc1:SideBySideBarSeriesView HiddenSerializableString="to be serialized"> 
            </cc1:SideBySideBarSeriesView> 
        </ViewSerializable> 
        <LabelSerializable> 
            <cc1:SideBySideBarSeriesLabel HiddenSerializableString="to be serialized"> 
                <FillStyle> 
                    <OptionsSerializable> 
                        <cc1:SolidFillOptions HiddenSerializableString="to be serialized" /> 
                    </OptionsSerializable> 
                </FillStyle> 
            </cc1:SideBySideBarSeriesLabel> 
        </LabelSerializable> 
        <PointOptionsSerializable> 
            <cc1:PointOptions HiddenSerializableString="to be serialized"> 
            </cc1:PointOptions> 
        </PointOptionsSerializable> 
        <LegendPointOptionsSerializable> 
            <cc1:PointOptions HiddenSerializableString="to be serialized"> 
            </cc1:PointOptions> 
        </LegendPointOptionsSerializable> 
    </seriestemplate> 
</dxchartsui:WebChartControl> 
</body>
</html>
