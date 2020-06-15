using Igreja.Com.Dominio.Entidades;
using Igreja.Com.Dominio.Entidades.Enum;
using Igreja.Com.Dominio.Interface;
using Igreja.Com.Infra.Configuracao;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Igreja.Com.Infra.Repositorio
{
    public class RepositorioMovimentacao : RepositorioBase<Movimentacao>, InterfaceMovimentacao
    {
        private readonly DbContextOptions<Contexto> dbContextOptions;

        public RepositorioMovimentacao()
        {
            this.dbContextOptions = new DbContextOptions<Contexto>();
        }

        public decimal BuscarEntradasDoMes(int month)
        {
            using (var busca = new Contexto(dbContextOptions))
            {
                var dados= busca.Movimentacao.Where(m => m.Data.Month == month && m.TipoDespesa==0).Sum(c=>c.Valor);
                return dados;
            }
        }
        public decimal BuscarSaidaDoMes(int month)
        {
            using (var busca = new Contexto(dbContextOptions))
            {
                var dados = busca.Movimentacao.Where(c => c.Data.Month == month && c.TipoDespesa==TipoDespesa.saida).Sum(c => c.Valor);
                return dados;
            }
        }

        public IList<Movimentacao> BuscarEntreDatas(DateTime data1,DateTime data2)
        {
            using (var busca = new Contexto(dbContextOptions))
            {
                var dados = busca.Movimentacao.Where(c => c.Data.Date >= data1.Date && c.Data.Date <= data2.Date).ToList();
                    return dados;
            }
        }

        public IList<Movimentacao> ListarMes(int month)
        {
            using (var busca = new Contexto(dbContextOptions))
            {
                var dados = busca.Movimentacao.Where(c => c.Data.Month == month).ToList();
                return dados;
            }

        }
    }
}
