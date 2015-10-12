using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Acesso;
using Objetos;
using System.Web.Services;
using System.Web.Script.Services;

namespace WebApp
{
    public partial class Default : System.Web.UI.Page
    {
        static Configuracao config;
        static int idUserStatic;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (HttpContext.Current.Session["logado"] == null || HttpContext.Current.Session["logado"].ToString() != "True")
            {
                HttpContext.Current.Session.Abandon();
                HttpContext.Current.Response.Redirect("Login.aspx");
            }
            else
            {
                lblUserNavBar.Text = HttpContext.Current.Session["usuario"].ToString();
                idUserStatic = Convert.ToInt32(HttpContext.Current.Session["idUsuario"]);

                carregarConfigs(idUserStatic);

                carregarMaq(idUserStatic);
                carregarSetor(idUserStatic);
                carregarSku(idUserStatic);
                carregarUnidade(idUserStatic);
                carregarJob(idUserStatic);
                carregarVelocidade(idUserStatic);
            }
        }
        #region CarregarConfigs
        private void carregarConfigs(int id)
        {
            DAO dao = new DAO();

            config = dao.GetConfig(id);

            if (config != null)
            {
                txtDefineSolucao.Text = config.SolucaoMax.ToString();
                txtCrossover.Text = config.TaxaCrossover.ToString();
                txtMutacao.Text = config.TaxaMutacao.ToString();
                txtPopulacao.Text = config.TotalPopulacao.ToString();
                txtGeracoes.Text = config.TotalGeracao.ToString();
                config.IdConfig = id;
            }
        }
        #endregion

        #region Sair
        private void Sair()
        {
            HttpContext.Current.Session.Clear();
            HttpContext.Current.Session.RemoveAll();
            HttpContext.Current.Session.Abandon();
            HttpContext.Current.Response.Redirect("Login.aspx");
        }

        protected void sairNavbar_ServerClick(object sender, EventArgs e)
        {
            Sair();
        }

        [WebMethod]
        public static void Logoff()
        {
            HttpContext.Current.Session.Clear();
            HttpContext.Current.Session.RemoveAll();
            HttpContext.Current.Session.Abandon();
            //HttpContext.Current.Response.Redirect("Login.aspx");
        }
        #endregion

        #region SalvarConfig
        [WebMethod]
        public static string salvarConfiguracoes(string solucao, string crossover, string mutacao, string populacao, string geracao)
        {
            try
            {
                DAO dao = new DAO();

                if (config != null)
                {
                    //Monta a config
                    config.SolucaoMax = Convert.ToDouble(solucao);
                    config.TaxaCrossover = Convert.ToDouble(crossover);
                    config.TaxaMutacao = Convert.ToDouble(mutacao);
                    //config.Eltismo = Convert.ToBoolean();
                    config.TotalPopulacao = Convert.ToInt32(populacao);
                    config.TotalGeracao = Convert.ToInt32(geracao);

                    dao.EdtConfig(config); //existe, update!
                }
                else
                {
                    //Monta a config
                    config.SolucaoMax = Convert.ToDouble(solucao);
                    config.TaxaCrossover = Convert.ToDouble(crossover);
                    config.TaxaMutacao = Convert.ToDouble(mutacao);
                    //config.Eltismo = Convert.ToBoolean();
                    config.TotalPopulacao = Convert.ToInt32(populacao);
                    config.TotalGeracao = Convert.ToInt32(geracao);

                    config.IdConfig = idUserStatic; //add a ID na config pois ainda nao existe no banco

                    dao.AddConfig(config); //não existe, insert!
                }

                return "True";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        #endregion

        #region FecharConfig
        [WebMethod]
        public string ReturnConfigFechar()
        {
            txtCrossover.Text = config.TaxaCrossover.ToString();
            txtDefineSolucao.Text = config.SolucaoMax.ToString();
            txtGeracoes.Text = config.TotalGeracao.ToString();
            txtMutacao.Text = config.TaxaMutacao.ToString();
            txtPopulacao.Text = config.TotalPopulacao.ToString();

            return "True";
        }

        protected void btnFecharModalConfig_Click(object sender, EventArgs e)
        {
            txtCrossover.Text = config.TaxaCrossover.ToString();
            txtDefineSolucao.Text = config.SolucaoMax.ToString();
            txtGeracoes.Text = config.TotalGeracao.ToString();
            txtMutacao.Text = config.TaxaMutacao.ToString();
            txtPopulacao.Text = config.TotalPopulacao.ToString();
        }
        #endregion

        #region PegarProxId
        [WebMethod]
        public static string PegarProximoId(string tbl)
        {
            var sequence = "";

            switch (tbl)
            {
                case "maquina":
                    sequence = "nextmaquina";
                    break;
                case "setor":
                    sequence = "nextsetor";
                    break;
                case "unidade":
                    sequence = "nextunidade";
                    break;
                case "job":
                    sequence = "nextjob";
                    break;
                case "sku":
                    sequence = "nextsku";
                    break;
                case "velocidade":
                    sequence = "nextvelocidade";
                    break;
            }

            DAO dao = new DAO();

            return dao.PegarProximoId(sequence).ToString();
        }
        #endregion

        #region Maquinas
        private void carregarMaq(int id)
        {
            DAO dao = new DAO();

            foreach (Maquina maq in dao.GetMaq(id))
            {
                ScriptManager.RegisterClientScriptBlock(this.Page, this.GetType(), "PreencheMaqs" + maq.Id_Maquina, "$( document ).ready(function() {\n$(\"#tblMaquina\").append('<tr id=\"rowMaq" + maq.Id_Maquina + "\" ><td style=\"width:85%; \"><div class=\"form-group has-feedback\" ><input type=\"text\" id =\"txtNomeMaquina" + maq.Id_Maquina + "\" name=\"txtNomeMaquina" + maq.Id_Maquina + "\" placeholder =\"Nome da Máquina\" class=\"form-control\" value =\"" + maq.Descricao + "\" disabled/><span class=\"glyphicon form-control-feedback\" id=\"spanNomeMaquina" + maq.Id_Maquina + "\"></span></div></td><td style=\"width:15%; \"><button class=\"btn btn-primary glyphicon glyphicon-pencil edtRowMaq\"></button> <button class=\"btn btn-danger glyphicon glyphicon-remove remRowMaq\"></button></td></tr>');\n$(\"#spanNomeMaquina" + maq.Id_Maquina + "\").removeClass('glyphicon-remove').addClass('glyphicon-ok').addClass('has-success');\n});\n\n", true);
            }
        }

        [WebMethod]
        public static string SalvarMaq(string id, string nome)
        {
            try
            {
                DAO dao = new DAO();

                if (dao.AddEdtMaq(new Maquina()
                {
                    idUser = idUserStatic,
                    Descricao = nome,
                    Id_Maquina = Convert.ToInt32(id)
                }))
                {
                    return "True";
                }
                else
                {
                    return "False";
                }
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        
        [WebMethod]
        public static string RemMaq(string id)
        {
            try
            {
                DAO dao = new DAO();

                int rtn = dao.RemMaq(Convert.ToInt32(id));

                if (rtn > 0)
                    return "True";
                else if (rtn == -1)
                    return "False1";
                else
                    return "False2";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        #endregion

        #region Setor
        private void carregarSetor(int id)
        {
            DAO dao = new DAO();

            foreach (Setor set in dao.GetSetor(id))
            {
                ScriptManager.RegisterClientScriptBlock(this.Page, this.GetType(), "PreencheSetores" + set.Id_Setor, "$( document ).ready(function() {\n$(\"#tblSetor\").append('<tr id=\"rowSetor" + set.Id_Setor + "\" ><td style=\"width:85%; \"><div class=\"form-group has-feedback\" ><input type=\"text\" id =\"txtNomeSetor" + set.Id_Setor + "\" name=\"txtNomeSetor" + set.Id_Setor + "\" placeholder =\"Nome do Setor\" class=\"form-control\" value =\"" + set.Descricao + "\" disabled/><span class=\"glyphicon form-control-feedback\" id=\"spanNomeSetor" + set.Id_Setor + "\"></span></div></td><td style=\"width:15%; \"><button class=\"btn btn-primary glyphicon glyphicon-pencil edtRowSetor\"></button> <button class=\"btn btn-danger glyphicon glyphicon-remove remRowSetor\"></button></td></tr>');\n$(\"#spanNomeSetor" + set.Id_Setor + "\").removeClass('glyphicon-remove').addClass('glyphicon-ok').addClass('has-success');\n});\n\n", true);
            }
        }

        [WebMethod]
        public static string SalvarSetor(string id, string nome)
        {
            try
            {
                DAO dao = new DAO();

                if (dao.AddEdtSetor(new Setor()
                {
                    idUser = idUserStatic,
                    Descricao = nome,
                    Id_Setor = Convert.ToInt32(id)
                }))
                {
                    return "True";
                }
                else
                {
                    return "False";
                }
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        [WebMethod]
        public static string RemSetor(string id)
        {
            try
            {
                DAO dao = new DAO();

                int rtn = dao.RemSetor(Convert.ToInt32(id));

                if (rtn > 0)
                    return "True";
                else if (rtn == -1)
                    return "False1";
                else
                    return "False2";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        #endregion

        #region Sku
        private void carregarSku(int id)
        {
            DAO dao = new DAO();

            foreach (Sku sku in dao.GetSku(id))
            {
                ScriptManager.RegisterClientScriptBlock(this.Page, this.GetType(), "PreencheSkus" + sku.Id_Sku, "$( document ).ready(function() { \n $(\"#tblSku\").append('<tr id=\"rowSku" + sku.Id_Sku + "\"><td style=\"width:55 %; \"><div class=\"form-group has-feedback\"><input type=\"text\" id=\"txtNomeSku" + sku.Id_Sku + "\" name=\"txtNomeSku" + sku.Id_Sku + "\" placeholder=\"Nome do Sku\" class=\"form-control\" value=\""+ sku.Descricao + "\" disabled /><span class=\"glyphicon form-control-feedback\" id=\"spanNomeSku" + sku.Id_Sku + "\"></span></div></td><td style=\"width: 30 %; \"><div class=\"form-group has-feedback\"><input type=\"text\" id=\"txtPesoSku" + sku.Id_Sku + "\" name=\"txtPesoSku" + sku.Id_Sku + "\" placeholder=\"Peso do Sku\" class=\"form-control\" value=\"" + sku.Peso_Caixa + "\" disabled /><span class=\"glyphicon form-control-feedback\" id=\"spanPesoSku" + sku.Id_Sku + "\"></span></div></td><td style=\"width: 15 %; \"><button class=\"btn btn-primary glyphicon glyphicon-pencil edtRowSku\"></button> <button class=\"btn btn-danger glyphicon glyphicon-remove remRowSku\"></button></td></tr>'); $(\"#spanNomeSku" + sku.Id_Sku + "\").removeClass('glyphicon-remove').addClass('glyphicon-ok').addClass('has-success'); $(\"#spanPesoSku" + sku.Id_Sku + "\").removeClass('glyphicon-remove').addClass('glyphicon-ok').addClass('has-success'); });\n\n", true);
            }
        }

        [WebMethod]
        public static string SalvarSku(string id, string nome, string peso)
        {
            try
            {
                DAO dao = new DAO();

                if (dao.AddEdtSku(new Sku()
                {
                    idUser = idUserStatic,
                    Descricao = nome,
                    Id_Sku = Convert.ToInt32(id),
                    Peso_Caixa = Convert.ToDouble(peso)
                }))
                {
                    return "True";
                }
                else
                {
                    return "False";
                }
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        [WebMethod]
        public static string RemSku(string id)
        {
            try
            {
                DAO dao = new DAO();

                int rtn = dao.RemSku(Convert.ToInt32(id));

                if (rtn > 0)
                    return "True";
                else if (rtn == -1)
                    return "False1";
                else
                    return "False2";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        #endregion

        #region Unidade
        private void carregarUnidade(int id)
        {
            DAO dao = new DAO();

            foreach (Unidade un in dao.GetUnidade(id))
            {
                ScriptManager.RegisterClientScriptBlock(this.Page, this.GetType(), "PreencheUnidade" + un.Codigo_Un, "$( document ).ready(function() { \n $(\"#tblUnidade\").append('<tr id=\"rowUnidade" + un.Codigo_Un + "\"><td style=\"width:55 %; \"><div class=\"form-group has-feedback\"><input type=\"text\" id=\"txtCodUnidade" + un.Codigo_Un + "\" name=\"txtCodUnidade" + un.Codigo_Un + "\" placeholder=\"Código da Unidade\" class=\"form-control\" value=\"" + un.Codigo_Un + "\" disabled /><span class=\"glyphicon form-control-feedback\" id=\"spanCodUnidade" + un.Codigo_Un + "\"></span></div></td><td style=\"width: 30 %; \"><div class=\"form-group has-feedback\"><input type=\"text\" id=\"txtNomeUnidade" + un.Codigo_Un + "\" name=\"txtNomeUnidade" + un.Codigo_Un + "\" placeholder=\"Nome da Unidade\" class=\"form-control\" value=\"" + un.Descricao + "\" disabled /><span class=\"glyphicon form-control-feedback\" id=\"spanNomeUnidade" + un.Codigo_Un + "\"></span></div></td><td style=\"width: 15 %; \"><button class=\"btn btn-primary glyphicon glyphicon-pencil edtRowUnidade\"></button> <button class=\"btn btn-danger glyphicon glyphicon-remove remRowUnidade\"></button></td></tr>'); $(\"#spanCodUnidade" + un.Codigo_Un + "\").removeClass('glyphicon-remove').addClass('glyphicon-ok').addClass('has-success'); $(\"#spanNomeUnidade" + un.Codigo_Un + "\").removeClass('glyphicon-remove').addClass('glyphicon-ok').addClass('has-success'); });\n\n", true);
            }
        }

        [WebMethod]
        public static string SalvarUnidade(string cod, string nome)
        {
            try
            {
                DAO dao = new DAO();

                if (dao.AddEdtUnidade(new Unidade()
                {
                    idUser = idUserStatic,
                    Descricao = nome,
                    Codigo_Un = cod
                }))
                {
                    return "True";
                }
                else
                {
                    return "False";
                }
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        [WebMethod]
        public static string RemUnidade(string cod)
        {
            try
            {
                DAO dao = new DAO();

                int rtn = dao.RemUnidade(cod, idUserStatic);

                if (rtn > 0)
                    return "True";
                else if (rtn == -1)
                    return "False1";
                else
                    return "False2";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        #endregion

        #region Job
        private void carregarJob(int id)
        {
            DAO dao = new DAO();

            foreach (Job job in dao.GetJob(id))
            {
                ScriptManager.RegisterClientScriptBlock(this.Page, this.GetType(), "PreencheJobs" + job.Id_Job, "$( document ).ready(function() { \n $(\"#tblJob\").append('<tr id=\"rowJob" + job.Id_Job + "\"><td><div class=\"form-group has-feedback\"><select id=\"selJobSku" + job.Id_Job + "\" class=\"form-control\" disabled></select><span class=\"glyphicon form-control-feedback\" id=\"spanJobSku" + job.Id_Job + "\"></span></div></td><td><div class=\"form-group has-feedback\"><input type=\"text\" id=\"txtQtdeJob" + job.Id_Job + "\" name=\"txtQtdeJob" + job.Id_Job + "\" placeholder=\"Quantidade da Job\" class=\"form-control\" value=\"" + job.Qtde + "\" disabled /><span class=\"glyphicon form-control-feedback\" id=\"spanQtdeJob" + job.Id_Job + "\"></span></div></td><td style=\"width:15 %; \"><button class=\"btn btn-primary glyphicon glyphicon-pencil edtRowJob\"></button> <button class=\"btn btn-danger glyphicon glyphicon-remove remRowJob\"></button></td></tr>'); $(\"#spanJobSku" + job.Id_Job + "\").removeClass('glyphicon-remove').addClass('glyphicon-ok').addClass('has-success'); $(\"#spanQtdeJob" + job.Id_Job + "\").removeClass('glyphicon-remove').addClass('glyphicon-ok').addClass('has-success'); });\n\n", true);

                var seletor = "#selJobSku" + job.Id_Job;

                carregarComboBoxSkuParaJob(seletor, job.Sku.Id_Sku);
            }
        }

        public void carregarComboBoxSkuParaJob(string seletor, int idSku)
        {
            try
            {
                DAO dao = new DAO();

                List<Sku> lstSku = dao.GetSku(idUserStatic);

                foreach (Sku sku in lstSku)
                {
                    if(sku.Id_Sku == idSku)
                        ScriptManager.RegisterClientScriptBlock(this.Page, this.GetType(), "PreencheJobs" + sku.Id_Sku, "$(document).ready(function() { $(\"" + seletor + "\").append('<option name=\"selJobSku\" value=\"" + sku.Id_Sku + "\" selected>"+ sku.Descricao +"</option>'); });", true);
                    else
                        ScriptManager.RegisterClientScriptBlock(this.Page, this.GetType(), "PreencheJobs" + sku.Id_Sku, "$(document).ready(function() { $(\"" + seletor + "\").append('<option name=\"selJobSku\" value=\"" + sku.Id_Sku + "\">" + sku.Descricao + "</option>'); });", true);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [WebMethod]
        public static List<Sku> CarregarSelectSkuJob(string seletor)
        {
            DAO dao = new DAO();

            return dao.GetSku(idUserStatic);
        }

        [WebMethod]
        public static string SalvarJob(int idjob, int idsku, string qtde)
        {
            try
            {
                DAO dao = new DAO();

                if (dao.AddEdtJob(new Job()
                {
                    idUser = idUserStatic,
                    Id_Job = idjob,
                    Sku = new Sku() { Id_Sku = idsku },
                    Qtde = Convert.ToDouble(qtde)
                }))
                {
                    return "True";
                }
                else
                {
                    return "False";
                }
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        [WebMethod]
        public static string RemJob(int id)
        {
            try
            {
                DAO dao = new DAO();

                int rtn = dao.RemJob(id);

                if (rtn > 0)
                    return "True";
                else if (rtn == -1)
                    return "False1";
                else
                    return "False2";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        #endregion

        #region Velocidade
        private void carregarVelocidade(int id)
        {
            DAO dao = new DAO();

            foreach (Velocidade vel in dao.GetVel(id))
            {
                ScriptManager.RegisterClientScriptBlock(this.Page, this.GetType(), "PreencheVelocidades" + vel.Id_Velocidade, "$( document ).ready(function() { \n $(\"#tblVelocidade\").append('<tr id=\"rowVelocidade" + vel.Id_Velocidade + "\"><td style=\"width: 20 %; \"><div class=\"form-group has-feedback\"><select id=\"selVelMaq" + vel.Id_Velocidade + "\" class=\"form-control\" disabled></select><span class=\"glyphicon form-control-feedback\" id=\"spanVelMaq" + vel.Id_Velocidade + "\"></span></div></td><td style=\"width: 20 %; \"><div class=\"form-group has-feedback\"><select id=\"selVelSetor" + vel.Id_Velocidade + "\" class=\"form-control\" disabled></select><span class=\"glyphicon form-control-feedback\" id=\"spanVelSetor" + vel.Id_Velocidade + "\"></span></div></td><td style=\"width: 20 %; \"><div class=\"form-group has-feedback\"><select id=\"selVelSku" + vel.Id_Velocidade + "\" class=\"form-control\" disabled></select><span class=\"glyphicon form-control-feedback\" id=\"spanVelSku" + vel.Id_Velocidade + "\"></span></div></td><td style=\"width: 20 %; \"><div class=\"form-group has-feedback\"><input type=\"text\" id=\"txtVelVelocidade" + vel.Id_Velocidade + "\" name=\"txtVelVelocidade" + vel.Id_Velocidade + "\" placeholder=\"Velocidade por hora\" class=\"form-control\" value=\"" + vel.Velocidade_Hr + "\" disabled /><span class=\"glyphicon form-control-feedback\" id=\"spanVelVelocidade" + vel.Id_Velocidade + "\"></span></div></td><td style=\"width:20 %; \"><button class=\"btn btn-primary glyphicon glyphicon-pencil edtRowVelocidade\"></button> <button class=\"btn btn-danger glyphicon glyphicon-remove remRowVelocidade\"></button></td></tr>'); $(\"#spanVelMaq" + vel.Id_Velocidade + "\").removeClass('glyphicon-remove').addClass('glyphicon-ok').addClass('has-success'); $(\"#spanVelSetor" + vel.Id_Velocidade + "\").removeClass('glyphicon-remove').addClass('glyphicon-ok').addClass('has-success'); $(\"#spanVelSku" + vel.Id_Velocidade + "\").removeClass('glyphicon-remove').addClass('glyphicon-ok').addClass('has-success'); $(\"#spanVelVelocidade" + vel.Id_Velocidade + "\").removeClass('glyphicon-remove').addClass('glyphicon-ok').addClass('has-success'); });\n\n", true);

                var seletor = "#selVelMaq" + vel.Id_Velocidade;
                var seletor2 = "#selVelSetor" + vel.Id_Velocidade;
                var seletor3 = "#selVelSku" + vel.Id_Velocidade;

                carregarComboBoxMaqParaVel(seletor, vel.Maquina.Id_Maquina);
                carregarComboBoxSetorParaVel(seletor2, vel.Setor.Id_Setor);
                carregarComboBoxSkuParaVel(seletor3, vel.Sku.Id_Sku);
            }
        }

        public void carregarComboBoxMaqParaVel(string seletor, int idMaq)
        {
            try
            {
                DAO dao = new DAO();

                List<Maquina> lstMaq = dao.GetMaq(idUserStatic);

                foreach (Maquina maq in lstMaq)
                {
                    if (maq.Id_Maquina == idMaq)
                        ScriptManager.RegisterClientScriptBlock(this.Page, this.GetType(), "PreencheVelMaq" + maq.Id_Maquina, "$(document).ready(function() { $(\"" + seletor + "\").append('<option name=\"selVelMaq\" value=\"" + maq.Id_Maquina + "\" selected>" + maq.Descricao + "</option>'); });", true);
                    else
                        ScriptManager.RegisterClientScriptBlock(this.Page, this.GetType(), "PreencheVelMaq" + maq.Id_Maquina, "$(document).ready(function() { $(\"" + seletor + "\").append('<option name=\"selVelMaq\" value=\"" + maq.Id_Maquina + "\">" + maq.Descricao + "</option>'); });", true);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void carregarComboBoxSetorParaVel(string seletor, int idSetor)
        {
            try
            {
                DAO dao = new DAO();

                List<Setor> lstSetor = dao.GetSetor(idUserStatic);

                foreach (Setor set in lstSetor)
                {
                    if (set.Id_Setor == idSetor)
                        ScriptManager.RegisterClientScriptBlock(this.Page, this.GetType(), "PreencheVelSetor" + set.Id_Setor, "$(document).ready(function() { $(\"" + seletor + "\").append('<option name=\"selVelSetor\" value=\"" + set.Id_Setor + "\" selected>" + set.Descricao + "</option>'); });", true);
                    else
                        ScriptManager.RegisterClientScriptBlock(this.Page, this.GetType(), "PreencheVelSetor" + set.Id_Setor, "$(document).ready(function() { $(\"" + seletor + "\").append('<option name=\"selVelSetor\" value=\"" + set.Id_Setor + "\">" + set.Descricao + "</option>'); });", true);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void carregarComboBoxSkuParaVel(string seletor, int idSku)
        {
            try
            {
                DAO dao = new DAO();

                List<Sku> lstSku = dao.GetSku(idUserStatic);

                foreach (Sku sku in lstSku)
                {
                    if (sku.Id_Sku == idSku)
                        ScriptManager.RegisterClientScriptBlock(this.Page, this.GetType(), "PreencheVelSku" + sku.Id_Sku, "$(document).ready(function() { $(\"" + seletor + "\").append('<option name=\"selVelSku\" value=\"" + sku.Id_Sku + "\" selected>" + sku.Descricao + "</option>'); });", true);
                    else
                        ScriptManager.RegisterClientScriptBlock(this.Page, this.GetType(), "PreencheVelSku" + sku.Id_Sku, "$(document).ready(function() { $(\"" + seletor + "\").append('<option name=\"selVelSku\" value=\"" + sku.Id_Sku + "\">" + sku.Descricao + "</option>'); });", true);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [WebMethod]
        public static List<Maquina> CarregarSelectVelMaq(string seletor)
        {
            DAO dao = new DAO();

            return dao.GetMaq(idUserStatic);
        }

        [WebMethod]
        public static List<Setor> CarregarSelectVelSetor(string seletor)
        {
            DAO dao = new DAO();

            return dao.GetSetor(idUserStatic);
        }

        [WebMethod]
        public static List<Sku> CarregarSelectVelSku(string seletor)
        {
            DAO dao = new DAO();

            return dao.GetSku(idUserStatic);
        }

        [WebMethod]
        public static string SalvarVelocidade(int idvel, int maq, int setor, int sku, string vel)
        {
            try
            {
                DAO dao = new DAO();

                if (dao.AddEdtVel(new Velocidade()
                {
                    idUser = idUserStatic,
                    Id_Velocidade = idvel,
                    Maquina = new Maquina() { Id_Maquina = maq},
                    Setor = new Setor() { Id_Setor = setor},
                    Sku = new Sku() { Id_Sku = sku},
                    Velocidade_Hr = Convert.ToDouble(vel)
                }))
                {
                    return "True";
                }
                else
                {
                    return "False";
                }
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        [WebMethod]
        public static string RemVelocidade(int id)
        {
            try
            {
                DAO dao = new DAO();

                int rtn = dao.RemVel(id);

                if (rtn > 0)
                    return "True";
                else if (rtn == -1)
                    return "False1";
                else
                    return "False2";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        #endregion

        #region AlterarSenha
        [WebMethod]
        public static string AlterarSenha(string senha, string newsenha, string newsenha2)
        {
            try
            {
                DAO dao = new DAO();

                int rtn = dao.AlterarSenha(new AlterarSenha() {
                    idUser = idUserStatic,
                    Senha = senha,
                    SenhaNova = newsenha,
                    SenhaNova2 = newsenha2
                });

                if (rtn > 0)
                    return "True";
                else if (rtn == -1)
                    return "False1";
                else if (rtn == 0)
                    return "False2";
                else
                    return "False";

            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        #endregion
    }
}