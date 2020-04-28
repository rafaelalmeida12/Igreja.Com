using Igreja.Com.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace Igreja.Com.Dominio.Interface
{
    public interface InterfaceDizimo:InterfaceBase<Dizimo>
    {
        List<Dizimo> ListDizimo();
    }
}
