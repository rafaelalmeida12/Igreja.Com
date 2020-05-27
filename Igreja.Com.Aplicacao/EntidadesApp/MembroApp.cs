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
        private readonly InterfaceMembro _interfaceMembro;
        private readonly InterfaceServicoMembro _interfaceServico;

        public MembroApp(InterfaceMembro interfaceMembro, InterfaceServicoMembro interfaceServico)
        {
            _interfaceMembro = interfaceMembro;
            _interfaceServico = interfaceServico;
        }

        public void Add(Membro Objeto)
        {
            _interfaceMembro.Add(Objeto);
        }

        public void Delete(Membro Objeto)
        {
            _interfaceMembro.Delete(Objeto);
        }

        public int BuscarTotalMembros(int IgrejaId)
        {

            return _interfaceMembro.BuscarTotalMembros(IgrejaId);
        }


        public List<Membro> GetAll(int igrejaId)
        {
            return _interfaceMembro.GetAll(igrejaId);
        }

        public Membro GetEntityById(int Id)
        {
            return _interfaceMembro.GetEntityById(Id);
        }

        public List<Membro> List()
        {
            return _interfaceMembro.List();
        }

        public void Update(Membro Objeto)
        {
            _interfaceMembro.Update(Objeto);
        }

        #region servicos
        public async Task EhValido(Membro membro)
        {
            await _interfaceServico.EhValido(membro);
        }

        public bool Existe(Membro membro)
        {
            return _interfaceServico.Existe(membro);
        }

        public Membro BuscarPorId(int Id)
        {
            return _interfaceMembro.BuscarPorId(Id);
        }

        public IList<Membro> BuscarAniversariantes(DateTime dateTime)
        {
            return _interfaceMembro.BuscarAniversariantes(dateTime);
        }


        #endregion
    }
}
