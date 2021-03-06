﻿using Igreja.Com.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace Igreja.Com.Aplicacao.InterfaceApp
{
    public interface InterfaceIgrejasApp:InterfaceBaseApp<Igrejas>
    {
        IList<Igrejas> BuscarCedes();
        IList<Igrejas> BuscarFilialPorIgrejaID(int igrejasId);
    }
}
