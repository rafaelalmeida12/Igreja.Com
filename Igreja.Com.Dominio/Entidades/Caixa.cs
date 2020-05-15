using System;
using System.Collections.Generic;
using System.Text;

namespace Igreja.Com.Dominio.Entidades
{
    public class Caixa : Base
    {
        public int MovimentacaoId { get; set; }
        public Movimentacao Movimentacao { get; set; }
        public decimal SaldoAnterior { get; set; }
        public decimal SaldoAtual { get; set; }
        public bool StatusCaixa { get; set; }
    }
}
