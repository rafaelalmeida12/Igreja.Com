using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Igreja.Com.Dominio.Entidades
{
    public class Igrejas : Base
    {
        [Required(ErrorMessage = "Nome Obrigatorio")]
        public string Nome { get; set; }
        [Required(ErrorMessage = "Rua Obrigatorio")]
        public string Rua { get; set; }
        [Required(ErrorMessage = "Numero Obrigatorio")]
        public string Numero { get; set; }
        [Required(ErrorMessage = "Bairro Obrigatorio")]
        public string Bairro { get; set; }
        public int? IgrejasId { get; set; }
        public ICollection<Igrejas> SubIgrejas { get; set; }
    }
}
