using Igreja.Com.Dominio.Entidades;
using Igreja.Com.Dominio.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace Igreja.Com.Dominio.Interface
{
    public interface InterfaceMembro : InterfaceBase<Membro>
    {
        List<Membro> GetAll();
        Membro BuscarPorId(int Id);
    }
}
