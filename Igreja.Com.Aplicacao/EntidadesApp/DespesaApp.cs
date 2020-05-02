using Igreja.Com.Aplicacao.InterfaceApp;
using Igreja.Com.Dominio.Entidades;
using Igreja.Com.Dominio.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace Igreja.Com.Aplicacao.EntidadesApp
{
    public class DespesaApp : InterfaceDespesaApp
    {
        private readonly InterfaceDespesa _interfaceDespesa;

        public DespesaApp(InterfaceDespesa interfaceDespesa)
        {
            this._interfaceDespesa = interfaceDespesa;
        }
        public void Add(Despesa Objeto)
        {

            _interfaceDespesa.Add(Objeto);
        }

        public decimal CalculaSaldo()
        {
            return _interfaceDespesa.CalculaSaldo();
        }

        public void Delete(Despesa Objeto)
        {
            throw new NotImplementedException();
        }

        public Despesa GetEntityById(int Id)
        {
            throw new NotImplementedException();
        }

        public List<Despesa> List()
        {
            return _interfaceDespesa.List();
        }

        public void Update(Despesa Objeto)
        {
            throw new NotImplementedException();
        }
    }
}
