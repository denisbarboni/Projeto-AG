using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Acesso;
using System.Web.Services;
using System.Web.Script.Services;

namespace WebApp
{
    public partial class login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (HttpContext.Current.Session["logado"] != null)
            {
                if (HttpContext.Current.Session["logado"].ToString() == "True")
                {
                    HttpContext.Current.Response.Redirect("Default.aspx");
                }
            }
        }

        [WebMethod(EnableSession = true)]
        public static string Logar(string user, string senha)
        {
            try
            {
                DAO dao = new DAO();

                Objetos.Login login = dao.verificarLogin(new Objetos.Login()
                {
                    User = user,
                    Senha = senha
                });

                //Objetos.Login login = new Objetos.Login();
                //login.User = "ADMIN";
                //login.Senha = "123";
                //login.Plano = new Objetos.Plano();
                //login.IdLogin = 1;

                if (login != null)
                {
                    HttpContext.Current.Session["logado"] = "True";
                    HttpContext.Current.Session["usuario"] = login.User;
                    HttpContext.Current.Session["plano"] = login.Plano;
                    HttpContext.Current.Session["idUsuario"] = login.IdLogin.ToString();

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
    }
}