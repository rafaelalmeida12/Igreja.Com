using Igreja.Com.Dominio.Entidades.Enum;
using System;
using System.Collections.Generic;
using System.Text;

namespace Igreja.Com.Dominio.Entidades
{
    public class Dizimo:Base
   {
        public int MembroId { get; set; }
        public Membro Membro { get; set; }
        public int CultoId { get; set; }
        public Culto Culto { get; set; }
        public string Observacao { get; set; }
        public decimal Valor { get; set; }
        public DateTime DataCadastro { get; set; }
        public TipoFormaPagamento FormaPagamento { get; set; }
    }
}
