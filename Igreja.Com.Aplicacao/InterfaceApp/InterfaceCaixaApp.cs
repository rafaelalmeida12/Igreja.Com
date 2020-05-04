using Igreja.Com.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace Igreja.Com.Aplicacao.InterfaceApp
{
    public interface InterfaceCaixaApp : InterfaceBaseApp<Caixa>
    {
        Caixa BuscarSaldoDoMes(DateTime date);
     
    }
}
