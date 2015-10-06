using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Objetos
{
    public class Configuracao
    {
        public int IdConfig { get; set; }
        public double SolucaoMax { get; set; }
        public double TaxaCrossover { get; set; }
        public double TaxaMutacao { get; set; }
        public bool Eltismo { get; set; }
        public int TotalPopulacao { get; set; }
        public int TotalGeracao { get; set; }
    }
}
