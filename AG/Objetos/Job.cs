using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Objetos
{
    public class Job
    {
        public int Id_Job { get; set; }
        public Sku Sku { get; set; }
        public double Qtde { get; set; }
        public int idUser { get; set; }
    }
}
