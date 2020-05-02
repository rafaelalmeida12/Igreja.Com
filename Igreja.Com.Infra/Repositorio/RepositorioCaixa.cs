using Igreja.Com.Dominio.Entidades;
using Igreja.Com.Dominio.Interface;
using Igreja.Com.Infra.Configuracao;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Igreja.Com.Infra.Repositorio
{
    public class RepositorioCaixa : RepositorioBase<Caixa>, InterfaceCaixa
    {
        private readonly DbContextOptions<Contexto> dbContextOptions;
        public RepositorioCaixa()
        {
            dbContextOptions = new DbContextOptions<Contexto>();
        }
        public decimal BuscarSaldo()
        {
            using (var busca = new Contexto(dbContextOptions))
            {
                return busca.Oferta.Sum(m => m.Valor);
            }
        }
    }
}
