using Igreja.Com.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace Igreja.Com.Aplicacao.InterfaceApp
{
    public interface InterfaceDespesaApp : InterfaceBaseApp<Despesa>
    {
        decimal CalculaSaldo();
        int AddRetornoDespesa(Despesa Objeto);
    }
}
