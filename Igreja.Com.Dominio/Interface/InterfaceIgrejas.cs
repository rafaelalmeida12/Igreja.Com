﻿using Igreja.Com.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace Igreja.Com.Dominio.Interface
{
    public interface InterfaceIgrejas:InterfaceBase<Igrejas>
    {
        IList<Igrejas> BuscarCedes();
        IList<Igrejas> BuscarFilialPorIgrejaID(int igrejasId);

    }
}
