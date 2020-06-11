using Igreja.Com.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace Igreja.Com.Aplicacao.InterfaceApp
{
    public interface InterfaceMovimentacaoApp : InterfaceBaseApp<Movimentacao>
    {
        decimal BuscarEntradasDoMes(int month);
        decimal BuscarSaidaDoMes(int month);
    }
}
