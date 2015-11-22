using Objetos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApp
{
    public partial class index : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnCadastrar_ServerClick(object sender, EventArgs e)
        {
            Usuario newUser = new Usuario();

            newUser.Nome = txtCadNome.Text;
            newUser.Sobrenome = txtCadSobrenome.Text;
            newUser.User = txtCadUsuario.Text;
            newUser.Senha = txtCadSenha.Text;
            newUser.Senha2 = txtCadSenha2.Text;
            newUser.Email = txtCadEmail.Text;
            newUser.Plano = new Plano() { IdPlano = 1 };
        }
    }
}