﻿using Igreja.Com.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace Igreja.Com.Aplicacao.InterfaceApp
{
    public interface InterfaceDizimoApp : InterfaceBaseApp<Dizimo>
    {
        List<Dizimo> ListDizimo();
    }
}
