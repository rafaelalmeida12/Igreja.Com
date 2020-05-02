using System;
using System.Collections.Generic;
using System.Text;

namespace Igreja.Com.Dominio.Entidades
{
    public class Caixa : Base
    {
        public Oferta oferta { get; set; }
        public Despesa despesa { get; set; }
        public decimal Saldo { get; set; }
    }
}
