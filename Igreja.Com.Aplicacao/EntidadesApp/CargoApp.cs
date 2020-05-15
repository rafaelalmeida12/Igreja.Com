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
        InterfaceCargo _InterfaceCargo;

        public CargoApp(InterfaceCargo interfaceCargo)
        {
            _InterfaceCargo = interfaceCargo;
        }

        public void Add(Cargo Objeto)
        {
            _InterfaceCargo.Add(Objeto);
        }

        public void Delete(Cargo Objeto)
        {
            throw new NotImplementedException();
        }

        public Cargo GetEntityById(int Id)
        {
            return _InterfaceCargo.GetEntityById(Id);
        }

        public List<Cargo> List()
        {
            return _InterfaceCargo.List();
        }

        public void Update(Cargo Objeto)
        {
            _InterfaceCargo.Update(Objeto);
        }
    }
}
