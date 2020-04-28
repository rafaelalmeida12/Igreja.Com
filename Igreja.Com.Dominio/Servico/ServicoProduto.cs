using Igreja.Com.Dominio.Entidades;
using Igreja.Com.Dominio.Interface;
using Igreja.Com.Dominio.InterfaceServico;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Igreja.Com.Dominio.Servico
{
    public class ServicoProduto : InterfaceServicoMembro
    {
        InterfaceMembro _interfaceMembro;

        public ServicoProduto(InterfaceMembro interfaceMembro)
        {
            interfaceMembro = _interfaceMembro;
        }
        public Task EhValido(Membro membro)
        {
            //chama as validações
            throw new NotImplementedException();
        }

        public bool Existe(Membro membro)
        {
            throw new NotImplementedException();
        }
    }
}
