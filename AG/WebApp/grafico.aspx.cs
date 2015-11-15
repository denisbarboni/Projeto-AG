using Acesso;
using DevExpress.XtraCharts;
using Objetos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApp
{
    public partial class grafico : System.Web.UI.Page
    {
        int idUserStatic;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (HttpContext.Current.Session["logado"] == null || HttpContext.Current.Session["logado"].ToString() != "True")
            {
                HttpContext.Current.Session.Abandon();
                HttpContext.Current.Response.Redirect("Login.aspx");
            }
            else
            {
                idUserStatic = Convert.ToInt32(HttpContext.Current.Session["idUsuario"]);
                setarGrafico(idUserStatic);
            }
        }

        public void setarGrafico(int idUser)
        {
            DAO dao = new DAO();
            List<Genes> lstGenes = dao.getResultado(idUser);

            this.WebChartControl1.Series.Clear();

            foreach (var item in lstGenes)
            {
                Series series = new Series(item.Sku, ViewType.SideBySideGantt);
                //this.WebChartControl1.Series.Add(series1);
                //series.Label.Visible = false;
                ((GanttSeriesView)series.View).BarWidth = 1.5;

                // Add points to the first series.
                series.ArgumentScaleType = ScaleType.Qualitative;
                series.ValueScaleType = ScaleType.DateTime;

                series.Points.Add(new SeriesPoint(item.Maq, new DateTime[] {
                    item.Inicio,
                    item.Final
                }));

                this.WebChartControl1.Series.Add(series);
            }

            // Create the second Gantt series and set its properties.

            // Add a constant line.
            //ConstantLine deadline = new ConstantLine("Deadline", new DateTime(2015, 11, 06));
            //deadline.ShowInLegend = false;
            //deadline.Title.Alignment = ConstantLineTitleAlignment.Far;
            //deadline.Color = System.Drawing.Color.Red;
            //((GanttDiagram)this.WebChartControl1.Diagram).AxisY.ConstantLines.Add(deadline);

            // Customize the chart.
            //ganttChart.Size = New System.Drawing.Size(500, 300)
            WebChartControl1.Legend.AlignmentHorizontal = LegendAlignmentHorizontal.Right;
            WebChartControl1.Legend.AlignmentVertical = LegendAlignmentVertical.TopOutside;
            WebChartControl1.Legend.Direction = LegendDirection.LeftToRight;
            ((GanttDiagram)WebChartControl1.Diagram).AxisX.Title.Text = "Máquinas";
            ((GanttDiagram)WebChartControl1.Diagram).AxisX.Title.Visible = true;
            ((GanttDiagram)WebChartControl1.Diagram).AxisY.Interlaced = true;
            ((GanttDiagram)WebChartControl1.Diagram).AxisY.GridSpacing = 10;
            ((GanttDiagram)WebChartControl1.Diagram).AxisY.Label.Angle = -30;
            ((GanttDiagram)WebChartControl1.Diagram).AxisY.Label.Antialiasing = true;
            ((GanttDiagram)WebChartControl1.Diagram).AxisY.DateTimeOptions.Format = DateTimeFormat.LongDate;

            this.WebChartControl1.Visible = true;
        }
    }
}