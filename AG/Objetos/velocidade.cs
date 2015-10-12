using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Objetos
{
    public class Velocidade
    {
        public int Id_Velocidade { get; set; }
        public Setor Setor { get; set; }
        public Maquina Maquina { get; set; }
        public Sku Sku { get; set; }
        public double Velocidade_Hr { get; set; }
        public int idUser { get; set; }
    }
}
