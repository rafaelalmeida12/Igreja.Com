using Igreja.Com.Aplicacao.InterfaceApp;
using Igreja.Com.Dominio.Entidades;
using Igreja.Com.Dominio.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace Igreja.Com.Aplicacao.EntidadesApp
{
    public class IgrejasApp : InterfaceIgrejasApp
    {
        private readonly InterfaceIgrejas _interfaceIgrejas;

        public IgrejasApp(InterfaceIgrejas interfaceIgrejas)
        {
            _interfaceIgrejas = interfaceIgrejas;
        }
        public void Add(Igrejas Objeto)
        {
            _interfaceIgrejas.Add(Objeto);
        }

        public void Delete(Igrejas Objeto)
        {
            throw new NotImplementedException();
        }

        public Igrejas GetEntityById(int Id)
        {
            throw new NotImplementedException();
        }

        public List<Igrejas> List()
        {
            return _interfaceIgrejas.List();
        }

        public void Update(Igrejas Objeto)
        {
            throw new NotImplementedException();
        }
    }
}
