using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Objetos
{
    public class Usuario
    {
        public int idUsuario { get; set; }
        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        public string User { get; set; }
        public string Senha { get; set; }
        public string Senha2 { get; set; }
        public string Email { get; set; }
        public Plano Plano { get; set; }
    }
}
