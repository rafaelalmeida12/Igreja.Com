using Igreja.Com.Dominio.Entidades;
using Igreja.Com.Dominio.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace Igreja.Com.Dominio.Interface
{
    public interface InterfaceMembro : InterfaceBase<Membro>
    {
        List<Membro> GetAll(int igrejaId);
        Membro BuscarPorId(int Id);
        IList<Membro> BuscarAniversariantes(DateTime dateTime);
        int BuscarTotalMembros(int IgrejaId);
        IList<Membro> BuscarPorNome(string nome);
    }
}
