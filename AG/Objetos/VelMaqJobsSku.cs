using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Objetos
{
    public class VelMaqJobsSku
    {
        public Velocidade Vel { get; set; }
        public Maquina Maq { get; set; }
        public Job Job { get; set; }
        public Sku Sku { get; set; }
    }
}
