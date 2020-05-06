using Igreja.Com.Dominio.Entidades.Enum;
using System;
using System.Collections.Generic;
using System.Text;

namespace Igreja.Com.Dominio.Entidades
{
    public class Membro : Base
    {
        public string Nome { get; set; }
        public TipoSexo Sexo { get; set; }
        public DateTime DataNascimento { get; set; }
        public TipoEstadoCivel EstadoCivil { get; set; }
        public string Cpf { get; set; }
        public string RG { get; set; }
        public string Profissão { get; set; }
        public string Email { get; set; }
        public string Telefone { get; set; }
        public string Celular { get; set; }
        public TipoEscolaridade Escolaridade { get; set; }
        public string Curso { get; set; }
        public Endereco Endereco { get; set; }
        public DadosMinisteriais DadosMinisteriais { get; set; }
        public int CargoId { get; set; }
        public IEnumerable<Cargo> Cargos { get; set; }
        public int IgrejaId { get; set; }
        public Igrejas Igreja { get; set; } 

    }
}
