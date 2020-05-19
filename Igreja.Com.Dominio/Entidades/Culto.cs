using System;
using System.Collections.Generic;
using System.Text;

namespace Igreja.Com.Dominio.Entidades
{
    public class Culto : Base
    {
        public int CategoriaCultoId { get; set; }
        public CategoriaCulto CategoriaCulto { get; set; }
        public int? MembroId { get; set; }
        public Membro Dirigente { get; set; }
        public IList<Oferta> Ofertas { get; set; }
        public IList<Dizimo> Dizimos { get; set; }
    }
}
