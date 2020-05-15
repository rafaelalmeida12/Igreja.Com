using Igreja.Com.Aplicacao.InterfaceApp;
using Igreja.Com.Dominio.Entidades;
using Igreja.Com.Dominio.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace Igreja.Com.Aplicacao.EntidadesApp
{
    public class CultoApp : InterfaceCultoApp
    {
        private readonly InterfaceCulto _interfaceCulto;

        public CultoApp(InterfaceCulto interfaceCulto)
        {
            _interfaceCulto = interfaceCulto;
        }

        public void Add(Culto Objeto)
        {
            _interfaceCulto.Add(Objeto);
        }

        public void Delete(Culto Objeto)
        {
            throw new NotImplementedException();
        }

        public List<Culto> GetAll()
        {
            return _interfaceCulto.GetAll();
        }

        public Culto GetEntityById(int Id)
        {
            return _interfaceCulto.GetEntityById(Id);
        }

        public List<Culto> List()
        {
            return _interfaceCulto.List();
        }

        public void Update(Culto Objeto)
        {
            _interfaceCulto.Update(Objeto);
        }
    }
}
