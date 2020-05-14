using Igreja.Com.Aplicacao.InterfaceApp;
using Igreja.Com.Dominio.Entidades;
using Igreja.Com.Dominio.Interface;
using Igreja.Com.Dominio.InterfaceServico;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Igreja.Com.Aplicacao.EntidadesApp
{
    public class MembroApp : InterfaceMembroApp
    {
        private readonly InterfaceMembro interfaceMembro;
        private readonly InterfaceServicoMembro interfaceServico;

        public MembroApp(InterfaceMembro interfaceMembro, InterfaceServicoMembro interfaceServico)
        {
            this.interfaceMembro = interfaceMembro;
            this.interfaceServico = interfaceServico;
        }

        public void Add(Membro Objeto)
        {
            interfaceMembro.Add(Objeto);
        }

        public void Delete(Membro Objeto)
        {
            throw new NotImplementedException();
        }

        public int BuscarTotalMembros(int IgrejaId)
        {

            return interfaceMembro.BuscarTotalMembros(IgrejaId);
        }


        public List<Membro> GetAll(int igrejaId)
        {
            return interfaceMembro.GetAll(igrejaId);
        }

        public Membro GetEntityById(int Id)
        {
            return interfaceMembro.GetEntityById(Id);
        }

        public List<Membro> List()
        {
            return interfaceMembro.List();
        }

        public void Update(Membro Objeto)
        {
            interfaceMembro.Update(Objeto);
        }

        #region servicos
        public async Task EhValido(Membro membro)
        {
            await interfaceServico.EhValido(membro);
        }

        public bool Existe(Membro membro)
        {
            return interfaceServico.Existe(membro);
        }

        public Membro BuscarPorId(int Id)
        {
            return interfaceMembro.BuscarPorId(Id);
        }

        public IList<Membro> BuscarAniversariantes(DateTime dateTime)
        {
            return interfaceMembro.BuscarAniversariantes(dateTime);
        }


        #endregion
    }
}
