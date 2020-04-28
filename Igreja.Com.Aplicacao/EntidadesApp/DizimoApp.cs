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
        private readonly InterfaceDizimo interfaceDizimo;

        public DizimoApp(InterfaceDizimo interfaceDizimo)
        {
            this.interfaceDizimo = interfaceDizimo;
        }

        public void Add(Dizimo Objeto)
        {
            interfaceDizimo.Add(Objeto);
        }

        public void Delete(Dizimo Objeto)
        {
            throw new NotImplementedException();
        }

        public Dizimo GetEntityById(int Id)
        {
            return interfaceDizimo.GetEntityById(Id);
        }

        public List<Dizimo> List()
        {
            return interfaceDizimo.List();
        }

        public List<Dizimo> ListDizimo()
        {
            return interfaceDizimo.ListDizimo();
        }

        public void Update(Dizimo Objeto)
        {
            interfaceDizimo.Update(Objeto);
        }
    }
}
