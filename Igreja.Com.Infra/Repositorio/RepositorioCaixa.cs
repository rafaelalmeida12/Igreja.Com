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

        public Caixa BuscarSaldoDoMes(DateTime date)
        {
            using (var busca = new Contexto(dbContextOptions))
            {
                return busca.Caixa.Where(m => m.dateTime.Month==date.Month).FirstOrDefault();
            }
        }
    }
}



