﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Igreja.Com.Dominio.Entidades
{
    public class Oferta : Base
    {
        public Culto TipoCulto { get; set; }
        public string Observacao { get; set; }
        public decimal Valor { get; set; }
        public DateTime DataCadastro { get; set; }
    }
}