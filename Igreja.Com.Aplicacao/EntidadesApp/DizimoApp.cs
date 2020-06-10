using Igreja.Com.Aplicacao.InterfaceApp;
using Igreja.Com.Dominio.Entidades;
using Igreja.Com.Dominio.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace Igreja.Com.Aplicacao.EntidadesApp
{
    public class DizimoApp : InterfaceDizimoApp
    {
        private readonly InterfaceDizimo _interfaceDizimo;

        public DizimoApp(InterfaceDizimo interfaceDizimo)
        {
            _interfaceDizimo = interfaceDizimo;
        }

        public void Add(Dizimo Objeto)
        {
            _interfaceDizimo.Add(Objeto);
        }

        public int AddRetorno(Dizimo Objeto)
        {
            int dados = _interfaceDizimo.AddRetorno(Objeto);
            return dados;
        }

        public void Delete(Dizimo Objeto)
        {
            throw new NotImplementedException();
        }

        public Dizimo GetEntityById(int Id)
        {
            return _interfaceDizimo.GetEntityById(Id);
        }

        public List<Dizimo> List()
        {
            return _interfaceDizimo.List();
        }

        public List<Dizimo> ListDizimo()
        {
            return _interfaceDizimo.ListDizimo();
        }

        public void Update(Dizimo Objeto)
        {
            _interfaceDizimo.Update(Objeto);
        }
    }
}
