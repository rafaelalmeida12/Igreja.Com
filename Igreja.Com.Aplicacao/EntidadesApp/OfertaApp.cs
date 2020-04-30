using Igreja.Com.Aplicacao.InterfaceApp;
using Igreja.Com.Dominio.Entidades;
using Igreja.Com.Dominio.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace Igreja.Com.Aplicacao.EntidadesApp
{
    public class OfertaApp : InterfaceOfertaApp
    {
        InterfaceOferta _interfaceOferta;
        public OfertaApp(InterfaceOferta interfaceOferta)
        {
            _interfaceOferta = interfaceOferta;
        }
        public void Add(Oferta Objeto)
        {
            _interfaceOferta.Add(Objeto);
        }

        public void Delete(Oferta Objeto)
        {
            throw new NotImplementedException();
        }

        public Oferta GetEntityById(int Id)
        {
            throw new NotImplementedException();
        }

        public List<Oferta> List()
        {
          return  _interfaceOferta.List();
        }

        public void Update(Oferta Objeto)
        {
            throw new NotImplementedException();
        }
    }
}
