using System;
using System.Collections.Generic;
using System.Text;

namespace Igreja.Com.Dominio.Entidades
{
    public class Oferta : Base
    {
        public int CultoId { get; set; }
        public Culto Culto { get; set; }
        public CategoriaOferta CategoriaOferta { get; set; }
        public string Observacao { get; set; }
        public decimal Valor { get; set; }
        public decimal Saldo { get; set; }
        public DateTime DataCadastro { get; set; }
    }
}
