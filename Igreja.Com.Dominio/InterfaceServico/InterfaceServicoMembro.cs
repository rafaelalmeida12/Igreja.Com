using Igreja.Com.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Igreja.Com.Dominio.InterfaceServico
{
    public interface InterfaceServicoMembro
    {
        bool Existe(Membro membro);
        Task EhValido(Membro membro);
    }
}
