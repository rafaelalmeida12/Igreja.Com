using Igreja.Com.Aplicacao.InterfaceApp;
using Igreja.Com.Dominio.Entidades;
using Igreja.Com.Dominio.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace Igreja.Com.Aplicacao.EntidadesApp
{
    public class CategoriaCultoApp:InterfaceCategoriaCultoApp
    {
        InterfaceCategoriaCulto _InterfaceCategoriaCulto;

        public CategoriaCultoApp(InterfaceCategoriaCulto InterfaceCategoriaCulto)
        {
            _InterfaceCategoriaCulto = InterfaceCategoriaCulto;
        }
        public void Add(CategoriaCulto Objeto)
        {
            _InterfaceCategoriaCulto.Add(Objeto);
        }

        public void Delete(CategoriaCulto Objeto)
        {
            _InterfaceCategoriaCulto.Delete(Objeto);
        }

        public CategoriaCulto GetEntityById(int Id)
        {
            return _InterfaceCategoriaCulto.GetEntityById(Id);
        }

        public List<CategoriaCulto> List()
        {
           return _InterfaceCategoriaCulto.List();
        }

        public void Update(CategoriaCulto Objeto)
        {
            _InterfaceCategoriaCulto.Update(Objeto);
        }
    }
}
