using Igreja.Com.Aplicacao.InterfaceApp;
using Igreja.Com.Dominio.Entidades;
using Igreja.Com.Dominio.Interface;
using System.Collections.Generic;

namespace Igreja.Com.Aplicacao.EntidadesApp
{
    public class CaixaApp:InterfaceCaixaApp
    {
        private readonly InterfaceCaixa _interfaceCaixa;

        public CaixaApp( InterfaceCaixa interfaceCaixa)
        {
            _interfaceCaixa = interfaceCaixa;
        }

        public void Add(Caixa Objeto)
        {
            throw new System.NotImplementedException();
        }

        public decimal BuscarSaldo()
        {
            return _interfaceCaixa.BuscarSaldo();
        }

        public void Delete(Caixa Objeto)
        {
            throw new System.NotImplementedException();
        }

        public Caixa GetEntityById(int Id)
        {
            throw new System.NotImplementedException();
        }

        public List<Caixa> List()
        {
            throw new System.NotImplementedException();
        }

        public void Update(Caixa Objeto)
        {
            throw new System.NotImplementedException();
        }
    }
}
