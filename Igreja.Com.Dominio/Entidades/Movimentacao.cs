using Igreja.Com.Dominio.Entidades.Enum;
using System;
using System.Collections.Generic;
using System.Text;

namespace Igreja.Com.Dominio.Entidades
{
    public class Movimentacao:Base
    {
        public decimal ValorTotal { get; set; }
        public TipoDespesa TipoDespesa { get; set; }
        public int Id_Movimentacoes { get; set; }
        public DateTime Data { get; set; }
        public string Pessoa { get; set; }
        public decimal Valor { get; set; }


    }
}
