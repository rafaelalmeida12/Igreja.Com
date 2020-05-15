using System;
using System.Collections.Generic;
using System.Text;

namespace Igreja.Com.Dominio.Entidades
{
    public class Movimentacao:Base
    {
        public decimal ValorTotal { get; set; }
        public CategoriaDespesa categoriaDespesa { get; set; }
        public int CultoId { get; set; }
        public Culto Culto { get; set; }

    }
}
