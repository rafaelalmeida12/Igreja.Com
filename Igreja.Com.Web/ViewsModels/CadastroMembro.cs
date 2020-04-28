using Igreja.Com.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Igreja.Com.Web.ViewsModel
{
    public class CadastroMembro
    {
        public Membro Membro { get; set; }
        public Endereco Endereco { get; set; }
    }
}
