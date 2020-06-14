using Igreja.Com.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace Igreja.Com.Dominio.Interface
{
    public interface InterfaceOferta:InterfaceBase<Oferta>
    {
        decimal CalculaSaldo();
        decimal DescontarDespesa(decimal valor);
        int AddRetornoOferta(Oferta objeto);
    }
}
