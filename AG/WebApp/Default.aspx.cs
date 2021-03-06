﻿using Acesso;
using Objetos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;
using log4net;

namespace WebApp
{
    public partial class index : System.Web.UI.Page
    {
        private static ILog log = LogManager.GetLogger(typeof(Log));

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
            {
                log.Info("Cadastro realizado com sucesso!");
                return "True";
            }
            else
            {
                return "False";
            }

            //log.Debug("Debugging message");
            //log.Info("Info message");
            //log.Warn("Warning message");
            //log.Error("Error message");
            //log.Fatal("Fatal message");
        }
    }
}