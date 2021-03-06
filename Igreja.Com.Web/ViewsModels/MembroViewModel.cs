﻿using Igreja.Com.Dominio.Entidades;
using Igreja.Com.Dominio.Entidades.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace Igreja.Com.Web.ViewsModels
{
    public class MembroViewModel
    {

        [DisplayName("Nome Completo")]
        public string NomeCompleto { get; set; }
        public TipoEstadoCivel EstadoCivil { get; set; }
        public string Telefone { get; set; }
        public DadosMinisteriais DadosMinisteriais { get; set; }
        public TipoSexo Sexo { get; set; }
        public int CargoId { get; set; }
        public int IgrejaId { get; set; }
        public DateTime DataNascimento { get; set; }
       
    }
}
