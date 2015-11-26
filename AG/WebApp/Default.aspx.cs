using Acesso;
using Objetos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApp
{
    public partial class index : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        [WebMethod]
        public static String CadUser(string nome, string sobrenome, string user, string senha, string senha2, string email)
        {
            Usuario newUser = new Usuario();

            newUser.Nome = nome;
            newUser.Sobrenome = sobrenome;
            newUser.User = user;
            newUser.Senha = senha;
            newUser.Senha2 = senha2;
            newUser.Email = email;
            newUser.Plano = new Plano() { IdPlano = 1 };

            DAO dao = new DAO();
            if (dao.AddUser(newUser) > 0)
                return "True";
            else
                return "False";
        }
    }
}