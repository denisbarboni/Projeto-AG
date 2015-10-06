using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Objetos
{
    public class Login
    {
        public int IdLogin { get; set; }
        public string User { get; set; }
        public string Senha { get; set; }
        public Plano Plano { get; set; }
    }
}
