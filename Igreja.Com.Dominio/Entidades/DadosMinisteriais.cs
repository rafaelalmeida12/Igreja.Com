using Igreja.Com.Dominio.Entidades.Enum;
using System;
using System.Collections.Generic;
using System.Text;

namespace Igreja.Com.Dominio.Entidades
{
    public class DadosMinisteriais : Base
    {
       
        public TipoSituacao TipoSituacao { get; set; }
        public Cargo Cargo { get; set; }
        public DateTime DataBatismo { get; set; }
        public DateTime DataConversao { get; set; }
        public string ComoConverteu { get; set; }
        public string IgrejaProcedencia { get; set; }
        public DateTime DataMembrado { get; set; }
        public TipoBatizado TipoBatizado { get; set; }
        public TipoDizimista TipoDizimista { get; set; }
        public TipoAdesao TipoAdesao { get; set; }
        public TipoFuncaoExerce TipoFuncaoExerce { get; set; }
    }
}
