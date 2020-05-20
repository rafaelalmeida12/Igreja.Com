using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace Igreja.Com.Web.ViewsModels
{
    public class MembroPDF
    {
        [DisplayName("Nome Completo")]
        public string Nome { get; set; }

        [DisplayName("Data Nascimento")]
        public DateTime DataNascimento { get; set; }

        public string Cpf { get; set; }
        public string RG { get; set; }
        public string Profissão { get; set; }
        public string Email { get; set; }
        public string Telefone { get; set; }
        public string Celular { get; set; }

        [DisplayName("Cargo")]
        public int CargoId { get; set; }
        public string Curso { get; set; }

        [DisplayName("Igreja Congrega")]
        public string Igreja{ get; set; }
        [DisplayName("Estado Civil")]
        public string EstadoCivil { get; set; }
        public string Escolaridade { get; set; }
        public string Sexo { get; set; }
   
        public string Rua { get; set; }
        public string Numero { get; set; }
        public string Bairro { get; set; }
        public string Cidade { get; set; }
        [DisplayName("Batizado")]
        public string Batizado { get; set; }

    }
}
