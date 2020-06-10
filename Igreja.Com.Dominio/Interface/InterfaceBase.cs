using System;
using System.Collections.Generic;
using System.Text;

namespace Igreja.Com.Dominio.Interface
{
    public interface InterfaceBase<T> where T : class
    {
        void Add(T Objeto);
        void Update(T Objeto);
        void Delete(T Objeto);
        int AddRetorno(T Objeto);
        T GetEntityById(int Id);
        List<T> List();
    }
}
