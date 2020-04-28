using Igreja.Com.Dominio.Entidades;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Igreja.Com.Aplicacao.InterfaceApp
{
    public interface InterfaceCultoApp : InterfaceBaseApp<Culto>
    {
        List<Culto> GetAll();
    }
}
