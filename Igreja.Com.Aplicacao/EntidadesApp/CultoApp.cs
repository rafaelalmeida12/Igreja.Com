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
        private readonly InterfaceCulto interfaceCulto;

        public CultoApp(InterfaceCulto interfaceCulto)
        {
            this.interfaceCulto = interfaceCulto;
        }

        public void Add(Culto Objeto)
        {
            interfaceCulto.Add(Objeto);
        }

        public void Delete(Culto Objeto)
        {
            throw new NotImplementedException();
        }

        public List<Culto> GetAll()
        {
            return interfaceCulto.GetAll();
        }

        public Culto GetEntityById(int Id)
        {
            return interfaceCulto.GetEntityById(Id);
        }

        public List<Culto> List()
        {
            return interfaceCulto.List();
        }

        public void Update(Culto Objeto)
        {
            interfaceCulto.Update(Objeto);
        }
    }
}
