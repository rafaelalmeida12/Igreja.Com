using Igreja.Com.Aplicacao.InterfaceApp;
using Igreja.Com.Dominio.Interface;
using System.Collections.Generic;

namespace Igreja.Com.Aplicacao.EntidadesApp
{
    public class CategoriaOferta : InterfaceCategoriaOfertaApp
    {
        InterfaceCategoriaOferta _InterfaceCategoriaOfertaApp;

        public CategoriaOferta(InterfaceCategoriaOferta InterfaceCategoriaOfertaApp)
        {
            _InterfaceCategoriaOfertaApp = InterfaceCategoriaOfertaApp;
        }
        public void Add(Dominio.Entidades.CategoriaOferta Objeto)
        {
           _InterfaceCategoriaOfertaApp.Add(Objeto);
        }

        public void Delete(Dominio.Entidades.CategoriaOferta Objeto)
        {
            _InterfaceCategoriaOfertaApp.Delete(Objeto);
        }

        public Dominio.Entidades.CategoriaOferta GetEntityById(int Id)
        {
          return  _InterfaceCategoriaOfertaApp.GetEntityById(Id);
        }

        public List<Dominio.Entidades.CategoriaOferta> List()
        {
            return _InterfaceCategoriaOfertaApp.List();
        }

        public void Update(Dominio.Entidades.CategoriaOferta Objeto)
        {
            _InterfaceCategoriaOfertaApp.Update(Objeto);
        }
    }
}
