using Igreja.Com.Dominio.Entidades.Enum;
using System;
using System.Collections.Generic;
using System.Text;

namespace Igreja.Com.Dominio.Entidades
{
   public class Despesa:Base
    {
        public string NumeroNotaFiscal { get; set; }
        public decimal Valor { get; set; }
        public CategoriaDespesa categoriaDespesa { get; set; }
        public string Descricao { get; set; }
        public TipoDestinoDespesa DestinoDespesa { get; set; }
    }
}
