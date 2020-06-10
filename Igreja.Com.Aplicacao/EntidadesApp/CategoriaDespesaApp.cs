using Igreja.Com.Aplicacao.InterfaceApp;
using Igreja.Com.Dominio.Entidades;
using Igreja.Com.Dominio.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace Igreja.Com.Aplicacao.EntidadesApp
{
    public class CategoriaDespesaApp : InterfaceCategoriaDespesaApp
    {
        private readonly InterfaceCategoriaDespesa _interfaceCategoriaDespesa;

        public CategoriaDespesaApp(InterfaceCategoriaDespesa interfaceCategoriaDespesa)
        {
            _interfaceCategoriaDespesa = interfaceCategoriaDespesa;
        }
        public void Add(CategoriaDespesa Objeto)
        {
            throw new NotImplementedException();
        }

        public int AddRetorno(CategoriaDespesa Objeto)
        {
            throw new NotImplementedException();
        }

        public void Delete(CategoriaDespesa Objeto)
        {
            throw new NotImplementedException();
        }

        public CategoriaDespesa GetEntityById(int Id)
        {
            throw new NotImplementedException();
        }

        public List<CategoriaDespesa> List()
        {
            throw new NotImplementedException();
        }

        public void Update(CategoriaDespesa Objeto)
        {
            throw new NotImplementedException();
        }
    }
}
