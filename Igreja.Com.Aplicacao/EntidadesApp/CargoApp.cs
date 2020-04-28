using Igreja.Com.Aplicacao.InterfaceApp;
using Igreja.Com.Dominio.Entidades;
using Igreja.Com.Dominio.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace Igreja.Com.Aplicacao.EntidadesApp
{
    public class CargoApp : InterfaceCargoApp
    {
        InterfaceCargo InterfaceCargo;

        public CargoApp(InterfaceCargo interfaceCargo)
        {
            InterfaceCargo = interfaceCargo;
        }

        public void Add(Cargo Objeto)
        {
            InterfaceCargo.Add(Objeto);
        }

        public void Delete(Cargo Objeto)
        {
            throw new NotImplementedException();
        }

        public Cargo GetEntityById(int Id)
        {
            return InterfaceCargo.GetEntityById(Id);
        }

        public List<Cargo> List()
        {
            return InterfaceCargo.List();
        }

        public void Update(Cargo Objeto)
        {
            InterfaceCargo.Update(Objeto);
        }
    }
}
