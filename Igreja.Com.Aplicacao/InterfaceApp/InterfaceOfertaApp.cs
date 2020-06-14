using Igreja.Com.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace Igreja.Com.Aplicacao.InterfaceApp
{
    public interface InterfaceOfertaApp : InterfaceBaseApp<Oferta>
    {
        decimal CalculaSaldo();
        decimal DescontarDespesa(decimal valor);
        int AddRetornoOferta(Oferta objeto);
    }
}
