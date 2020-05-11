using Igreja.Com.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Igreja.Com.Aplicacao.InterfaceApp
{
    public interface InterfaceMembroApp : InterfaceBaseApp<Membro>
    {
        List<Membro> GetAll(int igrejaId);
        bool Existe(Membro membro);
        Task EhValido(Membro membro);
        Membro BuscarPorId(int Id);
        IList<Membro> BuscarAniversariantes(DateTime dateTime);
    }
}
