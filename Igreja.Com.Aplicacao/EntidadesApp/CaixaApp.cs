using Igreja.Com.Aplicacao.InterfaceApp;
using Igreja.Com.Dominio.Entidades;
using Igreja.Com.Dominio.Interface;
using System;
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

        #region CRUD
        public void Add(Caixa Objeto)
        {
            _interfaceCaixa.Add(Objeto);
        }
        public void Update(Caixa Objeto)
        {
            _interfaceCaixa.Update(Objeto);
        }
        public void Delete(Caixa Objeto)
        {
            _interfaceCaixa.Delete(Objeto);
        }


        #endregion

        public Caixa BuscarSaldoDoMes(DateTime date)
        {
            return _interfaceCaixa.BuscarSaldoDoMes(date);
        }

        public decimal BuscarSaldoMes(DateTime dateTime)
        {
            throw new NotImplementedException();
        }


        public Caixa GetEntityById(int Id)
        {
            throw new System.NotImplementedException();
        }

        public List<Caixa> List()
        {
            throw new System.NotImplementedException();
        }

        public int AddRetorno(Caixa Objeto)
        {
            throw new NotImplementedException();
        }
    }
}
